'use server';

import {
  createDummyItemCreateActionRequest,
  createDummyItemDeleteActionRequest,
  createDummyItemGetActionRequest,
  createDummyItemGetListActionRequest,
  createDummyItemUpdateActionRequest,
  createRequestContext,
  DummyItemCreateActionCommand,
  DummyItemDeleteActionCommand,
  DummyItemGetActionQuery,
  DummyItemGetListActionQuery,
  DummyItemUpdateActionCommand,
} from '@/lib';
import modules from '@/lib/modules';
import serverContext from '@/lib/serverContext';

export async function serverActionToDummyItemCreate(command: DummyItemCreateActionCommand) {
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

  const result = await modules.dummyItem.actions.create.getHandler().handle(request);

  return result;
}

export async function serverActionToDummyItemDelete(command: DummyItemDeleteActionCommand) {
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

  await modules.dummyItem.actions.delete.getHandler().handle(request);
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
  
  const {accessToken} = appSession;
  
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

export async function serverActionToDummyItemUpdate(command: DummyItemUpdateActionCommand) {
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

  const result = await modules.dummyItem.actions.update.getHandler().handle(request);

  return result;
}
