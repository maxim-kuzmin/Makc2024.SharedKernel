import {AppApiErrorResources } from '@/lib';
import indexContext from '@/lib/indexContext';

export interface AppApiErrorResourcesOptions extends Partial<AppApiErrorResources> {
  readonly badRequestErrorMessage: string;
  readonly notFoundErrorMessage: string;
  readonly internalServerErrorMessage: string;
  readonly unauthorizedErrorMessage: string;
  readonly unknownErrorMessage: string;
}

export function createAppApiErrorResourcesOptions(options?: Partial<AppApiErrorResourcesOptions> | null): AppApiErrorResourcesOptions {
  const getMessage = indexContext.app.localization.getMessage;

  return {
    badRequestErrorMessage: getMessage(options?.getBadRequestErrorMessage, options?.badRequestErrorMessage),
    notFoundErrorMessage: getMessage(options?.getNotFoundErrorMessage, options?.notFoundErrorMessage),
    internalServerErrorMessage: getMessage(options?.getInternalServerErrorMessage, options?.internalServerErrorMessage),
    unauthorizedErrorMessage: getMessage(options?.getUnauthorizedErrorMessage, options?.unauthorizedErrorMessage),
    unknownErrorMessage: getMessage(options?.getUnknownErrorMessage, options?.unknownErrorMessage),
  };
}