import { AuthorizationType } from '@/lib';

export interface AuthorizationLoginActionCommand {
  readonly userName: string;
  readonly password: string;
  readonly authorizationType: AuthorizationType;
  readonly authorizationKey: string;
}

export function createAuthorizationLoginActionCommand(
  options?: Partial<AuthorizationLoginActionCommand>
): AuthorizationLoginActionCommand {
  return {
    userName: options?.userName ?? '',
    password: options?.password ?? '',
    authorizationType: options?.authorizationType ?? AuthorizationType.Undefined,
    authorizationKey: options?.authorizationKey ?? ''
  };
}