"use client"
import { createI18nClient } from 'next-international/client'
import { AppApiErrorResources, createContext } from '@/lib';

const {
  I18nProviderClient,
  useChangeLocale: useChangeLanguage,
  useCurrentLocale: useCurrentLanguage,
  useI18n: useTranslator,
  useScopedI18n: useScopedTranslator
} = createI18nClient({
  en: () => import('@/locales/en'),
  ru: () => import('@/locales/ru')
});

function useAppApiErrorResources(): AppApiErrorResources {
  const t = useTranslator();

  return {
    getBadRequestErrorMessage: () => t('App.Api.Error.BadRequest'),
    getNotFoundErrorMessage: () => t('App.Api.Error.NotFound'),
    getInternalServerErrorMessage: () => t('App.Api.Error.InternalServerError'),
    getUnknownErrorMessage: () => t('App.Api.Error.Unknown')
  }
}

function createClientContext() {
  const context = createContext();

  const app = {
    ...context.app,
    api: {
      useErrorResources: useAppApiErrorResources
    },
    localization: {
      ...context.app.localization,
      ContextProvider: I18nProviderClient,
      useChangeLanguage,
      useCurrentLanguage,
      useTranslator,
      useScopedTranslator
    }
  };

  return {
    ...context,
    app
  };
}

const clientContext = createClientContext();

export default clientContext;