import {
  AppApiErrorResources,
  AuthorizationLoginActionCommand,
  RequestBase,
  createAppApiErrorResources,
  createAuthorizationLoginActionCommand,
  createRequestBase
} from '@/lib';

export interface AuthorizationLoginActionRequest extends RequestBase {
  command: AuthorizationLoginActionCommand;
  errorResources: AppApiErrorResources
}

export function createAuthorizationLoginActionRequest(
  options?: Partial<AuthorizationLoginActionRequest>
): AuthorizationLoginActionRequest {
  const base = createRequestBase(options?.context);

  return {
    ...base,
    command: options?.command ?? createAuthorizationLoginActionCommand(),
    errorResources: options?.errorResources ?? createAppApiErrorResources()
  };
}