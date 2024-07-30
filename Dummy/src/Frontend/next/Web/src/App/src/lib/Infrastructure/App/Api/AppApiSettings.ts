export interface AppApiSettings {
  readonly url: string;
}

export function createAppApiSettings(options?: Partial<AppApiSettings> | null): AppApiSettings {
  return {
    url: options?.url ?? ''
  }
}