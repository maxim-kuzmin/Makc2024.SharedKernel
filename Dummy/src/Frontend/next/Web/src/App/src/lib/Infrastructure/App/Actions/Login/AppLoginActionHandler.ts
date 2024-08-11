import {
  AppApiClient,
  AppLoginActionRequest,
  AppLoginActionHandler,
  createAppApiRequestWithBody,
  AppLoginActionDTO,
  createAppLoginActionDTO,
} from '@/lib';
import indexContext from '@/lib/indexContext';

interface Options {
  readonly appApiClient: AppApiClient;
}

export function createAppLoginActionHandler({
  appApiClient 
}: Options): AppLoginActionHandler {
  async function handle(request: AppLoginActionRequest): Promise<AppLoginActionDTO> {
    const appApiRequest = createAppApiRequestWithBody({
      body: request.command,
      endpoint: `${indexContext.app.actions.settings.rootPath}/login`,
      requestContext: request.context,
      errorResources: request.errorResources
    });

    const appApiResponse = await appApiClient.post<AppLoginActionDTO>(appApiRequest);

    return appApiResponse.data ?? createAppLoginActionDTO();
  }

  return {
    handle
  };
}
