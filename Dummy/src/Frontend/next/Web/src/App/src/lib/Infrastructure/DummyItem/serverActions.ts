'use server';

import { z } from 'zod';
import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';
import {
  AppApiError,
  createDummyItemCreateActionCommand,
  createDummyItemCreateActionRequest,
  createDummyItemFormState,
  createDummyItemDeleteActionRequest,
  createDummyItemGetActionRequest,
  createDummyItemGetListActionRequest,
  createDummyItemUpdateActionRequest,
  createRequestContext,
  DummyItemFormState,
  DummyItemGetActionQuery,
  DummyItemGetListActionQuery,
  createDummyItemUpdateActionCommand,
  createDummyItemDeleteActionCommand,
  StateBase,
  createStateBase,
} from '@/lib';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';
import indexContext from '@/lib/indexContext';

const FormSchema = z.object({
  name: z.string(),
});

export async function serverActionToDummyItemCreate(
  prevState: DummyItemFormState,
  formData: FormData
): Promise<DummyItemFormState> {
  const validatedFields = FormSchema.safeParse({
    name: formData.get('name'),
  });

  if (!validatedFields.success) {
    return createDummyItemFormState({
      errors: validatedFields.error.flatten().fieldErrors,
      errorMessage: 'Missing Fields. Failed to Create Dummy Item.',
    });
  }

  const { name } = validatedFields.data;

  const command = createDummyItemCreateActionCommand({
    name
  });

  const language = serverContext.app.localization.getCurrentLanguage();

  const errorResources = await serverContext.app.api.getErrorResources();

  const { accessToken } = await serverContext.app.authentication.getAppSession();

  const request = createDummyItemCreateActionRequest({
    command,
    context: createRequestContext({
      accessToken,
      language
    }),
    errorResources
  });

  let state: DummyItemFormState;

  try {
    const result = await modules.dummyItem.actions.create.getHandler().handle(request);

    state = createDummyItemFormState({
      result
    });
  } catch (error) {
    console.error(error);

    const errorMessage = error instanceof AppApiError
      ? error.message
      : 'Failed to Create Dummy Item';

    state = createDummyItemFormState({
      errorMessage
    });
  }

  if (state.isOk) {
    revalidatePath(indexContext.app.getHrefToDummyItem());
    redirect(indexContext.app.getHrefToDummyItem());
  }

  return state;
}

export async function serverActionToDummyItemDelete(id: number): Promise<StateBase> {
  const command = createDummyItemDeleteActionCommand({
    id
  });

  const language = serverContext.app.localization.getCurrentLanguage();

  const errorResources = await serverContext.app.api.getErrorResources();

  const { accessToken } = await serverContext.app.authentication.getAppSession();

  const request = createDummyItemDeleteActionRequest({
    command,
    context: createRequestContext({
      accessToken,
      language
    }),
    errorResources
  });

  let state: StateBase;

  try {
    await modules.dummyItem.actions.delete.getHandler().handle(request);

    state = createStateBase();
  } catch (error) {
    console.error(error);

    const errorMessage = error instanceof AppApiError
      ? error.message
      : 'Failed to Delete Dummy Item';

    state = createStateBase({
      errorMessage
    });
  }

  if (state.isOk) {
    revalidatePath(indexContext.app.getHrefToDummyItem());
  }

  return state;
}

export async function serverActionToDummyItemGet(query: DummyItemGetActionQuery) {
  const language = serverContext.app.localization.getCurrentLanguage();

  const errorResources = await serverContext.app.api.getErrorResources();

  const { accessToken } = await serverContext.app.authentication.getAppSession();

  const request = createDummyItemGetActionRequest({
    query,
    context: createRequestContext({
      accessToken,
      language
    }),
    errorResources
  });

  const result = await modules.dummyItem.actions.get.getHandler().handle(request);

  return result;
}

export async function serverActionToDummyItemGetList(query: DummyItemGetListActionQuery) {
  const language = serverContext.app.localization.getCurrentLanguage();

  const errorResources = await serverContext.app.api.getErrorResources();

  const appSession = await serverContext.app.authentication.getAppSession();

  const { accessToken } = appSession;

  const request = createDummyItemGetListActionRequest({
    query,
    context: createRequestContext({
      accessToken,
      language
    }),
    errorResources
  });

  const result = await modules.dummyItem.actions.getList.getHandler().handle(request);

  return result;
}

export async function serverActionToDummyItemUpdate(
  id: number,
  prevState: DummyItemFormState,
  formData: FormData
): Promise<DummyItemFormState> {
  const validatedFields = FormSchema.safeParse({
    name: formData.get('name'),
  });

  if (!validatedFields.success) {
    return createDummyItemFormState({
      errors: validatedFields.error.flatten().fieldErrors,
      errorMessage: 'Missing Fields. Failed to Update Dummy Item.',
    });
  }

  const { name } = validatedFields.data;

  const command = createDummyItemUpdateActionCommand({
    id,
    name
  });

  const language = serverContext.app.localization.getCurrentLanguage();

  const errorResources = await serverContext.app.api.getErrorResources();

  const { accessToken } = await serverContext.app.authentication.getAppSession();

  const request = createDummyItemUpdateActionRequest({
    command,
    context: createRequestContext({
      accessToken,
      language
    }),
    errorResources
  });

  let state: DummyItemFormState;

  try {
    const result = await modules.dummyItem.actions.update.getHandler().handle(request);

    state = createDummyItemFormState({
      result
    });
  } catch (error) {
    console.error(error);

    const errorMessage = error instanceof AppApiError
      ? error.message
      : 'Failed to Update Dummy Item';

    state = createDummyItemFormState({
      errorMessage
    });
  }
console.log('MAKC:state', state);
  if (state.isOk) {
    revalidatePath(indexContext.app.getHrefToDummyItemEdit(id));
    revalidatePath(indexContext.app.getHrefToDummyItem());
    redirect(indexContext.app.getHrefToDummyItem());
  }

  return state;
}
