'use client';

import { SessionProvider } from 'next-auth/react';
import clientContext from '@/lib/clientContext';
 
export default function SubLayout({
    params: { locale },
    children
  }: {
    params: { locale: string },
    children: React.ReactNode 
  }) {
  const AppLocalizationContextProvider = clientContext.app.localization.ContextProvider;

  return (
    <SessionProvider>
    <AppLocalizationContextProvider locale={locale}>
      {children}
    </AppLocalizationContextProvider>
    </SessionProvider>
  )
}