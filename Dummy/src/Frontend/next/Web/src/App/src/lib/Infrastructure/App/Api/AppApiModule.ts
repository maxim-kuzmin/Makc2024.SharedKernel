import {
  AppApiClient,
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
  readonly getHttpClient: () => HttpClient;
}

export function createAppApiModule({
  getHttpClient
}: Options): AppApiModule {
  const appApiSettings = createAppApiSettings({
    url: process.env.NEXT_PUBLIC_API_URL
  });

  const getSettings = () => appApiSettings;

  const appApiClient = createAppApiClient({
    appApiSettings,
    httpClient: getHttpClient()
  });

  const getClient = () => appApiClient;

  return {
    getClient,
    getSettings
  }
}