export interface DummyItemGetActionQuery {
  readonly id: number;
}

export function createDummyItemGetActionQuery(options?: Partial<DummyItemGetActionQuery> | null): DummyItemGetActionQuery {
  return {
    id: options?.id ?? 0,
  };
}