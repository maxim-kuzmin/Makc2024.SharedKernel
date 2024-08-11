import {
  AppApiClient,
  DummyItemGetListActionHandler,
  createDummyItemGetListActionHandler
} from '@/lib';

export interface DummyItemGetListActionModule {
  readonly getHandler: () => DummyItemGetListActionHandler;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createDummyItemGetListActionModule({
  getAppApiClient
}: Options): DummyItemGetListActionModule {
  const DummyItemGetListActionHandler = createDummyItemGetListActionHandler({
    appApiClient: getAppApiClient()
  });

  const getHandler = () => DummyItemGetListActionHandler;

  return {
    getHandler
  };
}