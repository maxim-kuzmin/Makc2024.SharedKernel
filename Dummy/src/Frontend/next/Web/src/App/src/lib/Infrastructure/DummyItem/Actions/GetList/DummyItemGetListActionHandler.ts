import {
  AppApiClient,
  DummyItemGetListActionRequest,
  DummyItemGetListActionHandler,
  createAppApiRequestWithBody,
  DummyItemGetListActionDTO,
  createDummyItemGetListActionDTO,
} from '@/lib';
import indexContext from '@/lib/indexContext';

interface Options {
  readonly appApiClient: AppApiClient;
}

export function createDummyItemGetListActionHandler({
  appApiClient
}: Options): DummyItemGetListActionHandler {
  async function handle(request: DummyItemGetListActionRequest): Promise<DummyItemGetListActionDTO> {
    const appApiRequest = createAppApiRequestWithBody({
      query: {
        ...(request.query.page && {
          'currentPage': request.query.page.number,
          'itemsPerPage': request.query.page.size,
        }),
        ...(request.query.filter?.fullTextSearchQuery && {
          'query': request.query.filter?.fullTextSearchQuery
        }),
      },
      endpoint: indexContext.dummyItem.actions.settings.rootPath,
      requestContext: request.context,
      errorResources: request.errorResources
    });

    const appApiResponse = await appApiClient.post<DummyItemGetListActionDTO>(appApiRequest);

    return appApiResponse.data ?? createDummyItemGetListActionDTO();
  }

  return {
    handle
  };
}
