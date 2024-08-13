import {
  AppApiClient,
  DummyItemCreateActionModule,
  DummyItemDeleteActionModule,
  DummyItemGetActionModule,
  DummyItemGetListActionModule,
  DummyItemUpdateActionModule,
  createDummyItemCreateActionModule,
  createDummyItemDeleteActionModule,
  createDummyItemGetActionModule,
  createDummyItemGetListActionModule,
  createDummyItemUpdateActionModule
} from '@/lib';

export interface DummyItemActionsModule {
  readonly create: DummyItemCreateActionModule;
  readonly delete: DummyItemDeleteActionModule;
  readonly get: DummyItemGetActionModule;
  readonly getList: DummyItemGetListActionModule;
  readonly update: DummyItemUpdateActionModule;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createDummyItemActionsModule({
  getAppApiClient
}: Options): DummyItemActionsModule {
  const create = createDummyItemCreateActionModule({
    getAppApiClient
  });

  const _delete = createDummyItemDeleteActionModule({
    getAppApiClient
  });

  const get = createDummyItemGetActionModule({
    getAppApiClient
  });

  const getList = createDummyItemGetListActionModule({
    getAppApiClient
  });

  const update = createDummyItemUpdateActionModule({
    getAppApiClient
  });

  return {
    create,
    delete: _delete,
    get,
    getList,
    update,
  };
}