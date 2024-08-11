export interface AppConfigOptionsJira {
  readonly url: string;
}

export function createAppConfigOptionsJira(options?: Partial<AppConfigOptionsJira> | null): AppConfigOptionsJira {
  return {
    url: options?.url ?? ''
  };
}