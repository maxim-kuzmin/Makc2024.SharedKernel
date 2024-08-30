import { createFormState, DummyItemGetActionDTO, FormState } from '@/lib';

interface Errors {
  name?: string[];
}

export interface DummyItemFormState extends FormState<Errors, DummyItemGetActionDTO> {
};

export function createDummyItemFormState(options?: Partial<DummyItemFormState> | null): DummyItemFormState {
  return createFormState<Errors, DummyItemGetActionDTO>(options);
}