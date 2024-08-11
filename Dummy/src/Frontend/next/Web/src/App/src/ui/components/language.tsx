'use client';


import clientContext from '@/lib/clientContext';
import { FormEvent } from 'react';

export default function Language() {
  const currentLanguage = clientContext.app.localization.useCurrentLanguage();

  const changeLanguage = clientContext.app.localization.useChangeLanguage();

  function onChange(e: FormEvent<HTMLSelectElement>) {
    const select = e.currentTarget;

    if (select.value === 'en' || select.value === 'ru') {
      changeLanguage(select.value);
    }
  }
  
  return (
    <select defaultValue={currentLanguage} onChange={onChange} className='rounded-lg'>
      <option value={'ru'}>по-русски</option>
      <option value={'en'}>in English</option>
    </select>
  );
}
