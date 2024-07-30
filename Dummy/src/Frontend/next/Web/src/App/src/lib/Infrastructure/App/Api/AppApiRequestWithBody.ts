import { type AppApiRequest, createAppApiRequest } from '@/lib';

export interface AppApiRequestWithBody extends AppApiRequest {
  body: any;
}

export function createAppApiRequestWithBody(options?: Partial<AppApiRequestWithBody> | null): AppApiRequestWithBody {
  const base = createAppApiRequest(options);

  return {
    ...base,
    body: options?.body
  };
}
