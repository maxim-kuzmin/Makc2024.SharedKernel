import {
  AppApiClient,
  AppConfigOptionsApi,
  HttpClient,
  createAppApiClient,
} from '@/lib';

export interface AppApiModule {
  readonly getClient: () => AppApiClient;
}

interface Options {
  readonly getAppConfigOptionsApi: () => AppConfigOptionsApi;
  readonly getHttpClient: () => HttpClient;
}

export function createAppApiModule({
  getAppConfigOptionsApi,
  getHttpClient
}: Options): AppApiModule {
  const appApiClient = createAppApiClient({
    appConfigOptionsApi: getAppConfigOptionsApi(),
    httpClient: getHttpClient()
  });

  const getClient = () => appApiClient;

  return {
    getClient
  };
}