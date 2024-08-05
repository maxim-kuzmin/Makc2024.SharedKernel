import {
  AppActionsSettings,
  AppApiClient,
  AppLoginActionHandler,
  createAppLoginActionHandler
} from '@/lib';

export interface AppLoginActionModule {
  readonly getHandler: () => AppLoginActionHandler;
}

interface Options {
  readonly getAppActionsSettings: () => AppActionsSettings;
  readonly getAppApiClient: () => AppApiClient;
}

export function createAppLoginActionModule({
  getAppActionsSettings,
  getAppApiClient
}: Options): AppLoginActionModule {
  const appLoginActionHandler = createAppLoginActionHandler({
    appActionsSettings: getAppActionsSettings(),
    appApiClient: getAppApiClient()
  });

  const getHandler = () => appLoginActionHandler;

  return {
    getHandler
  };
}