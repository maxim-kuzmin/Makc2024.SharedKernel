import {
  createAppApiModule,
  createAppModule,
  createHttpModule
} from '@/lib';

export function createContext() {
  const http = createHttpModule();

  const api = createAppApiModule({
    getHttpClient: http.getClient
  });

  const app = createAppModule({
    getAppApiClient: api.getClient
  });

  return {
    app
  };
}