import { AppApiClient, createDummyItemActionsModule, DummyItemActionsModule } from '@/lib';

export interface DummyItemModule {
  readonly actions: DummyItemActionsModule;
}

interface Options {
  readonly getAppApiClient: () => AppApiClient;
}

export function createDummyItemModule(options: Options): DummyItemModule {
  const actions = createDummyItemActionsModule({
    getAppApiClient: options.getAppApiClient
  });
  
  return {
    actions
  };
}