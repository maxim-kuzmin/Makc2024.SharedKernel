import { DummyItemCreateActionRequest, DummyItemGetActionDTO } from '@/lib';

export interface DummyItemCreateActionHandler {
  readonly handle: (request: DummyItemCreateActionRequest) => Promise<DummyItemGetActionDTO>;
}
