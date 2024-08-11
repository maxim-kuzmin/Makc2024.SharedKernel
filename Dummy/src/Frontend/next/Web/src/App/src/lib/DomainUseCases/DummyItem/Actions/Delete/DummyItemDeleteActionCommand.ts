export interface DummyItemDeleteActionQuery {
  readonly id: number;
}

export function createDummyItemDeleteActionQuery(options?: Partial<DummyItemDeleteActionQuery> | null): DummyItemDeleteActionQuery {
  return {
    id: options?.id ?? 0,
  };
}