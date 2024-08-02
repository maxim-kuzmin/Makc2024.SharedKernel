import {
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

  const authorization = createAuthorizationModule({
    getAppApiClient: api.getClient
  });

  const app = createAppModule({
    getAuthorizationLoginActionHandler: () => authorization.actions.login.getHandler()
  });

  return {
    app,
    authorization
  };
}