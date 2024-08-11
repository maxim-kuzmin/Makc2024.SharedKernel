import { localization } from '../Localization/serverContext';

import {
  AppApiErrorResources,
  createAppApiErrorResources,
  createAppApiErrorResourcesOptions
} from '@/lib';

async function getErrorResources(): Promise<AppApiErrorResources> {
  const t = await localization.getTranslator();

  return createAppApiErrorResources(createAppApiErrorResourcesOptions({
    getBadRequestErrorMessage: () => t('lib.app.api.error.BadRequest'),
    getNotFoundErrorMessage: () => t('lib.app.api.error.NotFound'),
    getInternalServerErrorMessage: () => t('lib.app.api.error.InternalServerError'),
    getUnknownErrorMessage: () => t('lib.app.api.error.Unknown')
  }));
}

export const api = {
  getErrorResources
};