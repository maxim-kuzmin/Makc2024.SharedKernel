import { DummyItemDeleteActionRequest } from '@/lib';

export interface DummyItemDeleteActionHandler {
  readonly handle: (request: DummyItemDeleteActionRequest) => Promise<void>;
}
