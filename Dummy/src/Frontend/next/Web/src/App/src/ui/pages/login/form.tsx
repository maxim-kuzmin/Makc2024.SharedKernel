'use client';

import { lusitana } from '@/ui/fonts';
import {
  UserIcon,
  KeyIcon,
  ExclamationCircleIcon,
} from '@heroicons/react/24/outline';
import { ArrowRightIcon } from '@heroicons/react/20/solid';
import { Button } from '@/ui/components/button';
import { useFormState, useFormStatus } from 'react-dom';
import { serverActionToAppAuthenticationLogin } from '@/lib/serverActions';
import clientContext from '@/lib/clientContext';
import { FormEvent } from 'react';

export default function Form() {
  const [errorMessage, dispatch] = useFormState(serverActionToAppAuthenticationLogin, undefined);

  const appSession = clientContext.app.authentication.useAppSession();

  const t = clientContext.app.localization.useTranslator();

  function onInput(e: FormEvent<HTMLInputElement>) {
    e.currentTarget.setCustomValidity('');
  }

  function onInvalidForPassword(e: FormEvent<HTMLInputElement>) {
    const input = e.currentTarget;

    const validityState = input.validity;

    if (validityState.valueMissing) {
      input.setCustomValidity(t('ui.pages.login._form.field.password.ErrorMessageForRequired'));
    } else if (validityState.tooShort) {
      input.setCustomValidity(t('ui.pages.login._form.field.password.ErrorMessageForMinLength'));
    }
  }

  function onChangeForPassword(e: FormEvent<HTMLInputElement>) {
    onInvalidForPassword(e);
  }

  function onInvalidForUserName(e: FormEvent<HTMLInputElement>) {
    const input = e.currentTarget;

    const validityState = input.validity;

    if (validityState.valueMissing) {
      input.setCustomValidity(t('ui.pages.login._form.field.userName.ErrorMessageForRequired'));
    }
  }

  function onChangeForUserName(e: FormEvent<HTMLInputElement>) {
    onInvalidForUserName(e);
  }

  return (
    <form action={dispatch} className="space-y-3">
      <div className="flex-1 rounded-lg bg-gray-50 px-6 pb-4 pt-8">
        <h1 className={`${lusitana.className} mb-3 text-2xl`}>
          {t('ui.pages.login._form.Title')}
        </h1>
        <div className="w-full">
          <div>
            <label
              className="mb-3 mt-5 block text-xs font-medium text-gray-900"
              htmlFor="email"
            >
              {t('ui.pages.login._form.field.userName.Title')}
            </label>
            <div className="relative">
              <input
                className="peer block w-full rounded-md border border-gray-200 py-[9px] pl-10 text-sm outline-2 placeholder:text-gray-500"
                id="userName"
                name="userName"
                placeholder={t('ui.pages.login._form.field.userName.Placeholder')}
                required
                onChange={onChangeForUserName}
                onInvalid={onInvalidForUserName}
                onInput={onInput}
              />
              <UserIcon className="pointer-events-none absolute left-3 top-1/2 h-[18px] w-[18px] -translate-y-1/2 text-gray-500 peer-focus:text-gray-900" />
            </div>
          </div>
          <div className="mt-4">
            <label
              className="mb-3 mt-5 block text-xs font-medium text-gray-900"
              htmlFor="password"
            >
              {t('ui.pages.login._form.field.password.Title')}
            </label>
            <div className="relative">
              <input
                className="peer block w-full rounded-md border border-gray-200 py-[9px] pl-10 text-sm outline-2 placeholder:text-gray-500"
                id="password"
                type="password"
                name="password"
                placeholder={t('ui.pages.login._form.field.password.Placeholder')}
                required
                minLength={6}
                onChange={onChangeForPassword}
                onInvalid={onInvalidForPassword}
                onInput={onInput}
              />
              <KeyIcon className="pointer-events-none absolute left-3 top-1/2 h-[18px] w-[18px] -translate-y-1/2 text-gray-500 peer-focus:text-gray-900" />
            </div>
          </div>
        </div>
        <LoginButton />
        <div
          className="flex h-8 items-end space-x-1"
          aria-live="polite"
          aria-atomic="true"
        >
          {errorMessage && (
            <>
              <ExclamationCircleIcon className="h-5 w-5 text-red-500" />
              <p className="text-sm text-red-500">{errorMessage}</p>
            </>
          )}
        </div>
      </div>
    </form>
  );
}

function LoginButton() {
  const { pending } = useFormStatus();

  const t = clientContext.app.localization.useTranslator();

  return (
    <Button className="mt-4 w-full" aria-disabled={pending}>
      {t('ui.pages.login._form.button.LogIn')} <ArrowRightIcon className="ml-auto h-5 w-5 text-gray-50" />
    </Button>
  );
}