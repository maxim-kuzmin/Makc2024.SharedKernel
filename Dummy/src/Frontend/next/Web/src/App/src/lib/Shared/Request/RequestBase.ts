import {
  RequestContext,
  RequestContextOptions,
  createRequestContext
} from '@/lib';

export interface RequestBase {
  context: RequestContext;
}

export function createRequestBase(options?: RequestContextOptions | null): RequestBase {
  const context = createRequestContext(options);

  return {
    context
  };
}