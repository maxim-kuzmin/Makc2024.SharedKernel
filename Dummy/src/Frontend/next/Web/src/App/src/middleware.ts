import { createI18nMiddleware } from 'next-international/middleware';
import clientContext from '@/lib/clientContext';

const nextAuth = clientContext.authorization.getNextAuth();

const localizationSettings = clientContext.app.localization.getSettings();

const I18nMiddleware = createI18nMiddleware({
  locales: localizationSettings.languages,
  defaultLocale: localizationSettings.defaultLanguage
});

export default nextAuth.auth((request) => {
  return I18nMiddleware(request)
});
 
export const config = {
  // https://nextjs.org/docs/app/building-your-application/routing/middleware#matcher
  matcher: [
    /*
     * Match all request paths except for the ones starting with:
     * - api (API routes)
     * - _next/static (static files)
     * - _next/image (image optimization files)
     * - .*\\..* (any files with extension)
     */    
    '/((?!api|_next/static|_next/image|.*\\..*).*)'
  ],
};