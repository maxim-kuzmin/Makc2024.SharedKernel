import { localization } from '../Localization/clientContext';

import {
  AppApiErrorResources,
  createAppApiErrorResources,
  createAppApiErrorResourcesOptions
} from '@/lib';

async function getErrorResources(): Promise<AppApiErrorResources> {
  const t = localization.useTranslator();

  return createAppApiErrorResources(createAppApiErrorResourcesOptions({
    getBadRequestErrorMessage: () => t('lib.app.api.error.BadRequest'),
    getNotFoundErrorMessage: () => t('lib.app.api.error.NotFound'),
    getInternalServerErrorMessage: () => t('lib.app.api.error.InternalServerError'),
    getUnauthorizedErrorMessage: () => t('lib.app.api.error.Unauthorized'),
    getUnknownErrorMessage: () => t('lib.app.api.error.Unknown')
  }));
}

export const api = {
  getErrorResources
};