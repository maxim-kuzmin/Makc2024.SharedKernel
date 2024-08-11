import { DummyItemGetListActionDTO, DummyItemGetListActionRequest } from '@/lib';

export interface DummyItemGetListActionHandler {
  readonly handle: (request: DummyItemGetListActionRequest) => Promise<DummyItemGetListActionDTO>;
}
