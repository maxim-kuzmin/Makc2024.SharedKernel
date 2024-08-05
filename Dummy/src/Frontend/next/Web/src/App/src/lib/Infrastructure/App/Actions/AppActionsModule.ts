import {
  AppActionsSettings,
  AppApiClient,
  AppLoginActionModule,
  createAppActionsSettings,
  createAppLoginActionModule
} from '@/lib';

export interface AppActionsModule {
  readonly getSettings: () => AppActionsSettings;
  readonly login: AppLoginActionModule;  
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createAppActionsModule({
  getAppApiClient
}: Options): AppActionsModule {
  const appActionsSettings = createAppActionsSettings({
    rootPath: 'app'
  });

  const getSettings = () => appActionsSettings;

  const login = createAppLoginActionModule({
    getAppActionsSettings: getSettings,
    getAppApiClient
  });

  return {
    getSettings,
    login
  };
}