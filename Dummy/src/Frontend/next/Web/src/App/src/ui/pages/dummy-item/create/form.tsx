'use client';

import Link from 'next/link';
import { useFormState } from 'react-dom';
import { Button } from '@/ui/components/button';
import clientContext from '@/lib/clientContext';
import indexContext from '@/lib/indexContext';

interface ServerActionResponse {
  errorMessage: string | null;
  errors: {
    name: string,
  } | any;
}

async function serverActionToCreate(): Promise<ServerActionResponse> {
  var result = await new Promise<ServerActionResponse>(
    (resolve) => setTimeout(resolve, 1000)
  ).then(() => ({
    errorMessage: '',
    errors: {}
  } as ServerActionResponse
  ));

  return result;
}

export default function Form() {
  const initialState = { errorMessage: null, errors: {} };

  const [state, dispatch] = useFormState(serverActionToCreate, initialState);

  const t = clientContext.app.localization.useTranslator();

  return (
    <form action={dispatch}>
      <div className="rounded-md bg-gray-50 p-4 md:p-6">
        <div className="mb-4">
          <label htmlFor="name" className="mb-2 block text-sm font-medium">
            {t('ui.pages.dummy-item.create._form.field.name.Title')}
          </label>
          <div className="relative mt-2 rounded-md">
            <div className="relative">
              <input
                id="name"
                name="name"
                type="text"
                placeholder={t('ui.pages.dummy-item.create._form.field.name.Title')}
                className="peer block w-full rounded-md border border-gray-200 py-2 pl-10 text-sm outline-2 placeholder:text-gray-500"
                aria-describedby="name-error"
              />
            </div>
          </div>
          <div id="name-error" aria-live="polite" aria-atomic="true">
            {state.errors?.name &&
              state.errors.name.map((error: string) => (
                <p className="mt-2 text-sm text-red-500" key={error}>
                  {error}
                </p>
              ))}
          </div>
        </div>
        <div aria-live="polite" aria-atomic="true">
          {state.errorMessage &&
            <p className="mt-2 text-sm text-red-500">
              {state.errorMessage}
            </p>
          }
        </div>
      </div>
      <div className="mt-6 flex justify-end gap-4">
        <Link
          href={indexContext.app.getHrefToDummyItem()}
          className="flex h-10 items-center rounded-lg bg-gray-100 px-4 text-sm font-medium text-gray-600 transition-colors hover:bg-gray-200"
        >
          {t('ui.pages.dummy-item.create._form.button.cancel.Title')}
        </Link>
        <Button type="submit">{t('ui.pages.dummy-item.create._form.button.create.Title')}</Button>
      </div>
    </form>
  );
}
