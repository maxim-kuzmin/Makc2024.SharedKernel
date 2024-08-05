import { AppLoginActionDTO, AppLoginActionRequest } from '@/lib';

export interface AppLoginActionHandler {
  readonly handle: (request: AppLoginActionRequest) => Promise<AppLoginActionDTO>;
}
