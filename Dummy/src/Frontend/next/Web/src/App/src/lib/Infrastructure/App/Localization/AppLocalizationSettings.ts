export interface AppLocalizationSettings {
  readonly defaultLanguage: string;
  readonly languages: string[];
}

export function createAppLocalizationSettings(options?: Partial<AppLocalizationSettings> | null): AppLocalizationSettings {
  return {
    defaultLanguage: options?.defaultLanguage ?? '',
    languages: options?.languages ?? []
  };
}