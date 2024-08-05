'use client';

import clientContext from '@/lib/clientContext';
 
export default function SubLayout({
    params: { locale },
    children
  }: {
    params: { locale: string },
    children: React.ReactNode 
  }) {
  const LocalizationContextProvider = clientContext.app.localization.ContextProvider;

  return (
    <LocalizationContextProvider locale={locale}>
      {children}
    </LocalizationContextProvider>
  )
}