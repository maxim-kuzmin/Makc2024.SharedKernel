import { notFound } from 'next/navigation';
import Form from '@/ui/pages/admin/dummy-item/edit/form';
import Breadcrumbs from '@/ui/pages/admin/dummy-item/breadcrumbs';
import { createDummyItemGetActionQuery } from '@/lib';
import { serverActionWithDummyItemToGet } from '@/lib/serverActions';

export default async function Page({ params }: { params: { id: number } }) {
  const id = params.id;

  const query = createDummyItemGetActionQuery({
    id
  });

  const item = await serverActionWithDummyItemToGet(query);
  
  if (!item.id) {
    notFound();
  }

  return (
    <main>
      <Breadcrumbs
        breadcrumbs={[
          { label: 'Dummy items', href: '/admin/dummy-item' },
          {
            label: 'Edit Dummy item',
            href: `/admin/dummy-item/${id}/edit`,
            active: true,
          },
        ]}
      />
      <Form item={item} />
    </main>
  );
}