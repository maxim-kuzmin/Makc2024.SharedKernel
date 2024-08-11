import { PlusIcon } from '@heroicons/react/24/outline';
import Link from 'next/link';
import serverContext from '@/lib/serverContext';

export async function CreateDummyItemButton() {
  const t = await serverContext.app.localization.getTranslator();

  return (
    <Link
      href="/admin/dummy-item/create"
      className="flex h-10 items-center rounded-lg bg-blue-600 px-4 text-sm font-medium text-white transition-colors hover:bg-blue-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600"
    >
      <span className="hidden md:block">{t('ui.pages.admin.dummy-item._buttons.Create')}</span>{' '}
      <PlusIcon className="h-5 md:ml-4" />
    </Link>
  );
}
