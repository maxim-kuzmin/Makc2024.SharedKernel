'use server';

import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';
import {
  AppApiError,
  createDummyItemCreateActionCommand,
  createDummyItemCreateActionRequest,
  createDummyItemFormState,
  createRequestContext,
  DummyItemFormState,
} from '@/lib';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';
import indexContext from '@/lib/indexContext';

export async function serverActionToDummyItemCreate(
  prevState: DummyItemFormState,
  formData: FormData
): Promise<DummyItemFormState> {
  const validatedFields = indexContext.dummyItem.form.schema.safeParse({
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
