import NextAuth, { NextAuthResult, User } from 'next-auth';
import Credentials from 'next-auth/providers/credentials';
import { z } from 'zod';
import {
  createAuthorizationLoginActionCommand,
  createAuthorizationLoginActionRequest,
  AuthorizationLoginActionHandler
} from '@/lib';

declare module "next-auth" {
  /**
   * The shape of the user object returned in the OAuth providers' `profile` callback,
   * or the second parameter of the `session` callback, when using a database.
   */
  interface User {
    token: string
  }
}

interface Options {
  getLoginActionHandler: () => AuthorizationLoginActionHandler;
}

export function createAppAuthenticationNextAuth({
  getLoginActionHandler
}: Options): NextAuthResult {
  return NextAuth({
    pages: {
      signIn: '/login',
    },
    callbacks: {
      authorized({ auth, request: { nextUrl } }) {
        // const isLoggedIn = !!auth?.user;

        // const pathToRedirect = '/dummy-item';

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
            .object({ userName: z.string(), password: z.string() })
            .safeParse(credentials);

          if (parsedCredentials.success) {
            const { userName, password } = parsedCredentials.data;

            const loginActionHandler = getLoginActionHandler();

            const authorizationLoginActionCommand = createAuthorizationLoginActionCommand({
              userName,
              password
            });

            const authorizationLoginActionRequest = createAuthorizationLoginActionRequest({
              command: authorizationLoginActionCommand
            });

            const token = await loginActionHandler.handle(authorizationLoginActionRequest);

            if (token) {
              result = {
                name: userName,
                token
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