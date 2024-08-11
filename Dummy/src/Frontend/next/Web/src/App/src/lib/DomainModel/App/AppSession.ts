export interface AppSession {
  readonly accessToken: string | null;
  readonly userName: string | null;
}

export function createAppSession(options?: Partial<AppSession> | null): AppSession {
  return {
    accessToken: options?.accessToken ?? null,
    userName: options?.userName ?? null,
  };
}