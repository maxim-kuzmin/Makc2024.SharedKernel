export interface AppLoginActionDTO {
  userName: string;
  accessToken: string;
}

export function createAppLoginActionDTO(options?: Partial<AppLoginActionDTO> | null): AppLoginActionDTO {
  return {
    userName: options?.userName ?? '',
    accessToken: options?.accessToken ?? ''
  };
}