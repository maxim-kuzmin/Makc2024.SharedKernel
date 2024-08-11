export interface AppConfigOptionsLocalization {
  readonly defaultLanguage: string;
  readonly languages: string[];
}

export function createAppConfigOptionsLocalization(options?: Partial<AppConfigOptionsLocalization> | null): AppConfigOptionsLocalization {
  return {
    defaultLanguage: options?.defaultLanguage ?? '',
    languages: options?.languages ?? []
  };
}