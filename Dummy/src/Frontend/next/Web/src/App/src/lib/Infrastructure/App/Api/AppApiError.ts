import { AppApiErrorResources } from "@/lib/DomainUseCases";

export interface AppApiError {
  readonly message: string;
  readonly responseStatus: number;
}

interface Options extends ErrorOptions {
  readonly errorMessage?: string;
  readonly errorResources: AppApiErrorResources;
  readonly responseStatus?: number;
}

export function createAppApiError({
  errorMessage,
  errorResources,
  responseStatus
}: Options) {
  let message: string;

  switch (responseStatus) {
    case 400:
      message = errorResources.badRequestErrorMessage
      break;
    case 404:
      message = errorResources.notFoundErrorMessage
      break;
    case 500:
      message = errorResources.internalServerErrorMessage
      break;
    default:
      message = errorResources.unknownErrorMessage
      break;
  }

  if (errorMessage) {
    message = `${message}: ${errorMessage}`;
  }

  return {
    message,
    responseStatus: responseStatus ?? 0,
  };
}
