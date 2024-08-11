import { AppApiErrorResourcesOptions, createAppApiErrorResourcesOptions } from '@/lib';

export interface AppApiErrorResources {
  readonly getBadRequestErrorMessage: () => string;
  readonly getNotFoundErrorMessage: () => string;
  readonly getInternalServerErrorMessage: () => string;
  readonly getUnknownErrorMessage: () => string;
}

export function createAppApiErrorResources(options?: AppApiErrorResourcesOptions): AppApiErrorResources {
  if (!options) {
    options = createAppApiErrorResourcesOptions();
  }

  return {
    getBadRequestErrorMessage: options.getBadRequestErrorMessage ?? (() => options.badRequestErrorMessage),
    getNotFoundErrorMessage: options.getNotFoundErrorMessage ?? (() => options.notFoundErrorMessage),
    getInternalServerErrorMessage: options.getInternalServerErrorMessage ?? (() => options.internalServerErrorMessage),
    getUnknownErrorMessage: options.getUnknownErrorMessage ?? (() => options.unknownErrorMessage)
  };
}