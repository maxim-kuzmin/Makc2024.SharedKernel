import { notFound } from 'next/navigation';
import Form from '@/ui/pages/dummy-item/edit/form';
import Breadcrumbs from '@/ui/pages/dummy-item/breadcrumbs';
import { createDummyItemGetActionQuery } from '@/lib';
import { serverActionToDummyItemGet } from '@/lib/serverActions';
import serverContext from '@/lib/serverContext';
import indexContext from '@/lib/indexContext';

export default async function Page({ params }: { params: { id: number } }) {
  const t = await serverContext.app.localization.getTranslator();

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
          { label: t('app.dummy-item.edit._page.Breadcrumb.1'), href: indexContext.app.getHrefToDummyItem() },
          { label: t('app.dummy-item.edit._page.Breadcrumb.2'), href: indexContext.app.getHrefToDummyItemEdit(id), active: true },
        ]}
      />
      <Form item={item} />
    </main>
  );
}