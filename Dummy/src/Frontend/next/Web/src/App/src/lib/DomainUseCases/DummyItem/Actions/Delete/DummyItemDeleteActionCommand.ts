export interface DummyItemDeleteActionCommand {
  readonly id: number;
}

export function createDummyItemDeleteActionCommand(options?: Partial<DummyItemDeleteActionCommand> | null): DummyItemDeleteActionCommand {
  return {
    id: options?.id ?? 0,
  };
}