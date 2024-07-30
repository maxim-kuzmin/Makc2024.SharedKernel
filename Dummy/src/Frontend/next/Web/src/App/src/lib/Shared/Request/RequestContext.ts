import { v4 as uuidv4 } from 'uuid';
import { RequestContextOptions } from '@/lib';

export interface RequestContext {
  readonly abortSignal: AbortSignal | null;
  corellationId: string;
  language: string;
}

export function createRequestContext(options?: RequestContextOptions | null): RequestContext {
  return{
    abortSignal: options?.abortSignal ?? null,
    corellationId: options?.corellationId ?? uuidv4(),
    language: options?.language ?? ''
  }
}