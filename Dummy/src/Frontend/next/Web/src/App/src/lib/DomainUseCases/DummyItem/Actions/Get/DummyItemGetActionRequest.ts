import {
  AppApiErrorResources,
  DummyItemGetActionQuery,
  RequestBase,
  createAppApiErrorResources,
  createDummyItemGetActionQuery,
  createRequestBase
} from '@/lib';

export interface DummyItemGetActionRequest extends RequestBase {
  query: DummyItemGetActionQuery;
  errorResources: AppApiErrorResources
}

export function createDummyItemGetActionRequest(options?: Partial<DummyItemGetActionRequest> | null): DummyItemGetActionRequest {
  const base = createRequestBase(options?.context);

  return {
    ...base,
    query: options?.query ?? createDummyItemGetActionQuery(),
    errorResources: options?.errorResources ?? createAppApiErrorResources()
  };
}