import {
  AuthorizationLoginActionHandler,
  AuthorizationLoginActionModule,
  createAuthorizationLoginActionModule
} from '@/lib';

export interface AuthorizationActionsModule {
  readonly login: AuthorizationLoginActionModule;
}

interface Options {
  readonly getAuthorizationLoginActionHandler: () => AuthorizationLoginActionHandler;
}

export function createAuthorizationActionsModule({
  getAuthorizationLoginActionHandler
}: Options): AuthorizationActionsModule {
  const login = createAuthorizationLoginActionModule({
    getAuthorizationLoginActionHandler
  });

  return {
    login
  };
}