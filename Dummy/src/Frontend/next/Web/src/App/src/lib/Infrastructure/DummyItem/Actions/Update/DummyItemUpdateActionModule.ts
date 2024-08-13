import {
  AppApiClient,
  DummyItemUpdateActionHandler,
  createDummyItemUpdateActionHandler
} from '@/lib';

export interface DummyItemUpdateActionModule {
  readonly getHandler: () => DummyItemUpdateActionHandler;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createDummyItemUpdateActionModule({
  getAppApiClient
}: Options): DummyItemUpdateActionModule {
  const DummyItemUpdateActionHandler = createDummyItemUpdateActionHandler({
    appApiClient: getAppApiClient()
  });

  const getHandler = () => DummyItemUpdateActionHandler;

  return {
    getHandler
  };
}