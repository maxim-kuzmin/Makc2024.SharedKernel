export interface StateBase {
  readonly errorMessage: string | null;
  readonly isOk: boolean;
};

export function createStateBase(options?: Partial<StateBase> | null): StateBase {
  const errorMessage = options?.errorMessage ?? null;

  return {
    errorMessage,
    isOk: errorMessage === null,
  };
}