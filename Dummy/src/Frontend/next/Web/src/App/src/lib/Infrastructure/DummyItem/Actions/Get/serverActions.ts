'use server';

import {
  createDummyItemGetActionRequest,
  createRequestContext,
  DummyItemGetActionQuery,
} from '@/lib';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';

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