import {
  AppApiErrorResources,
  DummyItemUpdateActionCommand,
  RequestBase,
  createAppApiErrorResources,
  createDummyItemUpdateActionCommand,
  createRequestBase
} from '@/lib';

export interface DummyItemUpdateActionRequest extends RequestBase {
  command: DummyItemUpdateActionCommand;
  errorResources: AppApiErrorResources
}

export function createDummyItemUpdateActionRequest(options?: Partial<DummyItemUpdateActionRequest> | null): DummyItemUpdateActionRequest {
  const base = createRequestBase(options?.context);

  return {
    ...base,
    command: options?.command ?? createDummyItemUpdateActionCommand(),
    errorResources: options?.errorResources ?? createAppApiErrorResources()
  };
}