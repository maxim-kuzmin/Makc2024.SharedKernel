export interface AppConfigOptionsJira {
  readonly url: string;
}

export function createAppConfigOptionsJira(options?: Partial<AppConfigOptionsJira>): AppConfigOptionsJira {
  return {
    url: options?.url ?? ''
  };
}