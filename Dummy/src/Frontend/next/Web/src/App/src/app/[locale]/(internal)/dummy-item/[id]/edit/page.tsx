import { notFound } from 'next/navigation';
import Form from '@/ui/pages/dummy-item/edit/form';
import Breadcrumbs from '@/ui/pages/dummy-item/breadcrumbs';
import { createDummyItemGetActionQuery } from '@/lib';
import { serverActionToDummyItemGet } from '@/lib/serverActions';
import indexContext from '@/lib/indexContext';

export default async function Page({ params }: { params: { id: number } }) {
  const id = params.id;

  const query = createDummyItemGetActionQuery({
    id
  });

  const item = await serverActionToDummyItemGet(query);
  
  if (!item.id) {
    notFound();
  }

  return (
    <main>
      <Breadcrumbs
        breadcrumbs={[
          { label: 'Dummy items', href: indexContext.app.getHrefToDummyItem() },
          {
            label: 'Edit Dummy item',
            href: indexContext.app.getHrefToDummyItemEdit(id),
            active: true,
          },
        ]}
      />
      <Form item={item} />
    </main>
  );
}