import {
  AppActionsModule,
  AppApiClient,
  AppAuthenticationModule,
  AppConfigOptions,
  createAppActionsModule,
  createAppAuthenticationModule,
} from '@/lib';

export interface AppModule {
  readonly actions: AppActionsModule;
  readonly authentication: AppAuthenticationModule;
  readonly getConfigOptions: () => AppConfigOptions;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
  readonly getAppConfigOptions: () => AppConfigOptions;  
}

export function createAppModule({
  getAppApiClient,
  getAppConfigOptions
}: Options): AppModule {
  const actions = createAppActionsModule({
    getAppApiClient
  });

  const authentication = createAppAuthenticationModule({
    getAppLoginActionHandler: actions.login.getHandler
  });

  return {
    actions,
    authentication,
    getConfigOptions: getAppConfigOptions,
  };
}