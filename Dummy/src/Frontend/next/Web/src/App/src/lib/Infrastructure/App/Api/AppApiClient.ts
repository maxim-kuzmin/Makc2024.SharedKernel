import {
  AppApiError,
  AppApiErrorResources,
  AppApiRequest,
  AppApiRequestWithBody,
  AppApiResponse,
  AppApiResponseWithData,
  AppApiSettings,
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

interface Options {
  readonly appApiSettings: AppApiSettings;
  readonly httpClient: HttpClient;  
}

interface HttpConfigOptions {
  readonly query?: any;
  readonly requestContext: RequestContext;
}

interface RequestOptions {
  readonly corellationId: string;
  readonly errorResources: AppApiErrorResources;
  readonly getResponse: () => Promise<HttpResponse>;  
}

function createHttpConfig({
  query,
  requestContext: {
    abortSignal,
    corellationId,
    language
  }
}: HttpConfigOptions): HttpConfig {
  return {
    query,
    init: {
      headers: {
        'Accept-Language': language,
        'Content-Type': 'application/json',
        'X-Corellation-ID': corellationId
      },
      signal: abortSignal
    },
  }
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

  return await Promise.reject(
    createAppApiResponse({
      corellationId,
      error: appApiError
    })
  );
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

  return await Promise.reject(
    createAppApiResponse({
      corellationId,
      error: appApiError
    })
  );
}

export function createAppApiClient({
  httpClient,
  appApiSettings
}: Options): AppApiClient {  
  function createUrl(endpoint: string) {
    return `${appApiSettings.url}/${endpoint}`;
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