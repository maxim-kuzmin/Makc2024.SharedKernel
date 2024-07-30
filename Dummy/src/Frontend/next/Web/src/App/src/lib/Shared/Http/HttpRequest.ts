import { type HttpConfig } from '@/lib';

export interface HttpRequest {
  body?: any;
  config?: HttpConfig;
  url: string;
}
