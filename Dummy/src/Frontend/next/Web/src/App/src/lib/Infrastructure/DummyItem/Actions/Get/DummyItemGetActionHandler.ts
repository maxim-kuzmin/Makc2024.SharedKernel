import {
  AppApiClient,
  DummyItemGetActionRequest,
  DummyItemGetActionHandler,
  createAppApiRequestWithBody,
  DummyItemGetActionDTO,
  createDummyItemGetActionDTO,
} from '@/lib';
import indexContext from '@/lib/indexContext';

interface Options {
  readonly appApiClient: AppApiClient;
}

export function createDummyItemGetActionHandler({
  appApiClient
}: Options): DummyItemGetActionHandler {
  async function handle(request: DummyItemGetActionRequest): Promise<DummyItemGetActionDTO> {
    const appApiRequest = createAppApiRequestWithBody({
      endpoint: `${indexContext.dummyItem.actions.settings.rootPath}/${request.query.id}`,
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
