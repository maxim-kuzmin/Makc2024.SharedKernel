export interface AppApiErrorResources {
  readonly badRequestErrorMessage: string;
  readonly notFoundErrorMessage: string;
  readonly internalServerErrorMessage: string;
  readonly unknownErrorMessage: string;
}

export function createAppApiErrorResources(options?: Partial<AppApiErrorResources>) {
  const defaultErrorMessage = 'Error';

  return {
    badRequestErrorMessage: options?.badRequestErrorMessage ?? defaultErrorMessage,
    notFoundErrorMessage: options?.notFoundErrorMessage ?? defaultErrorMessage,
    internalServerErrorMessage: options?.internalServerErrorMessage ?? defaultErrorMessage,
    unknownErrorMessage: options?.unknownErrorMessage ?? defaultErrorMessage
  };
}