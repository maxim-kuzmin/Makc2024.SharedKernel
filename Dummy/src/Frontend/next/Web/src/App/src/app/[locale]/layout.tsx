import '@/ui/globals.css';
import { inter } from '@/ui/fonts';
import serverContext from '@/lib/serverContext';

export async function generateMetadata() {
  const t = await serverContext.app.localization.getTranslator();

  const title = t('app.layout.Title');

  return {
    title: {
      template: `%s | ${title}`,
      default: title,
    },
    description: 'The official Next.js Learn Dashboard built with App Router.',
    metadataBase: new URL('https://next-learn-dashboard.vercel.sh'),
  }
}
export default function RootLayout({
    params: { locale },
    children 
  }: {
    params: { locale: string },
    children: React.ReactNode 
  }) {
  return (
    <html lang={locale}>
      <body className={`${inter.className} antialiased`}>{children}</body>
    </html>
  );
}