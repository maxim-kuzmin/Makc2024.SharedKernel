import {
  AppActionsModule,
  AppApiClient,
  AppApiErrorResources,
  AppAuthenticationModule,
  AppLocalizationModule,
  createAppActionsModule,
  createAppAuthenticationModule,
  createAppLocalizationModule,
} from '@/lib';

export interface AppModule {
  readonly actions: AppActionsModule;
  readonly authentication: AppAuthenticationModule;
  readonly localization: AppLocalizationModule;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createAppModule({
  getAppApiClient
}: Options): AppModule {
  const actions = createAppActionsModule({
    getAppApiClient
  });

  const authentication = createAppAuthenticationModule({
    getAppLoginActionHandler: actions.login.getHandler
  });

  const localization = createAppLocalizationModule();

  return {
    actions,
    authentication,
    localization
  };
}