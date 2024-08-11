import {
  AppApiClient,
  DummyItemDeleteActionModule,
  DummyItemGetActionModule,
  DummyItemGetListActionModule,
  createDummyItemDeleteActionModule,
  createDummyItemGetActionModule,
  createDummyItemGetListActionModule
} from '@/lib';

export interface DummyItemActionsModule {
  readonly delete: DummyItemDeleteActionModule;
  readonly get: DummyItemGetActionModule;
  readonly getList: DummyItemGetListActionModule;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createDummyItemActionsModule({
  getAppApiClient
}: Options): DummyItemActionsModule {
  const _delete = createDummyItemDeleteActionModule({
    getAppApiClient
  });

  const get = createDummyItemGetActionModule({
    getAppApiClient
  });

  const getList = createDummyItemGetListActionModule({
    getAppApiClient
  });

  return {
    delete: _delete,
    get,
    getList,
  };
}