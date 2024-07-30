import {
  AppApiClient,
  AppApiErrorResources,
  AppApiSettings,
  HttpClient,
  createAppApiClient,
  createAppApiSettings
} from '@/lib';

export interface AppApiModule {
  readonly getClient: () => AppApiClient;
  readonly getSettings: () => AppApiSettings;
}

interface Options {
  readonly getHttpClient: () => HttpClient
}

export function createAppApiModule({
  getHttpClient
}: Options): AppApiModule {
  const settings = createAppApiSettings({
    url: process.env.NEXT_PUBLIC_API_URL
  });

  const client = createAppApiClient({
    appApiSettings: settings,
    httpClient: getHttpClient()
  });

  return {
    getClient: () => client,
    getSettings: () => settings
  }
}