import { NextAuthResult } from 'next-auth';

import {
  AppApiClient,
  AuthorizationActionsModule,  
  createAuthorizationActionsModule,
  createAuthorizationLoginActionHandler,
  createAuthorizationNextAuth
} from '@/lib';

export interface AuthorizationModule {
  readonly actions: AuthorizationActionsModule;
  getNextAuth(): NextAuthResult;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createAuthorizationModule({
  getAppApiClient
}: Options): AuthorizationModule {
  const loginActionHandler = createAuthorizationLoginActionHandler({
    appApiClient: getAppApiClient()
  });

  const actions = createAuthorizationActionsModule({
    getAuthorizationLoginActionHandler: () => loginActionHandler
  });

  const nextAuth = createAuthorizationNextAuth({
    getLoginActionHandler: () => loginActionHandler
  });

  return {
    actions,
    getNextAuth: () => nextAuth
  }
}