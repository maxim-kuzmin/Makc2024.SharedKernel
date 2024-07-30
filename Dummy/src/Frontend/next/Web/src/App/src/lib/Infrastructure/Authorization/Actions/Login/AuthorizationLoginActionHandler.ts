import {
  AppApiClient,
  AuthorizationLoginActionRequest,
  AuthorizationLoginActionHandler,
  createAppApiRequestWithBody
} from '@/lib';

interface Options {
  readonly appApiClient: AppApiClient;
}

const rootPath = 'authorization';

export function createAuthorizationLoginActionHandler({
  appApiClient 
}: Options): AuthorizationLoginActionHandler {
  async function handle(request: AuthorizationLoginActionRequest): Promise<string> {
    const appApiRequest = createAppApiRequestWithBody({
      body: request.command,
      endpoint: `${rootPath}/login`,
      requestContext: request.context,
      errorResources: request.errorResources
    });

    const appApiResponse = await appApiClient.post<string>(appApiRequest);

    return appApiResponse.data ?? '';
  }

  return {
    handle
  };
}
