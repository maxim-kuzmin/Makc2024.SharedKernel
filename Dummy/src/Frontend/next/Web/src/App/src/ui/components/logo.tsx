import { lusitana } from '../fonts';
import serverContext from '@/lib/serverContext';

export default async function Logo() {
  const t = await serverContext.app.localization.getTranslator();

  return (
    <p className={`${lusitana.className} text-[44px] leading-tight text-white text-center`}>{t('ui.components._logo.Title')}</p>
  );
}
