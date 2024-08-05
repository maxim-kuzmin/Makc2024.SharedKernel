export interface RequestContextOptions {
  abortSignal?: AbortSignal | null,
  accessToken: string | null;
  corellationId?: string | null;
  language?: string | null;
}