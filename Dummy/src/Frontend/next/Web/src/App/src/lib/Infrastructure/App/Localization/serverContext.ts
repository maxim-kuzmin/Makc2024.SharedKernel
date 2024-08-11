import { createI18nServer, setStaticParamsLocale } from 'next-international/server';

const {
  getCurrentLocale: getCurrentLanguage,
  getScopedI18n: getScopedTranslator,
  getStaticParams: getStaticParamsTranslation,
  getI18n: getTranslator
} = createI18nServer({
  en: () => import('@/locales/en'),
  ru: () => import('@/locales/ru')
});

export const localization = {
  getCurrentLanguage,
  getScopedTranslator,
  getStaticParamsTranslation,
  getTranslator,
  setStaticParamsLocale
};