import {
  AppApiErrorResources,
  DummyItemGetListActionQuery,
  RequestBase,
  createAppApiErrorResources,
  createDummyItemGetListActionQuery,
  createRequestBase
} from '@/lib';

export interface DummyItemGetListActionRequest extends RequestBase {
  query: DummyItemGetListActionQuery;
  errorResources: AppApiErrorResources
}

export function createDummyItemGetListActionRequest(options?: Partial<DummyItemGetListActionRequest> | null): DummyItemGetListActionRequest {
  const base = createRequestBase(options?.context);

  return {
    ...base,
    query: options?.query ?? createDummyItemGetListActionQuery(),
    errorResources: options?.errorResources ?? createAppApiErrorResources()
  };
}