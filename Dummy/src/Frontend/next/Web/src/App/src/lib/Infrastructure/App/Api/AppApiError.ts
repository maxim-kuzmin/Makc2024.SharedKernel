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
      message = errorResources.getBadRequestErrorMessage()
      break;
    case 404:
      message = errorResources.getNotFoundErrorMessage()
      break;
    case 500:
      message = errorResources.getInternalServerErrorMessage()
      break;
    default:
      message = errorResources.getUnknownErrorMessage()
      break;
  }

  if (errorMessage) {
    message = message ? `${message}: ${errorMessage}` : errorMessage;
  }

  return {
    message,
    responseStatus: responseStatus ?? 0,
  };
}
