import NextAuth, { DefaultSession, NextAuthResult, User } from 'next-auth';
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
import { AdapterUser } from 'next-auth/adapters';

declare module "next-auth" {
  interface User {
    accessToken: string,
  }
}

declare module "@auth/core/jwt" {
  interface JWT {
    user: AdapterUser,
  }
}

interface Options {
  readonly getAppLoginActionHandler: () => AppLoginActionHandler;
}

export function createAppAuthenticationNextAuth({
  getAppLoginActionHandler,
}: Options): NextAuthResult {
  return NextAuth({
    session: {
      strategy: 'jwt'
    },
    pages: {
      signIn: indexContext.app.getHrefToLogin(),
    },
    callbacks: {
      async session({ session, token, user }) {
        session.user = token.user;

        return session;
      },
      async jwt({ token, user, account }) {
        if (account) {
          token.user = user as AdapterUser;
        }

        return token;
      }
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

          const appLoginActionDTO = await appLoginActionHandler.handle(appLoginActionRequest);

          const { userName: name, accessToken } = appLoginActionDTO;

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