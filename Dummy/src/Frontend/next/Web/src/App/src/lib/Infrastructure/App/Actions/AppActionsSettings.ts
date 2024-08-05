export interface AppActionsSettings {
  readonly rootPath: string;
}

export function createAppActionsSettings(options: Partial<AppActionsSettings> | null): AppActionsSettings {
  return {
    rootPath: options?.rootPath ?? ''
  };
}