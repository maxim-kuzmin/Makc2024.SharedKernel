import { AppApiErrorResources } from "@/lib/DomainUseCases";

interface AppApiErrorOptions {
  readonly message: string;
  readonly responseStatus: number;
}

export class AppApiError extends Error {
  responseStatus: number;

  constructor({message, responseStatus}: AppApiErrorOptions) {
    super(message);
    this.responseStatus = responseStatus;
  }
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
}: Options): AppApiError {
  let message: string;

  switch (responseStatus) {
    case 400:
      message = errorResources.getBadRequestErrorMessage();
      break;
    case 401:
      message = errorResources.getUnauthorizedErrorMessage();
      break;
    case 404:
      message = errorResources.getNotFoundErrorMessage();
      break;
    case 500:
      message = errorResources.getInternalServerErrorMessage();
      break;
    default:
      message = errorResources.getUnknownErrorMessage();
      break;
  }

  if (errorMessage) {
    message = message ? `${message}: ${errorMessage}` : errorMessage;
  }

  return new AppApiError({
    message,
    responseStatus: responseStatus ?? 0,
  });
}
