import {
  AppApiClient,
  AppLoginActionModule,
  createAppLoginActionModule
} from '@/lib';

export interface AppActionsModule {
  readonly login: AppLoginActionModule;  
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createAppActionsModule({
  getAppApiClient
}: Options): AppActionsModule {
  const login = createAppLoginActionModule({
    getAppApiClient
  });

  return {
    login,
  };
}