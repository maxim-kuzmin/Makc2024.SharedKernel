'use server';

import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';
import {
  AppApiError,
  createDummyItemCreateActionCommand,
  createDummyItemCreateActionRequest,
  createDummyItemFormComponentState,
  createRequestContext,
  DummyItemFormComponentState,
} from '@/lib';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';
import indexContext from '@/lib/indexContext';

export async function serverActionToDummyItemCreate(
  prevState: DummyItemFormComponentState,
  formData: FormData
): Promise<DummyItemFormComponentState> {
  let result: DummyItemFormComponentState;

  const validatedFields = indexContext.dummyItem.components.form.schema.safeParse({
    name: formData.get('name'),
  });

  if (validatedFields.success) {
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
  
    try {
      const data = await modules.dummyItem.actions.create.getHandler().handle(request);
  
      result = createDummyItemFormComponentState({
        data
      });
    } catch (error) {
      console.error(error);
  
      const errorMessage = error instanceof AppApiError
        ? error.message
        : 'Failed to Create Dummy Item';
  
      result = createDummyItemFormComponentState({
        errorMessage
      });
    }
  
    if (result.isOk) {
      revalidatePath(indexContext.app.getHrefToDummyItem());
      redirect(indexContext.app.getHrefToDummyItem());
    }  
  } else {
    result = createDummyItemFormComponentState({
      errors: validatedFields.error.flatten().fieldErrors,
      errorMessage: 'Missing Fields. Failed to Create Dummy Item.',
    });
  }

  return result;
}
