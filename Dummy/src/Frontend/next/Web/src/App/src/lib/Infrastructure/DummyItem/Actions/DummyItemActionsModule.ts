import {
  AppApiClient,
  DummyItemGetListActionModule,
  createDummyItemGetListActionModule
} from '@/lib';

export interface DummyItemActionsModule {
  readonly getList: DummyItemGetListActionModule;  
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createDummyItemActionsModule({
  getAppApiClient
}: Options): DummyItemActionsModule {
  const getList = createDummyItemGetListActionModule({
    getAppApiClient
  });

  return {
    getList,
  };
}