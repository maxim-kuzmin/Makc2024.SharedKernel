'use server';

import { revalidatePath } from 'next/cache';

import {
  AppApiError,
  createDummyItemDeleteActionRequest,
  createRequestContext,
  createDummyItemDeleteActionCommand,
  DummyItemTableComponentState,
  createDummyItemTableComponentState,
} from '@/lib';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';
import indexContext from '@/lib/indexContext';

export async function serverActionToDummyItemDelete(id: number): Promise<DummyItemTableComponentState> {
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

  let result: DummyItemTableComponentState;

  try {
    await modules.dummyItem.actions.delete.getHandler().handle(request);

    result = createDummyItemTableComponentState();
  } catch (error) {
    console.error(error);

    const errorMessage = error instanceof AppApiError
      ? error.message
      : 'Failed to Delete Dummy Item';

    result = createDummyItemTableComponentState({
      errorMessage
    });
  }

  if (result.isOk) {
    revalidatePath(indexContext.app.getHrefToDummyItem());
  }

  return result;
}
