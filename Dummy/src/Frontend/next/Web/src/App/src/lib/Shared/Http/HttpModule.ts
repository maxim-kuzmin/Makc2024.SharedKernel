import { HttpClient, createHttpClient } from '@/lib';

export interface HttpModule {
  readonly getClient: () => HttpClient;
}

export function createHttpModule(): HttpModule {
  const httpClient = createHttpClient();

  return {
    getClient: () => httpClient
  };
}