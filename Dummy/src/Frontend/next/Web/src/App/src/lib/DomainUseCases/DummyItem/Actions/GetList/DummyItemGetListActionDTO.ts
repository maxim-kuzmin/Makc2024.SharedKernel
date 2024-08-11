import { DummyItemGetListActionDTOItem } from '@/lib';

export interface DummyItemGetListActionDTO {
  readonly items: DummyItemGetListActionDTOItem[];
  readonly totalCount: number;
}

export function createDummyItemGetListActionDTO(options?: Partial<DummyItemGetListActionDTO> | null): DummyItemGetListActionDTO {
  return {
    items: options?.items ?? [],
    totalCount: options?.totalCount ?? 0,
  };
}