import {
  AppLocalizationSettings,
  createAppLocalizationSettings
} from '@/lib';

export interface AppLocalizationModule {
  readonly getSettings: () => AppLocalizationSettings;
}

export function createAppLocalizationModule(): AppLocalizationModule {
  const languagesEnv = process.env.NEXT_PUBLIC_LOCALIZATION_LANGUAGES ?? '';

  if (!languagesEnv) {
    throw new Error('Languages are not configured');
  }

  const languages = languagesEnv.split(',');

  const defaultLanguage = process.env.NEXT_PUBLIC_LOCALIZATION_DEFAULT_LANGUAGE ?? languages[0];

  const appLocalizationSettings = createAppLocalizationSettings({
    defaultLanguage,
    languages
  });

  const getSettings = () => appLocalizationSettings;

  return {
    getSettings
  };
}