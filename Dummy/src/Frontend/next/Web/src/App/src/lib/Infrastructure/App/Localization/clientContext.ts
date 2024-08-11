import { createI18nClient } from 'next-international/client';

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

export const localization = {
  ContextProvider: I18nProviderClient,
  useChangeLanguage,
  useCurrentLanguage,
  useTranslator,
  useScopedTranslator
};