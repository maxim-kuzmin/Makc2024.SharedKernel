export interface DummyItemGetListActionQueryFilter {
  readonly fullTextSearchQuery?: string | null;
}

export function createDummyItemGetListActionQueryFilter(options?: Partial<DummyItemGetListActionQueryFilter> | null): DummyItemGetListActionQueryFilter {
  return {
    fullTextSearchQuery: options?.fullTextSearchQuery ?? null,
  };
}