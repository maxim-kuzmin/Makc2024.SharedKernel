import { NextAuthResult } from 'next-auth';

import {
  AppLoginActionHandler,
  createAppAuthenticationNextAuth,
} from '@/lib';

export interface AppAuthenticationModule {
  readonly getNextAuth: () => NextAuthResult;
}

interface Options {
  readonly getAppLoginActionHandler: () => AppLoginActionHandler;
}

export function createAppAuthenticationModule({
  getAppLoginActionHandler
}: Options): AppAuthenticationModule {

  const nextAuth = createAppAuthenticationNextAuth({
    getAppLoginActionHandler
  });

  const getNextAuth = () => nextAuth;

  return {
    getNextAuth
  };
}