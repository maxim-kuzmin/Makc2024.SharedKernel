export interface AppLoginActionCommand {
  readonly userName: string;
  readonly password: string;
}

export function createAppLoginActionCommand(
  options?: Partial<AppLoginActionCommand> | null
): AppLoginActionCommand {
  return {
    userName: options?.userName ?? '',
    password: options?.password ?? '',
  };
}