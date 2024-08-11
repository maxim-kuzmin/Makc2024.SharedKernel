export interface AppConfigOptionsApi {
  readonly url: string;
}

export function createAppConfigOptionsApi(options?: Partial<AppConfigOptionsApi> | null): AppConfigOptionsApi {
  return {
    url: options?.url ?? ''
  };
}