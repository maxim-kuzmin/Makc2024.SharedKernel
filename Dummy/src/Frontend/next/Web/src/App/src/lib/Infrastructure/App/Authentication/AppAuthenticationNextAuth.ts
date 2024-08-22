import NextAuth, { NextAuthResult, User } from 'next-auth';
import Credentials from 'next-auth/providers/credentials';
import { z } from 'zod';
import {
  AppLoginActionHandler,
  createAppApiErrorResources,
  createAppLoginActionCommand,
  createAppLoginActionRequest,
  createRequestContext,
} from '@/lib';
import indexContext from '@/lib/indexContext';

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
      signIn: indexContext.app.getHrefToLogin(),
    },
    providers: [
      Credentials({
        async authorize(credentials) {
          let result: User | null = null;

          const parsedCredentials = z
            .object({
              appApiErrorResourcesOptions: z.string(),
              language: z.string(),
              password: z.string(),
              userName: z.string(),
            })
            .safeParse(credentials);

          if (!parsedCredentials.success) {
            console.log('Invalid credentials');

            return null;
          }

          const {
            appApiErrorResourcesOptions,
            language,
            password,
            userName
          } = parsedCredentials.data;

          const appLoginActionHandler = getAppLoginActionHandler();

          const appLoginActionCommand = createAppLoginActionCommand({
            userName,
            password,
          });

          const appLoginActionRequest = createAppLoginActionRequest({
            command: appLoginActionCommand,
            context: createRequestContext({
              language
            }),
            errorResources: createAppApiErrorResources(JSON.parse(appApiErrorResourcesOptions))
          });

          const { userName: name, accessToken } = await appLoginActionHandler.handle(appLoginActionRequest);

          if (name && accessToken) {
            result = {
              name,
              accessToken
            };
          }

          return result;
        },
      }),
    ],
  });
}