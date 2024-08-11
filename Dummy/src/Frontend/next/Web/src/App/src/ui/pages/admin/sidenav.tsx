import Link from 'next/link';
import NavLinks from '@/ui/pages/admin/nav-links';
import Logo from '@/ui/components/logo';
import { PowerIcon } from '@heroicons/react/24/outline';
import { serverActionToAppAuthenticationAtLogout } from '@/lib/serverActions';
import serverContext from '@/lib/serverContext';
import Language from '@/ui/components/language';

export default async function SideNav() {
  const t = await serverContext.app.localization.getTranslator();

  return (
    <div className="flex h-full flex-col px-3 py-4 md:px-2">
      <div className="flex flex-col gap-3 min-h-32 shrink-0 items-center justify-between rounded-lg bg-blue-500 p-4">
        <Link href="/">
          <Logo />
        </Link>
        <Language />
      </div>

      <div className="flex grow flex-row justify-between space-x-2 md:flex-col md:space-x-0 md:space-y-2">
        <NavLinks />
        <div className="hidden h-auto w-full grow rounded-md bg-gray-50 md:block"></div>
        <form action={serverActionToAppAuthenticationAtLogout}>
          <button className="flex h-[48px] w-full grow items-center justify-center gap-2 rounded-md bg-gray-50 p-3 text-sm font-medium hover:bg-sky-100 hover:text-blue-600 md:flex-none md:justify-start md:p-2 md:px-3">
            <PowerIcon className="w-6" />
            <div className="hidden md:block">{t('ui.pages.admin._sidenav.LogOut')}</div>
          </button>
        </form>
      </div>
    </div>
  );
}
