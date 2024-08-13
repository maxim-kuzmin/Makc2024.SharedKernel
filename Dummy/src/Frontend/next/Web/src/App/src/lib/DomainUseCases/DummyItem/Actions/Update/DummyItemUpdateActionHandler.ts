import { DummyItemGetActionDTO, DummyItemUpdateActionRequest } from '@/lib';

export interface DummyItemUpdateActionHandler {
  readonly handle: (request: DummyItemUpdateActionRequest) => Promise<DummyItemGetActionDTO>;
}
