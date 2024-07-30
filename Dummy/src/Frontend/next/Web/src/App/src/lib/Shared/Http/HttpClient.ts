import queryString from 'query-string';
import { type HttpConfig, type HttpResponse } from '@/lib';

export interface HttpClient {
  readonly delete: (url: string, config?: HttpConfig) => Promise<HttpResponse>;
  readonly get: (url: string, config?: HttpConfig) => Promise<HttpResponse>;
  readonly post: (url: string, body: any, config?: HttpConfig) => Promise<HttpResponse>;
  readonly put: (url: string, body: any, config?: HttpConfig) => Promise<HttpResponse>;
}

function createRequestConfigValue (method: string, config?: HttpConfig, body?: any) {
  const result: HttpConfig = { ...config };

  result.init = { method, ...result.init };

  result.init.body = JSON.stringify(body);

  return result;
}

async function request (url: string, config: HttpConfig): Promise<HttpResponse> {
  const { init, query } = config;

  const input = query ? queryString.stringifyUrl({ url, query }) : url;

  const response = await fetch(input, init);

  const value = await response.json();

  const { headers, ok, status, statusText } = response;

  return {
    headers,
    ok,
    status,
    statusText,
    value,
    url: response.url,
  };
}

async function _delete (url: string, config?: HttpConfig) {
  const result = await request(url, createRequestConfigValue('DELETE', config));

  return result;
}

async function get (url: string, config?: HttpConfig) {
  const result = await request(url, createRequestConfigValue('GET', config));

  return result;
}

async function post (url: string, body: any, config?: HttpConfig) {
  const result = await request(url, createRequestConfigValue('POST', config, body));

  return result;
}

async function put (url: string, body: any, config?: HttpConfig) {
  const result = await request(url, createRequestConfigValue('PUT', config, body));

  return result;
}

export function createHttpClient (): HttpClient {
  return {
    delete: _delete,
    get,
    post,
    put
  };
}
