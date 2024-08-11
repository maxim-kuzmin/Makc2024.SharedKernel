import {
  AppApiErrorResources,
  DummyItemDeleteActionQuery,
  RequestBase,
  createAppApiErrorResources,
  createDummyItemDeleteActionQuery,
  createRequestBase
} from '@/lib';

export interface DummyItemDeleteActionRequest extends RequestBase {
  query: DummyItemDeleteActionQuery;
  errorResources: AppApiErrorResources
}

export function createDummyItemDeleteActionRequest(options?: Partial<DummyItemDeleteActionRequest> | null): DummyItemDeleteActionRequest {
  const base = createRequestBase(options?.context);

  return {
    ...base,
    query: options?.query ?? createDummyItemDeleteActionQuery(),
    errorResources: options?.errorResources ?? createAppApiErrorResources()
  };
}