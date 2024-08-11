import {
  AppApiClient,
  AppLoginActionRequest,
  AppLoginActionHandler,
  createAppApiRequestWithBody,
  AppLoginActionDTO,
  createAppLoginActionDTO,
  AppActionsSettings
} from '@/lib';

interface Options {
  readonly appActionsSettings: AppActionsSettings;
  readonly appApiClient: AppApiClient;
}

export function createAppLoginActionHandler({
  appActionsSettings,
  appApiClient 
}: Options): AppLoginActionHandler {
  async function handle(request: AppLoginActionRequest): Promise<AppLoginActionDTO> {
    const appApiRequest = createAppApiRequestWithBody({
      body: request.command,
      endpoint: `${appActionsSettings.rootPath}/login`,
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
