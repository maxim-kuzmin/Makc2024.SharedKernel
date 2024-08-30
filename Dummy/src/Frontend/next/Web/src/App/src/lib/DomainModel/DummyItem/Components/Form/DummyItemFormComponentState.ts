import {
  createFormState,
  DummyItemGetActionDTO,
  FormState
} from '@/lib';

interface Errors {
  name?: string[];
}

export interface DummyItemFormComponentState extends FormState<DummyItemGetActionDTO, Errors> {
};

export function createDummyItemFormComponentState(options?: Partial<DummyItemFormComponentState> | null): DummyItemFormComponentState {
  return createFormState<DummyItemGetActionDTO, Errors>(options);
}