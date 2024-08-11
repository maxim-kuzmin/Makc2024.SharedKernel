import {
  AppApiClient,
  AppLoginActionHandler,
  createAppLoginActionHandler
} from '@/lib';

export interface AppLoginActionModule {
  readonly getHandler: () => AppLoginActionHandler;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createAppLoginActionModule({
  getAppApiClient
}: Options): AppLoginActionModule {
  const appLoginActionHandler = createAppLoginActionHandler({
    appApiClient: getAppApiClient()
  });

  const getHandler = () => appLoginActionHandler;

  return {
    getHandler
  };
}