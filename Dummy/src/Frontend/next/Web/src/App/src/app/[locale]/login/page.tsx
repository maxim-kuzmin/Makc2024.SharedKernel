import Logo from '@/ui/components/logo';
import Form from '@/ui/pages/login/form';
import serverContext from '@/lib/serverContext';
import Language from '@/ui/components/language';
import Link from 'next/link';

export default async function Page() {
  const appSession = await serverContext.app.authentication.getAppSession();

  return (
    <main className="flex items-center justify-center md:h-screen">
      <div className="relative mx-auto flex w-full max-w-[400px] flex-col space-y-2.5 p-4 md:-mt-32">
        <div className="flex flex-col gap-3 min-h-32 shrink-0 items-center justify-between rounded-lg bg-blue-500 p-4">
          <Link href="/">
            <Logo />
          </Link>
          <Language />
        </div>
        <Form />
      </div>
    </main>
  );
}