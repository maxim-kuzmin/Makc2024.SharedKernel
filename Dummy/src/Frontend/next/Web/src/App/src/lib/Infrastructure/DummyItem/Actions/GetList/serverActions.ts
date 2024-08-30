'use server';

import {
  createDummyItemGetListActionRequest,
  createRequestContext,
  DummyItemGetListActionQuery,
} from '@/lib';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';

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