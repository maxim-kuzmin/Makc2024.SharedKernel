import { AuthorizationLoginActionRequest } from '@/lib';

export interface AuthorizationLoginActionHandler {
  readonly handle: (request: AuthorizationLoginActionRequest) => Promise<string>;
}
