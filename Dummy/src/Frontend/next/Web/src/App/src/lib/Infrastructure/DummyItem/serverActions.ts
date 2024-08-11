'use server';

import {
  createDummyItemDeleteActionRequest,
  createDummyItemGetActionRequest,
  createDummyItemGetListActionRequest,
  createRequestContext,
  DummyItemDeleteActionCommand,
  DummyItemGetActionQuery,
  DummyItemGetListActionQuery,
} from '@/lib';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';

export async function serverActionWithDummyItemToDelete(command: DummyItemDeleteActionCommand) {
  const language = serverContext.app.localization.getCurrentLanguage();

  const errorResources = await serverContext.app.api.getErrorResources();

  const request = createDummyItemDeleteActionRequest({
    command,
    context: createRequestContext({
      language
    }),
    errorResources
  });

  await modules.dummyItem.actions.delete.getHandler().handle(request);
}

export async function serverActionWithDummyItemToGet(query: DummyItemGetActionQuery) {
  const language = serverContext.app.localization.getCurrentLanguage();

  const errorResources = await serverContext.app.api.getErrorResources();

  const request = createDummyItemGetActionRequest({
    query,
    context: createRequestContext({
      language
    }),
    errorResources
  });

  const result = await modules.dummyItem.actions.get.getHandler().handle(request);

  return result;
}

export async function serverActionWithDummyItemToGetList(query: DummyItemGetListActionQuery) {
  const language = serverContext.app.localization.getCurrentLanguage();

  const errorResources = await serverContext.app.api.getErrorResources();

  const request = createDummyItemGetListActionRequest({
    query,
    context: createRequestContext({
      language
    }),
    errorResources
  });

  const result = await modules.dummyItem.actions.getList.getHandler().handle(request);

  return result;
}