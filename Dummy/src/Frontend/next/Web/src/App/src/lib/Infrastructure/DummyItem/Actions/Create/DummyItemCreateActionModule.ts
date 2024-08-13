import {
  AppApiClient,
  DummyItemCreateActionHandler,
  createDummyItemCreateActionHandler
} from '@/lib';

export interface DummyItemCreateActionModule {
  readonly getHandler: () => DummyItemCreateActionHandler;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createDummyItemCreateActionModule({
  getAppApiClient
}: Options): DummyItemCreateActionModule {
  const DummyItemCreateActionHandler = createDummyItemCreateActionHandler({
    appApiClient: getAppApiClient()
  });

  const getHandler = () => DummyItemCreateActionHandler;

  return {
    getHandler
  };
}