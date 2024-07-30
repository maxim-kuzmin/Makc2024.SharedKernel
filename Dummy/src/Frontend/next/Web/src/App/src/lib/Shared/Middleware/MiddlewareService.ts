import { NextMiddleware, NextResponse } from 'next/server';
import { MiddlewareFactory } from '@/lib';

export interface MiddlewareService {
  readonly stackMiddlewares: (functions: MiddlewareFactory[], index: number) => NextMiddleware;
}

export function createMiddlewareService(): MiddlewareService {
  function stackMiddlewares(
    functions: MiddlewareFactory[] = [],
    index = 0
  ): NextMiddleware {
    const current = functions[index];
    if (current) {
      const next = stackMiddlewares(functions, index + 1);
      return current(next);
    }
    return () => NextResponse.next();
  }

  return {
    stackMiddlewares
  };
}