import { createStateBase, StateBase } from '@/lib';

export interface FormState<TData, TErrors> extends StateBase {
  data: TData | null;
  errors: TErrors | null;
};

export function createFormState<TData, TErrors>(options?: Partial<FormState<TData, TErrors>> | null): FormState<TData, TErrors> {
  const base = createStateBase(options);

  const errors = options?.errors ?? null;

  return {
    ...base,
    data: options?.data ?? null,
    errors,
    isOk: base.isOk && errors === null,
  };
}