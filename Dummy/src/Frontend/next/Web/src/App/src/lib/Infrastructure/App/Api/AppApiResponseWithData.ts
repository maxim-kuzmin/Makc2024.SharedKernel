import { type AppApiResponse, createAppApiResponse } from '@/lib';

export interface AppApiResponseWithData<TData> extends AppApiResponse {
  readonly data?: TData | null;
}

export function createAppApiResponseWithData<TData> (
  options?: AppApiResponseWithData<TData> | null
): AppApiResponseWithData<TData> {
  const base = createAppApiResponse(options);

  return {
    ...base,
    data: options?.data
  };
}