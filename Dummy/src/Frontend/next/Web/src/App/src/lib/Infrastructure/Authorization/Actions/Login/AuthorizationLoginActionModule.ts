import { AuthorizationLoginActionHandler } from '@/lib';

export interface AuthorizationLoginActionModule {
  readonly getHandler: () => AuthorizationLoginActionHandler;
}

interface Options {
  readonly getAuthorizationLoginActionHandler: () => AuthorizationLoginActionHandler;
}

export function createAuthorizationLoginActionModule({
  getAuthorizationLoginActionHandler
}: Options): AuthorizationLoginActionModule {
  return {
    getHandler: getAuthorizationLoginActionHandler
  }
}