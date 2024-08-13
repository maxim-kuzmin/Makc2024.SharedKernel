import {
  AppApiClient,
  DummyItemCreateActionRequest,
  DummyItemCreateActionHandler,
  DummyItemGetActionDTO,
  createAppApiRequestWithBody,
  createDummyItemGetActionDTO
} from '@/lib';
import indexContext from '@/lib/indexContext';

interface Options {
  readonly appApiClient: AppApiClient;
}

export function createDummyItemCreateActionHandler({
  appApiClient
}: Options): DummyItemCreateActionHandler {
  async function handle(request: DummyItemCreateActionRequest): Promise<DummyItemGetActionDTO> {
    const appApiRequest = createAppApiRequestWithBody({
      body: request.command, 
      endpoint: indexContext.dummyItem.actions.settings.rootPath,
      requestContext: request.context,
      errorResources: request.errorResources
    });

    const appApiResponse = await appApiClient.post<DummyItemGetActionDTO>(appApiRequest);

    return appApiResponse.data ?? createDummyItemGetActionDTO();
  }

  return {
    handle
  };
}
