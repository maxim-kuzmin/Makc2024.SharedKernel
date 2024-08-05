import NextAuth, { NextAuthResult, User } from 'next-auth';
import Credentials from 'next-auth/providers/credentials';
import { z } from 'zod';
import {
  AppApiErrorResources,
  AppLoginActionHandler,
  createAppApiErrorResources,
  createAppLoginActionCommand,
  createAppLoginActionRequest,
  createRequestContext,
} from '@/lib';

declare module "next-auth" {
  /**
   * The shape of the user object returned in the OAuth providers' `profile` callback,
   * or the second parameter of the `session` callback, when using a database.
   */
  interface User {
    accessToken: string
  }
}

interface Options {
  readonly getAppLoginActionHandler: () => AppLoginActionHandler;
}

export function createAppAuthenticationNextAuth({
  getAppLoginActionHandler,
}: Options): NextAuthResult {
  return NextAuth({
    pages: {
      signIn: '/login',
    },
    callbacks: {
      authorized({ auth, request: { nextUrl } }) {
        // const isLoggedIn = !!auth?.user;

        // const pathToRedirect = '/dashboard';

        // const index = nextUrl.pathname.indexOf(pathToRedirect);

        // const isOnDashboard = index === 0 || index === 3;

        // if (isOnDashboard) {
        //   if (isLoggedIn) return true;
        //   return false; // Redirect unauthenticated users to login page
        // } else if (isLoggedIn) {
        //   return Response.redirect(new URL(pathToRedirect, nextUrl));
        // }

        return true;
      }
    },
    providers: [
      Credentials({
        async authorize(credentials) {
          let result: User | null = null;

          const parsedCredentials = z
            .object({
              userName: z.string(),
              password: z.string(),
              language: z.string(),
              appApiErrorResources: z.string()
            })
            .safeParse(credentials);

          if (parsedCredentials.success) {
            const { userName, password, language, appApiErrorResources } = parsedCredentials.data;

            const appLoginActionHandler = getAppLoginActionHandler();

            const appLoginActionCommand = createAppLoginActionCommand({
              userName,
              password
            });

            const appLoginActionRequest = createAppLoginActionRequest({
              command: appLoginActionCommand,
              context: createRequestContext({
                language
              }),
              errorResources: JSON.parse(appApiErrorResources)
            });

            const { userName: name, accessToken } = await appLoginActionHandler.handle(appLoginActionRequest);
console.log('MAKC:name', name);
            if (name && accessToken) {
              result = {
                name,
                accessToken
              };
            }
          } else {
            console.log('Invalid credentials');
          }

          return result;
        },
      }),
    ],
  });
}