export interface DummyItemGetListActionDTOItem {
  readonly id: number;
  readonly name: string;
}

export function createDummyItemGetListActionDTOItem(options?: Partial<DummyItemGetListActionDTOItem> | null): DummyItemGetListActionDTOItem {
  return {
    id: options?.id ?? 0,
    name: options?.name ?? '',
  };
}