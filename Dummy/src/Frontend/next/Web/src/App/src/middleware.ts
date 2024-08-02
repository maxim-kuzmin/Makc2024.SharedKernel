import { createI18nMiddleware } from 'next-international/middleware';
import clientContext from '@/lib/clientContext';

const { auth } = clientContext.app.authentication.getNextAuth();

const {languages, defaultLanguage } = clientContext.app.localization.getSettings();

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