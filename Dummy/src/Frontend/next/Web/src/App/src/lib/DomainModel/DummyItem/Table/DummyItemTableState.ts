import {
  createStateBase,
  StateBase
} from '@/lib';

export interface DummyItemTableState extends StateBase {
};

export function createDummyItemTableState(options?: Partial<DummyItemTableState> | null): DummyItemTableState {
  const base = createStateBase(options);

  return {
    ...base,
  };
}