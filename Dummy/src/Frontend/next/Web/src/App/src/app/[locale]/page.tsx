import { WrenchScrewdriverIcon } from '@heroicons/react/24/outline';
import Logo from '@/ui/components/logo';
import { ArrowRightIcon } from '@heroicons/react/24/outline';
import Link from 'next/link';
import { lusitana } from '@/ui/fonts';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';
import indexContext from '@/lib/indexContext';
import Language from '@/ui/components/language';

export default async function Page() {
  const t = await serverContext.app.localization.getTranslator();

  const appConfigOptions = modules.app.getConfigOptions();

  return (
    <main className="flex min-h-screen flex-col p-6">
      <div className="flex flex-col gap-3 min-h-32 shrink-0 items-center justify-between rounded-lg bg-blue-500 p-4">
        <Logo />
        <Language />
      </div>
      <div className="mt-4 flex grow flex-col gap-4 md:flex-row">
        <div className="flex flex-col gap-6 justify-center rounded-lg bg-gray-50 px-6 py-10 md:px-20">
          <WrenchScrewdriverIcon className="h-20 w-20" />
          <p className={`text-xl text-gray-800 md:text-3xl md:leading-normal ${lusitana.className}`}>
            <strong>{t('app._page.Content.Welcome.1')}</strong> {t('app._page.Content.Welcome.2')}{' '}
            <a href={appConfigOptions.author.url} className="text-blue-500" target="_blank">
              {t('app._page.Content.Welcome.3')}
            </a>
            {t('app._page.Content.Welcome.4')}
          </p>
          <Link
            href={indexContext.app.getHrefToLogin()}
            className="flex items-center gap-5 self-start rounded-lg bg-blue-500 px-6 py-3 text-sm font-medium text-white transition-colors hover:bg-blue-400 md:text-base"
          >
            <span>{t('app._page.Login')}</span> <ArrowRightIcon className="w-5 md:w-6" />
          </Link>
        </div>
        <div className='flex grow flex-col gap-4 md:flex-row flex-wrap'>
        <div className="flex flex-col gap-6 p-6 md:px-28 md:py-12">
            <p className={`text-xl text-gray-800 md:text-3xl md:leading-normal ${lusitana.className}`}>
              <strong>{t('app._page.Content.DummyItem.1')}</strong> {t('app._page.Content.DummyItem.2')}
            </p>
            <Link
              href={indexContext.app.getHrefToDummyItem()}
              className="flex items-center gap-5 self-start rounded-lg bg-blue-500 px-6 py-3 text-sm font-medium text-white transition-colors hover:bg-blue-400 md:text-base"
            >
              <span>{t('app._page.GoToDummyItem')}</span> <ArrowRightIcon className="w-5 md:w-6" />
            </Link>
          </div>
        </div>
      </div>
    </main>
  );
}
