import {
  AppApiErrorResources,
  AppLoginActionCommand,
  RequestBase,
  createAppApiErrorResources,
  createAppLoginActionCommand,
  createRequestBase
} from '@/lib';

export interface AppLoginActionRequest extends RequestBase {
  command: AppLoginActionCommand;
  errorResources: AppApiErrorResources
}

export function createAppLoginActionRequest(
  options?: Partial<AppLoginActionRequest> | null
): AppLoginActionRequest {
  const base = createRequestBase(options?.context);

  return {
    ...base,
    command: options?.command ?? createAppLoginActionCommand(),
    errorResources: options?.errorResources ?? createAppApiErrorResources()
  };
}