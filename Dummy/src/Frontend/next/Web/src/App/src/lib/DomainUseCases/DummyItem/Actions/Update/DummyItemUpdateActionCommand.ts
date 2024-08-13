export interface DummyItemUpdateActionCommand {
  readonly id: number;
  readonly name: string;
}

export function createDummyItemUpdateActionCommand(options?: Partial<DummyItemUpdateActionCommand> | null): DummyItemUpdateActionCommand {
  return {
    id: options?.id ?? 0,
    name: options?.name ?? '',
  };
}