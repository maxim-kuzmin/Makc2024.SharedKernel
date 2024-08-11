'use server';

import { createDummyItemGetListActionRequest, createRequestContext, DummyItemGetListActionQuery } from '@/lib';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';

export async function serverActionWithDummyItemToGetList(query: DummyItemGetListActionQuery) {
  const language = serverContext.app.localization.getCurrentLanguage();

  const errorResources = await serverContext.app.api.getErrorResources();

  const appLoginActionRequest = createDummyItemGetListActionRequest({
    query,
    context: createRequestContext({
      language
    }),
    errorResources
  });

  const result = await modules.dummyItem.actions.getList.getHandler().handle(appLoginActionRequest);

  return result;
}