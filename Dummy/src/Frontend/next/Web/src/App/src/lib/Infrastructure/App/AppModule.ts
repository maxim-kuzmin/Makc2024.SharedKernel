import {
  AppLocalizationModule,
  createAppLocalizationModule
} from '@/lib';

export interface AppModule {
  readonly localization: AppLocalizationModule;
}

export function createAppModule(): AppModule {
  const localization = createAppLocalizationModule();

  return {
    localization
  };
}