import {
  createStateBase,
  StateBase
} from '@/lib';

export interface DummyItemTableComponentState extends StateBase {
};

export function createDummyItemTableComponentState(options?: Partial<DummyItemTableComponentState> | null): DummyItemTableComponentState {
  return createStateBase(options);
}