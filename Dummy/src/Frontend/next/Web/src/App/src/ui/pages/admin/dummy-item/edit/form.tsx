'use client';

import Link from 'next/link';
import { useFormState } from 'react-dom';
import { Button } from '@/ui/components/button';
import { DummyItemGetActionDTO } from '@/lib';

interface ServerActionResponse {
  message: string | null;
  errors: {
    name: string,
  } | any;
}

async function serverActionToUpdate(): Promise<ServerActionResponse> {
  var result = await new Promise<ServerActionResponse>(
    (resolve) => setTimeout(resolve, 1000)
  ).then(() => ({
    message: '',
    errors: {}
  } as ServerActionResponse
  ));

  return result;
}

export default function Form({item}:{item: DummyItemGetActionDTO}) {
  const initialState = { message: null, errors: {} };

  const [state, dispatch] = useFormState(serverActionToUpdate, initialState);

  return (
    <form action={dispatch}>
      <div className="rounded-md bg-gray-50 p-4 md:p-6">
        <div className="mb-4">
          <label htmlFor="name" className="mb-2 block text-sm font-medium">
            Name
          </label>
          <div className="relative mt-2 rounded-md">
            <div className="relative">
              <input
                id="name"
                name="name"
                type="text"
                defaultValue={item.name}
                placeholder="Enter name"
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
      </div>
      <div className="mt-6 flex justify-end gap-4">
        <Link
          href="/admin/dummy-item"
          className="flex h-10 items-center rounded-lg bg-gray-100 px-4 text-sm font-medium text-gray-600 transition-colors hover:bg-gray-200"
        >
          Cancel
        </Link>
        <Button type="submit">Edit Dummy item</Button>
      </div>
    </form>
  );
}
