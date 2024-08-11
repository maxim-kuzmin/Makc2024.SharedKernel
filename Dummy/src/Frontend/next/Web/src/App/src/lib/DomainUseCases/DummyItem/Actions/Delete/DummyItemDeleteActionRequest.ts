import {
  AppApiErrorResources,
  DummyItemDeleteActionCommand,
  RequestBase,
  createAppApiErrorResources,
  createDummyItemDeleteActionCommand,
  createRequestBase
} from '@/lib';

export interface DummyItemDeleteActionRequest extends RequestBase {
  command: DummyItemDeleteActionCommand;
  errorResources: AppApiErrorResources
}

export function createDummyItemDeleteActionRequest(options?: Partial<DummyItemDeleteActionRequest> | null): DummyItemDeleteActionRequest {
  const base = createRequestBase(options?.context);

  return {
    ...base,
    command: options?.command ?? createDummyItemDeleteActionCommand(),
    errorResources: options?.errorResources ?? createAppApiErrorResources()
  };
}