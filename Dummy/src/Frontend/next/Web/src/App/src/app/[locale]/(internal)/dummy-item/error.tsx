'use client';
 
import { useEffect } from 'react';
import clientContext from '@/lib/clientContext';

export default function Error({
  error,
  reset,
}: {
  error: Error & { digest?: string };
  reset: () => void;
}) {
  const t = clientContext.app.localization.useTranslator();

  useEffect(() => {
    // Optionally log the error to an error reporting service
    console.error(error);
  }, [error]);
 
  return (
    <main className="flex h-full flex-col items-center justify-center">
      <h2 className="text-center">{t('app.dummy-item._error.Title')}</h2>
      <button
        className="mt-4 rounded-md bg-blue-500 px-4 py-2 text-sm text-white transition-colors hover:bg-blue-400"
        onClick={
          // Attempt to recover by trying to re-render the route
          () => reset()
        }
      >
        {t('app.dummy-item._error.button.tryAgain.Title')}
      </button>
    </main>
  );
}