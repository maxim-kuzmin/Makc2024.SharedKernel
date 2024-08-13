import { Suspense } from 'react';
import { CreateDummyItemButton } from '@/ui/pages/admin/dummy-item/buttons';
import { lusitana } from '@/ui/fonts';
import serverContext from '@/lib/serverContext';
import { createDummyItemGetListActionQuery } from '@/lib';
import { serverActionWithDummyItemToGetList } from '@/lib/serverActions';
import Search from '@/ui/components/search';
import { InvoicesTableSkeleton } from '@/ui/components/skeletons';
import Table from '@/ui/pages/admin/dummy-item/table';
import Pagination from '@/ui/components/pagination';

export async function generateMetadata() {
  const t = await serverContext.app.localization.getTranslator();

  return {
    title: t('app.admin.dummy-item._page.Title'),
  }
}

const pageSize = 10;

export default async function Page({
  searchParams,
}: {
  searchParams?: {
    query?: string;
    page?: string;
  };
}) {
  const t = await serverContext.app.localization.getTranslator();

  const fullTextSearchQuery = searchParams?.query || '';
  const currentPage = Number(searchParams?.page) || 1;

  const query = createDummyItemGetListActionQuery({
    filter: {
      fullTextSearchQuery
    },
    page: {
      size: pageSize,
      number: currentPage
    }
  });

  const data = await serverActionWithDummyItemToGetList(query);

  const totalPages = Math.ceil(data.totalCount / pageSize);

  return (
    <div className="w-full">
      <div className="flex w-full items-center justify-between">
        <h1 className={`${lusitana.className} text-2xl`}>{t('app.admin.dummy-item._page.Title')}</h1>
      </div>
      <div className="mt-4 flex items-center justify-between gap-2 md:mt-8">
        <Search placeholder="Search invoices..." />
        <CreateDummyItemButton />
      </div>
      <Suspense key={fullTextSearchQuery + currentPage} fallback={<InvoicesTableSkeleton />}>
        <Table items={data.items} />
      </Suspense>
      <div className="mt-5 flex w-full justify-center">
        <Pagination totalPages={totalPages} />
      </div>      
    </div>
  );
}