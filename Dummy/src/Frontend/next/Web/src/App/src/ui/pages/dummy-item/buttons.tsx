import { PencilIcon, PlusIcon, TrashIcon } from '@heroicons/react/24/outline';
import Link from 'next/link';
import { serverActionWithDummyItemToDelete } from '@/lib/serverActions';
import serverContext from '@/lib/serverContext';
import { createDummyItemDeleteActionCommand } from '@/lib';
import indexContext from '@/lib/indexContext';

export async function CreateDummyItemButton() {
  const t = await serverContext.app.localization.getTranslator();

  return (
    <Link
      href={indexContext.app.getHrefToDummyItemCreate()}
      className="flex h-10 items-center rounded-lg bg-blue-600 px-4 text-sm font-medium text-white transition-colors hover:bg-blue-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-600"
    >
      <span className="hidden md:block">{t('ui.pages.dummy-item._buttons.Create')}</span>{' '}
      <PlusIcon className="h-5 md:ml-4" />
    </Link>
  );
}

export function DeleteDummyItemButton({ id }: { id: number }) {
  const command = createDummyItemDeleteActionCommand({
    id
  });

  const deleteDummyItem = serverActionWithDummyItemToDelete.bind(null, command);

  return (
    <form action={deleteDummyItem}>
      <button className="rounded-md border p-2 hover:bg-gray-100">
        <span className="sr-only">Delete</span>
        <TrashIcon className="w-5" />
      </button>
    </form>
  );
}

export function UpdateDummyItemButton({ id }: { id: number }) {
  return (
    <Link
      href={indexContext.app.getHrefToDummyItemEdit(id)}
      className="rounded-md border p-2 hover:bg-gray-100"
    >
      <PencilIcon className="w-5" />
    </Link>
  );
}