'use server';

import { revalidatePath } from 'next/cache';
import { redirect } from 'next/navigation';
import {
  AppApiError,
  createDummyItemFormComponentState,
  createDummyItemUpdateActionRequest,
  createRequestContext,
  DummyItemFormComponentState,  
  createDummyItemUpdateActionCommand,
} from '@/lib';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';
import indexContext from '@/lib/indexContext';

export async function serverActionToDummyItemUpdate(
  id: number,
  prevState: DummyItemFormComponentState,
  formData: FormData
): Promise<DummyItemFormComponentState> {
  let result: DummyItemFormComponentState;

  const validatedFields = indexContext.dummyItem.components.form.schema.safeParse({
    name: formData.get('name'),
  });

  if (validatedFields.success) {
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
  
    try {
      const data = await modules.dummyItem.actions.update.getHandler().handle(request);
  
      result = createDummyItemFormComponentState({
        data
      });
    } catch (error) {
      console.error(error);
  
      const errorMessage = error instanceof AppApiError
        ? error.message
        : 'Failed to Update Dummy Item';
  
      result = createDummyItemFormComponentState({
        errorMessage
      });
    }
  
    if (result.isOk) {
      revalidatePath(indexContext.app.getHrefToDummyItemEdit(id));
      revalidatePath(indexContext.app.getHrefToDummyItem());
      redirect(indexContext.app.getHrefToDummyItem());
    }  
  } else {
    result = createDummyItemFormComponentState({
      errors: validatedFields.error.flatten().fieldErrors,
      errorMessage: 'Missing Fields. Failed to Update Dummy Item.',
    });
  }

  return result;
}
