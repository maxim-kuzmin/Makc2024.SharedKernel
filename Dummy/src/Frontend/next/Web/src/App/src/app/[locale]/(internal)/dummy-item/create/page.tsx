import Breadcrumbs from '@/ui/pages/dummy-item/breadcrumbs';
import Form from '@/ui/pages/dummy-item/create/form';
import serverContext from '@/lib/serverContext';
import indexContext from '@/lib/indexContext';

export default async function Page() {
  const t = await serverContext.app.localization.getTranslator();

  return (
    <main>
      <Breadcrumbs
        breadcrumbs={[
          { label: t('app.dummy-item.create._page.Breadcrumb.1'), href: indexContext.app.getHrefToDummyItem() },
          { label: t('app.dummy-item.create._page.Breadcrumb.2'), href: indexContext.app.getHrefToDummyItemCreate(), active: true },
        ]}
      />
      <Form />
    </main>
  );
}