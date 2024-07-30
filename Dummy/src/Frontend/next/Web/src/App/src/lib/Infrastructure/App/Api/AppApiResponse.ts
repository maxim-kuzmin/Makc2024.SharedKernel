import { AppApiError } from '@/lib';

export interface AppApiResponse {
  readonly corellationId: string;
  readonly error?: AppApiError | null;
}

export function createAppApiResponse (options?: Partial<AppApiResponse> | null): AppApiResponse {
  return {
    corellationId: options?.corellationId ?? '',
    error: options?.error
  }
}