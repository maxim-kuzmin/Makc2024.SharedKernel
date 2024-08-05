import { AuthorizationType } from '@/lib';

export interface AppLoginActionCommand {
  readonly userName: string;
  readonly password: string;
  readonly authorizationType: AuthorizationType;
  readonly authorizationKey: string;
}

export function createAppLoginActionCommand(
  options?: Partial<AppLoginActionCommand> | null
): AppLoginActionCommand {
  return {
    userName: options?.userName ?? '',
    password: options?.password ?? '',
    authorizationType: options?.authorizationType ?? AuthorizationType.Undefined,
    authorizationKey: options?.authorizationKey ?? ''
  };
}