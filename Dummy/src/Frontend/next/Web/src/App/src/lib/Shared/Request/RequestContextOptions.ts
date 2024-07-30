export interface RequestContextOptions {
  abortSignal?: AbortSignal | null,
  corellationId?: string | null;
  language?: string | null;
}