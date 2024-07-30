import { AppApiErrorResources, RequestContext, createAppApiErrorResources, createRequestContext } from '@/lib';

export interface AppApiRequest {  
  readonly endpoint: string;
  readonly query?: any;
  readonly requestContext: RequestContext;
  readonly errorResources: AppApiErrorResources;
}

export function createAppApiRequest(options?: Partial<AppApiRequest> | null): AppApiRequest {
  return {    
    endpoint: options?.endpoint ?? '',
    query: options?.query,
    requestContext: options?.requestContext ?? createRequestContext(),
    errorResources: options?.errorResources ?? createAppApiErrorResources()
  };
}