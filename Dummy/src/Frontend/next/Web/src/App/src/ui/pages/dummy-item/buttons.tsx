import { PencilIcon, PlusIcon, TrashIcon } from '@heroicons/react/24/outline';
import Link from 'next/link';
import { serverActionToDummyItemDelete } from '@/lib/serverActions';
import serverContext from '@/lib/serverContext';
import indexContext from '@/lib/indexContext';

export async function CreateDummyItemButton() {
  const t = await serverContext.app.localization.getTranslator();

  return (
    <Link
      href={indexContext.app.getHrefToDummyItemCreate()}
      className="flex h-10 items-center rounded-lg bg-blue-600 px-4 text-sm font-medium text-white transition-colors hover:bg-blue-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600"
    >
      <span className="hidden md:block">{t('ui.pages.dummy-item._buttons.create.Title')}</span>{' '}
      <PlusIcon className="h-5 md:ml-4" />
    </Link>
  );
}

export async function DeleteDummyItemButton({ id }: { id: number }) {
  const t = await serverContext.app.localization.getTranslator();

  const deleteDummyItem = serverActionToDummyItemDelete.bind(null, id);

  return (
    <form action={deleteDummyItem}>
      <button className="rounded-md border p-2 hover:bg-gray-100">
        <span className="sr-only">{t('ui.pages.dummy-item._buttons.delete.Title')}</span>
        <TrashIcon className="w-5" />
      </button>
    </form>
  );
}

export async function UpdateDummyItemButton({ id }: { id: number }) {
  const t = await serverContext.app.localization.getTranslator();

  return (
    <Link
      href={indexContext.app.getHrefToDummyItemEdit(id)}
      className="rounded-md border p-2 hover:bg-gray-100"
      title={t('ui.pages.dummy-item._buttons.edit.Title')}
    >
      <PencilIcon className="w-5" />
    </Link>
  );
}