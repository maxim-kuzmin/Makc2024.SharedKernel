import {
  AppApiClient,
  DummyItemDeleteActionHandler,
  createDummyItemDeleteActionHandler
} from '@/lib';

export interface DummyItemDeleteActionModule {
  readonly getHandler: () => DummyItemDeleteActionHandler;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createDummyItemDeleteActionModule({
  getAppApiClient
}: Options): DummyItemDeleteActionModule {
  const DummyItemDeleteActionHandler = createDummyItemDeleteActionHandler({
    appApiClient: getAppApiClient()
  });

  const getHandler = () => DummyItemDeleteActionHandler;

  return {
    getHandler
  };
}