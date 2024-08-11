export interface QueryPage {
  readonly count: number;
  readonly number: number;
}

export function createQueryPage(options?: Partial<QueryPage> | null): QueryPage {
  return {
    count: options?.count ?? 0,
    number: options?.number ?? 1,
  };
}