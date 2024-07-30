import {
  AppApiErrorResources,
  createAppApiModule,
  createAppModule,
  createAuthorizationModule,
  createHttpModule
} from '@/lib';

export function createContext() {
  const http = createHttpModule();

  const api = createAppApiModule({
    getHttpClient: http.getClient
  });

  const app = createAppModule();

  const authorization = createAuthorizationModule({
    getAppApiClient: api.getClient
  });

  return {
    app,
    authorization
  };
}