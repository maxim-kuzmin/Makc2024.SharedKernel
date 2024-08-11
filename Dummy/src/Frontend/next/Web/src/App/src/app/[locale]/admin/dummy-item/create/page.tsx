import Breadcrumbs from '@/ui/pages/admin/dummy-item/breadcrumbs';
import CreateForm from '@/ui/pages/admin/dummy-item/create-form';
import serverContext from '@/lib/serverContext';

export default async function Page() {
  const t = await serverContext.app.localization.getTranslator();

  return (
    <main>
      <Breadcrumbs
        breadcrumbs={[
          { label: t('app.admin.dummy-item.create._page._page.Breadcrumb.1'), href: '/admin/dummy-item' },
          { label: t('app.admin.dummy-item.create._page._page.Breadcrumb.2'), href: '/admin/dummy-item/create', active: true },
        ]}
      />
      <CreateForm />
    </main>
  );
}