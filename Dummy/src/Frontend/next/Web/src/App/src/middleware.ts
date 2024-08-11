import { createI18nMiddleware } from 'next-international/middleware';
import modules from '@/lib/modules';

const { auth } = modules.app.authentication.getNextAuth();

const appConfigOptions = modules.app.getConfigOptions();

const {languages, defaultLanguage } = appConfigOptions.localization;

const I18nMiddleware = createI18nMiddleware({
  locales: languages,
  defaultLocale: defaultLanguage
});

export default auth((request) => {
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