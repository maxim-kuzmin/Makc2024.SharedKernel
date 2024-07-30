import { MiddlewareService, createMiddlewareService } from '@/lib';

export interface MiddlewareModule {
  readonly getService: () => MiddlewareService;
}

export function createMiddlewareModule(): MiddlewareModule {
  const middlewareService = createMiddlewareService();

  return {
    getService: () => middlewareService
  };
}