export interface QueryOrder {
  readonly field: string;
  readonly isDesc: boolean;
}

export function createQueryOrder(options?: Partial<QueryOrder> | null): QueryOrder {
  return {
    field: options?.field ?? '',
    isDesc: options?.isDesc ?? false,
  };
}