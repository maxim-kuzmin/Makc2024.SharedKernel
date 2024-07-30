import { createI18nServer, setStaticParamsLocale } from 'next-international/server';
import { AppApiErrorResources, createContext } from '@/lib';

const {
  getCurrentLocale: getCurrentLanguage,
  getScopedI18n: getScopedTranslator,
  getStaticParams: getStaticParamsTranslation,
  getI18n: getTranslator 
} = createI18nServer({
  en: () => import('@/locales/en'),
  ru: () => import('@/locales/ru')
});

async function getAppApiErrorResources(): Promise<AppApiErrorResources> {
  const t = await getTranslator();

  return {
    getBadRequestErrorMessage: () => t('App.Api.Error.BadRequest'),
    getNotFoundErrorMessage: () => t('App.Api.Error.NotFound'),
    getInternalServerErrorMessage: () => t('App.Api.Error.InternalServerError'),
    getUnknownErrorMessage: () => t('App.Api.Error.Unknown')
  }
}

function createServerContext() {
  const context = createContext();

  const app = {
    ...context.app,
    api: {
      getErrorResources: getAppApiErrorResources
    },
    localization: {
      ...context.app.localization,
      getCurrentLanguage,
      getScopedTranslator,
      getStaticParamsTranslation,
      getTranslator 
    }
  };

  return {
    ...context,
    app
  };
}

const serverContext = createServerContext();

export default serverContext;