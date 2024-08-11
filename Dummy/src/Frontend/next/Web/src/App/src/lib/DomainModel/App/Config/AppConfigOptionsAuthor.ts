export interface AppConfigOptionsAuthor {
  readonly url: string;
}

export function createAppConfigOptionsAuthor(options?: Partial<AppConfigOptionsAuthor> | null): AppConfigOptionsAuthor {
  return {
    url: options?.url ?? ''
  };
}