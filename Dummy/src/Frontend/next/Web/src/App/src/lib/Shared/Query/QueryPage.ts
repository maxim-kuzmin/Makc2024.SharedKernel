export interface QueryPage {
  readonly size: number;
  readonly number: number;
}

export function createQueryPage(options?: Partial<QueryPage> | null): QueryPage {
  return {
    size: options?.size ?? 0,
    number: options?.number ?? 1,
  };
}