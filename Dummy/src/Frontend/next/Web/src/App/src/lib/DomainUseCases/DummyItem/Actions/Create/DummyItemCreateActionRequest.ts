import {
  AppApiErrorResources,
  DummyItemCreateActionCommand,
  RequestBase,
  createAppApiErrorResources,
  createDummyItemCreateActionCommand,
  createRequestBase
} from '@/lib';

export interface DummyItemCreateActionRequest extends RequestBase {
  command: DummyItemCreateActionCommand;
  errorResources: AppApiErrorResources
}

export function createDummyItemCreateActionRequest(options?: Partial<DummyItemCreateActionRequest> | null): DummyItemCreateActionRequest {
  const base = createRequestBase(options?.context);

  return {
    ...base,
    command: options?.command ?? createDummyItemCreateActionCommand(),
    errorResources: options?.errorResources ?? createAppApiErrorResources()
  };
}