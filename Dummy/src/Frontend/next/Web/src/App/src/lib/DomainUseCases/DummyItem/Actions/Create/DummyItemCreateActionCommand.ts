export interface DummyItemCreateActionCommand {
  readonly name: string;
}

export function createDummyItemCreateActionCommand(options?: Partial<DummyItemCreateActionCommand> | null): DummyItemCreateActionCommand {
  return {
    name: options?.name ?? '',
  };
}