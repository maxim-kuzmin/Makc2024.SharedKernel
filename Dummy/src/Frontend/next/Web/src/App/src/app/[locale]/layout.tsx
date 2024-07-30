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
  children,
}: {
  children: React.ReactNode;
}) {
  const language = serverContext.app.localization.getCurrentLanguage();

  return (
    <html lang={language}>
      <body className={`${inter.className} antialiased`}>{children}</body>
    </html>
  );
}