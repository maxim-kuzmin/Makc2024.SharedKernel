'use server';

import { revalidatePath } from 'next/cache';

import {
  AppApiError,
  createDummyItemDeleteActionRequest,
  createRequestContext,
  createDummyItemDeleteActionCommand,
  DummyItemTableState,
  createDummyItemTableState,
} from '@/lib';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';
import indexContext from '@/lib/indexContext';

export async function serverActionToDummyItemDelete(id: number): Promise<DummyItemTableState> {
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

  let state: DummyItemTableState;

  try {
    await modules.dummyItem.actions.delete.getHandler().handle(request);

    state = createDummyItemTableState();
  } catch (error) {
    console.error(error);

    const errorMessage = error instanceof AppApiError
      ? error.message
      : 'Failed to Delete Dummy Item';

    state = createDummyItemTableState({
      errorMessage
    });
  }

  if (state.isOk) {
    revalidatePath(indexContext.app.getHrefToDummyItem());
  }

  return state;
}
