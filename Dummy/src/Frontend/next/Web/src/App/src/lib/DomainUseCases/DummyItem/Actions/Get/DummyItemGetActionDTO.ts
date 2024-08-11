export interface DummyItemGetActionDTO {
  readonly id: number;
  readonly name: string;
}

export function createDummyItemGetActionDTO(options?: Partial<DummyItemGetActionDTO> | null): DummyItemGetActionDTO {
  return {
    id: options?.id ?? 0,
    name: options?.name ?? '',
  };
}