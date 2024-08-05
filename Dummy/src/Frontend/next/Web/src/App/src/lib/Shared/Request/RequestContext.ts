import { v4 as uuidv4 } from 'uuid';
import { RequestContextOptions } from '@/lib';

export interface RequestContext {
  readonly abortSignal: AbortSignal | null;
  readonly accessToken: string;
  corellationId: string;
  language: string;
}

export function createRequestContext(options?: Partial<RequestContextOptions> | null): RequestContext {
  return{
    abortSignal: options?.abortSignal ?? null,
    accessToken: options?.accessToken ?? '',
    corellationId: options?.corellationId ?? uuidv4(),
    language: options?.language ?? ''
  }
}