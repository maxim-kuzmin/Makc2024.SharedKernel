import {
  AppApiError,
  AppApiErrorResources,
  AppApiRequest,
  AppApiRequestWithBody,
  AppApiResponse,
  AppApiResponseWithData,
  AppConfigOptionsApi,
  HttpClient,
  HttpConfig,
  HttpResponse,
  RequestContext,
  createAppApiError,
  createAppApiResponse,
  createAppApiResponseWithData
} from '@/lib';

export interface AppApiClient {
  readonly delete: (request: AppApiRequest) => Promise<AppApiResponse>;
  readonly get: <TData>(request: AppApiRequest) => Promise<AppApiResponseWithData<TData>>;
  readonly post: <TData>(request: AppApiRequestWithBody) => Promise<AppApiResponseWithData<TData>>;
  readonly put: <TData>(request: AppApiRequestWithBody) => Promise<AppApiResponseWithData<TData>>;
}

const applicationJsonContentType = 'application/json';

interface Options {
  readonly appConfigOptionsApi: AppConfigOptionsApi;
  readonly httpClient: HttpClient;
}

interface HttpConfigOptions {
  readonly contentType?: string;
  readonly query?: any;
  readonly requestContext: RequestContext;  
}

interface RequestOptions {
  readonly corellationId: string;
  readonly errorResources: AppApiErrorResources;
  readonly getResponse: () => Promise<HttpResponse>;
}

function createHttpConfig({
  contentType,
  query,
  requestContext: {
    abortSignal,
    accessToken,
    corellationId,
    language
  },  
}: HttpConfigOptions): HttpConfig {
  return {
    query,
    init: {
      headers: {
        ...(contentType && { 'Content-Type': contentType}),
        ...(language && { 'Accept-Language': language }),
        ...(corellationId && { 'X-Corellation-ID': corellationId }),
        ...(accessToken && { 'Authorization': `Bearer ${accessToken}` })
      },
      signal: abortSignal
    },
  };
};

async function request({
  getResponse,
  corellationId,
  errorResources
}: RequestOptions): Promise<AppApiResponse> {
  let appApiError: AppApiError | null = null;

  try {
    const { ok, value, status } = await getResponse();

    if (ok) {
      return createAppApiResponse({ corellationId });
    }

    appApiError = createAppApiError({
      errorMessage: value,
      errorResources,
      responseStatus: status,
    });
  } catch (error: unknown) {
    appApiError = createAppApiError({
      errorMessage: (error instanceof Error) ? error.message : '',
      errorResources,
    });
  }

  throw new Error(appApiError.message);
}

async function requestWithData<TData>({
  getResponse,
  corellationId,
  errorResources
}: RequestOptions): Promise<AppApiResponseWithData<TData>> {
  let appApiError: AppApiError | null = null;

  try {
    const { ok, value, status } = await getResponse();

    if (ok) {
      return createAppApiResponseWithData({ corellationId, data: value });
    }

    appApiError = createAppApiError({
      errorMessage: value,
      errorResources,
      responseStatus: status
    });

  } catch (error: unknown) {
    appApiError = createAppApiError({
      errorMessage: (error instanceof Error) ? error.message : '',
      errorResources
    });
  }

  throw new Error(appApiError.message);
}

export function createAppApiClient({
  appConfigOptionsApi,
  httpClient,
}: Options): AppApiClient {
  function createUrl(endpoint: string) {
    return `${appConfigOptionsApi.url}/${endpoint}`;
  }

  async function _delete({
    endpoint,
    query,
    requestContext,
    errorResources
  }: AppApiRequest): Promise<AppApiResponse> {
    const { corellationId } = requestContext;

    return await request({
      getResponse: async () => await httpClient.delete(
        createUrl(endpoint),
        createHttpConfig({
          query,
          requestContext
        })
      ),
      corellationId,
      errorResources
    });
  }

  async function get<TData>({
    endpoint,
    query,
    requestContext,
    errorResources
  }: AppApiRequest): Promise<AppApiResponseWithData<TData>> {
    const { corellationId } = requestContext;

    return await requestWithData({
      getResponse: async () => await httpClient.get(
        createUrl(endpoint),
        createHttpConfig({
          query,
          requestContext
        })
      ),
      corellationId,
      errorResources
    });
  }

  async function post<TData>({
    body,
    endpoint,
    query,
    requestContext,
    errorResources
  }: AppApiRequestWithBody): Promise<AppApiResponseWithData<TData>> {
    const { corellationId } = requestContext;

    return await requestWithData({
      getResponse: async () => await httpClient.post(
        createUrl(endpoint),
        body,
        createHttpConfig({
          contentType: applicationJsonContentType,
          query,
          requestContext
        })
      ),
      corellationId,
      errorResources
    });
  }

  async function put<TData>({
    body,
    endpoint,
    query,
    requestContext,
    errorResources
  }: AppApiRequestWithBody): Promise<AppApiResponseWithData<TData>> {
    const { corellationId } = requestContext;

    return await requestWithData({
      getResponse: async () => await httpClient.put(
        createUrl(endpoint),
        body,
        createHttpConfig({
          contentType: applicationJsonContentType,
          query,
          requestContext
        })
      ),
      corellationId,
      errorResources
    });
  }

  return {
    delete: _delete,
    get,
    post,
    put
  };
}