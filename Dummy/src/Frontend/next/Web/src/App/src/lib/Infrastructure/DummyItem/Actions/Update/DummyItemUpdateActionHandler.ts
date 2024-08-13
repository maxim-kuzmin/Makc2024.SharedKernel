import {
  AppApiClient,
  DummyItemUpdateActionRequest,
  DummyItemUpdateActionHandler,
  DummyItemGetActionDTO,
  createAppApiRequestWithBody,
  createDummyItemGetActionDTO
} from '@/lib';
import indexContext from '@/lib/indexContext';

interface Options {
  readonly appApiClient: AppApiClient;
}

export function createDummyItemUpdateActionHandler({
  appApiClient
}: Options): DummyItemUpdateActionHandler {
  async function handle(request: DummyItemUpdateActionRequest): Promise<DummyItemGetActionDTO> {
    const appApiRequest = createAppApiRequestWithBody({
      body: request.command, 
      endpoint: `${indexContext.dummyItem.actions.settings.rootPath}/${request.command.id}`,
      requestContext: request.context,
      errorResources: request.errorResources
    });

    const appApiResponse = await appApiClient.put<DummyItemGetActionDTO>(appApiRequest);

    return appApiResponse.data ?? createDummyItemGetActionDTO();
  }

  return {
    handle
  };
}
