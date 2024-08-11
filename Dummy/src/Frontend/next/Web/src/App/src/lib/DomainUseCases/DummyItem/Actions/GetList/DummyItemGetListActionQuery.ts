import { DummyItemGetListActionQueryFilter, QueryPage } from '@/lib';

export interface DummyItemGetListActionQuery {
  readonly filter?: DummyItemGetListActionQueryFilter | null;
  readonly page?: QueryPage | null;
}

export function createDummyItemGetListActionQuery(options?: Partial<DummyItemGetListActionQuery> | null): DummyItemGetListActionQuery {
  return {
    filter: options?.filter ?? null,
    page: options?.page ?? null,
  };
}