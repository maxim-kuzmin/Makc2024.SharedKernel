import {
  AppAuthenticationModule,
  AppLocalizationModule,
  AuthorizationLoginActionHandler,
  createAppAuthenticationModule,
  createAppLocalizationModule
} from '@/lib';

export interface AppModule {
  readonly authentication: AppAuthenticationModule;
  readonly localization: AppLocalizationModule;
}

interface Options {
  readonly getAuthorizationLoginActionHandler: () => AuthorizationLoginActionHandler;
}

export function createAppModule({
  getAuthorizationLoginActionHandler
}: Options): AppModule {
  const authentication = createAppAuthenticationModule({
    getAuthorizationLoginActionHandler
  });

  const localization = createAppLocalizationModule();

  return {
    authentication,
    localization
  };
}