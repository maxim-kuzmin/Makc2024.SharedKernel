import { CreateDummyItemButton } from '@/ui/pages/admin/dummy-item/buttons';
import { lusitana } from '@/ui/fonts';
import serverContext from '@/lib/serverContext';

export async function generateMetadata() {
  const t = await serverContext.app.localization.getTranslator();

  return {
    title: t('app.admin.dummy-item._page.Title'),
  }
}

export default async function Page() {
  const t = await serverContext.app.localization.getTranslator();

  return (
    <div className="w-full">
      <div className="flex w-full items-center justify-between">
        <h1 className={`${lusitana.className} text-2xl`}>{t('app.admin.dummy-item._page.Title')}</h1>
      </div>
      <div className="mt-4 flex items-center justify-between gap-2 md:mt-8">
        <CreateDummyItemButton />
      </div>
    </div>
  );
}