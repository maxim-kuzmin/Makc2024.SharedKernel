export interface AppConfigOptionsAuthor {
  readonly url: string;
}

export function createAppConfigOptionsAuthor(options?: Partial<AppConfigOptionsAuthor>): AppConfigOptionsAuthor {
  return {
    url: options?.url ?? ''
  };
}