import { DummyItemGetActionDTO, DummyItemGetActionRequest } from '@/lib';

export interface DummyItemGetActionHandler {
  readonly handle: (request: DummyItemGetActionRequest) => Promise<DummyItemGetActionDTO>;
}
