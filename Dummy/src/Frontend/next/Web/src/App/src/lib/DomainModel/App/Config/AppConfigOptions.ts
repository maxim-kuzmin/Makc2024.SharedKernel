import {
  AppConfigOptionsApi,
  AppConfigOptionsAuthor,
  AppConfigOptionsJira,
  AppConfigOptionsLocalization,
  createAppConfigOptionsApi,
  createAppConfigOptionsAuthor,
  createAppConfigOptionsJira,
  createAppConfigOptionsLocalization
} from '@/lib';

export interface AppConfigOptions {
  readonly api: AppConfigOptionsApi;
  readonly author: AppConfigOptionsAuthor;
  readonly localization: AppConfigOptionsLocalization;
}

export function createAppConfigOptions(options?: Partial<AppConfigOptions> | null): AppConfigOptions {
  return {
    api: options?.api ?? createAppConfigOptionsApi(),
    author: options?.author ?? createAppConfigOptionsAuthor(),
    localization: options?.localization ?? createAppConfigOptionsLocalization()
  };
}