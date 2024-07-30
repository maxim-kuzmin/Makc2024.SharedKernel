import NextAuth, { NextAuthResult, User } from 'next-auth';
import Credentials from 'next-auth/providers/credentials';
import { z } from 'zod';
import {
  createAuthorizationLoginActionCommand,
  createAuthorizationLoginActionRequest,
  AuthorizationLoginActionHandler
} from '@/lib';

interface Options {
  getLoginActionHandler: () => AuthorizationLoginActionHandler;
}

export function createAuthorizationNextAuth({
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
      },
    },
    providers: [
      Credentials({
        async authorize(credentials) {
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

            const user = await loginActionHandler.handle(authorizationLoginActionRequest);

            if (!user) {
              return null;
            }

            return {
              name: userName
            } as User;
          }

          console.log('Invalid credentials');

          return null;
        },
      }),
    ],
  });
}