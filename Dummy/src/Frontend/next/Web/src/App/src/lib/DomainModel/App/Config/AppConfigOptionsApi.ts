export interface AppConfigOptionsApi {
  readonly url: string;
}

export function createAppConfigOptionsApi(options?: Partial<AppConfigOptionsApi>): AppConfigOptionsApi {
  return {
    url: options?.url ?? ''
  };
}