'use client';

import {
  HomeIcon,
  DocumentDuplicateIcon,
} from '@heroicons/react/24/outline';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import clsx from 'clsx';
import clientContext from '@/lib/clientContext';
import indexContext from '@/lib/indexContext';

export default function NavLinks() {
  const pathname = usePathname();
  const t = clientContext.app.localization.useTranslator();

  // Map of links to display in the side navigation.
  // Depending on the size of the application, this would be stored in a database.
  const links = [
    { name: t('ui.pages.admin._nav-links.Admin'),
      href: '/admin',
      icon: HomeIcon 
    },
    {
      name: t('ui.pages.admin._nav-links.DummyItem'),
      href: '/admin/dummy-item',
      icon: DocumentDuplicateIcon,
    },
  ];
  
  return (
    <>
      {links.map((link) => {
        const LinkIcon = link.icon;
        return (
          <Link
            key={link.name}
            href={link.href}
            className={clsx(
              'flex h-[48px] grow items-center justify-center gap-2 rounded-md bg-gray-50 p-3 text-sm font-medium hover:bg-sky-100 hover:text-blue-600 md:flex-none md:justify-start md:p-2 md:px-3',
              {
                'bg-sky-100 text-blue-600': indexContext.app.localization.isLocalizedPathSame(pathname, link.href),
              }
            )}
          >
            <LinkIcon className="w-6" />
            <p className="hidden md:block">{link.name}</p>
          </Link>
        );
      })}
    </>
  );
}
