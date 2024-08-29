import { createStateBase, StateBase } from '@/lib';

export interface FormState<TErrors, TResult> extends StateBase {
  errors: TErrors | null;
  result: TResult | null;
};

export function createFormState<TErrors, TResult>(options?: Partial<FormState<TErrors, TResult>> | null): FormState<TErrors, TResult> {
  const base = createStateBase(options);

  const errors = options?.errors ?? null;

  return {
    ...base,
    errors,
    result: options?.result ?? null,
    isOk: base.isOk && errors === null,
  };
}