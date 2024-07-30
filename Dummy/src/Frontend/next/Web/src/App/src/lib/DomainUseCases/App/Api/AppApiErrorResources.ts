export interface AppApiErrorResources {
  readonly getBadRequestErrorMessage: () => string;
  readonly getNotFoundErrorMessage: () => string;
  readonly getInternalServerErrorMessage: () => string;
  readonly getUnknownErrorMessage: () => string;
}

function getDefaultErrorMessage() {
  return 'Error';
}

export function createAppApiErrorResources(options?: Partial<AppApiErrorResources>) {
  return {
    getBadRequestErrorMessage: options?.getBadRequestErrorMessage ?? getDefaultErrorMessage,
    getNotFoundErrorMessage: options?.getNotFoundErrorMessage ?? getDefaultErrorMessage,
    getInternalServerErrorMessage: options?.getInternalServerErrorMessage ?? getDefaultErrorMessage,
    getUnknownErrorMessage: options?.getUnknownErrorMessage ?? getDefaultErrorMessage
  };
}