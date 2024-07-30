import serverContext from '@/lib/serverContext';

export default async function DashboardPage() {  
  const t = await serverContext.app.localization.getTranslator();
  const scopedT = await serverContext.app.localization.getScopedTranslator('hello');

  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
      <h1>Dashboard</h1>
      <div>
        <p>{t('hello')}</p>

        {/* Both are equivalent: */}
        <p>{t('hello.world')}</p>
        <p>{scopedT('world')}</p>

        <p>{t('welcome', { name: 'John' })}</p>
        <p>{t('welcome', { name: <strong>John</strong> })}</p>
      </div>      
    </main>
  );
}