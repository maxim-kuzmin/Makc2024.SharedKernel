import { NextAuthResult } from 'next-auth';

import {
  AuthorizationLoginActionHandler,
  createAppAuthenticationNextAuth,
} from '@/lib';

export interface AppAuthenticationModule {
  readonly getNextAuth: () => NextAuthResult;
}

interface Options {
  readonly getAuthorizationLoginActionHandler: () => AuthorizationLoginActionHandler;
}

export function createAppAuthenticationModule({
  getAuthorizationLoginActionHandler
}: Options): AppAuthenticationModule {

  const nextAuth = createAppAuthenticationNextAuth({
    getLoginActionHandler: getAuthorizationLoginActionHandler
  });

  return {
    getNextAuth: () => nextAuth
  }
}