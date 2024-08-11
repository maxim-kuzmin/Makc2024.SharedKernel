import {
  AppApiClient,
  DummyItemDeleteActionRequest,
  DummyItemDeleteActionHandler,
  createAppApiRequest
} from '@/lib';
import indexContext from '@/lib/indexContext';

interface Options {
  readonly appApiClient: AppApiClient;
}

export function createDummyItemDeleteActionHandler({
  appApiClient
}: Options): DummyItemDeleteActionHandler {
  async function handle(request: DummyItemDeleteActionRequest): Promise<void> {
    const appApiRequest = createAppApiRequest({
      endpoint: `${indexContext.dummyItem.actions.settings.rootPath}/${request.query.id}`,
      requestContext: request.context,
      errorResources: request.errorResources
    });

    await appApiClient.delete(appApiRequest);
  }

  return {
    handle
  };
}
