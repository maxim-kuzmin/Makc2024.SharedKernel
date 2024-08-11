import {
  AppApiClient,
  DummyItemGetActionHandler,
  createDummyItemGetActionHandler
} from '@/lib';

export interface DummyItemGetActionModule {
  readonly getHandler: () => DummyItemGetActionHandler;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createDummyItemGetActionModule({
  getAppApiClient
}: Options): DummyItemGetActionModule {
  const DummyItemGetActionHandler = createDummyItemGetActionHandler({
    appApiClient: getAppApiClient()
  });

  const getHandler = () => DummyItemGetActionHandler;

  return {
    getHandler
  };
}