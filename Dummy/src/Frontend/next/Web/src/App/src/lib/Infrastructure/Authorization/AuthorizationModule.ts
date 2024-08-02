import {
  AppApiClient,
  AuthorizationActionsModule,  
  createAuthorizationActionsModule,
  createAuthorizationLoginActionHandler
} from '@/lib';

export interface AuthorizationModule {
  readonly actions: AuthorizationActionsModule;
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

  return {
    actions
  };
}