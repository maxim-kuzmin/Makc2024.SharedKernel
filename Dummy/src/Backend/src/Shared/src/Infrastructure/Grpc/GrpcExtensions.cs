namespace Makc2024.Dummy.Shared.Infrastructure.Grpc;

public static class GrpcExtensions
{
  public static Metadata AddAuthorizationHeader(this Metadata headers, AppSession appSession)
  {
    string? accessToken = appSession.AccessToken;

    if (!string.IsNullOrWhiteSpace(accessToken))
    {
      headers.Add("Authorization", $"Bearer {accessToken}");
    }

    return headers;
  }

  public static void ThrowRpcExceptionIfNotSuccess(this Result result)
  {
    if (!result.IsSuccess)
    {
      ((IResult)result).ThrowRpcExceptionIfNotSuccess();
    }
  }

  public static void ThrowRpcExceptionIfNotSuccess<T>(this Result<T> result)
  {
    if (!result.IsSuccess)
    {
      ((IResult)result).ThrowRpcExceptionIfNotSuccess();
    }
  }

  public static StatusCode? ToGrpcStatusCode(this HttpStatusCode httpStatusCode)
  {
    switch (httpStatusCode)
    {
      case HttpStatusCode.Continue:
      case HttpStatusCode.SwitchingProtocols:
      case HttpStatusCode.Processing:
      case HttpStatusCode.EarlyHints:
      case HttpStatusCode.OK:
      case HttpStatusCode.Created:
      case HttpStatusCode.Accepted:
      case HttpStatusCode.NonAuthoritativeInformation:
      case HttpStatusCode.NoContent:
      case HttpStatusCode.ResetContent:
      case HttpStatusCode.PartialContent:
      case HttpStatusCode.MultiStatus:
      case HttpStatusCode.AlreadyReported:
      case HttpStatusCode.IMUsed:
        return StatusCode.OK;
      case HttpStatusCode.Ambiguous:
      case HttpStatusCode.Moved:
      case HttpStatusCode.Found:
      case HttpStatusCode.RedirectMethod:
      case HttpStatusCode.NotModified:
      case HttpStatusCode.UseProxy:
      case HttpStatusCode.Unused:
      case HttpStatusCode.RedirectKeepVerb:
      case HttpStatusCode.PermanentRedirect:
        break;
      case HttpStatusCode.BadRequest:
        return StatusCode.InvalidArgument;
      case HttpStatusCode.Unauthorized:
        return StatusCode.Unauthenticated;
      case HttpStatusCode.PaymentRequired:
        break;
      case HttpStatusCode.Forbidden:
        return StatusCode.PermissionDenied;
      case HttpStatusCode.NotFound:
        return StatusCode.NotFound;
      case HttpStatusCode.MethodNotAllowed:
      case HttpStatusCode.NotAcceptable:
      case HttpStatusCode.ProxyAuthenticationRequired:
        break;
      case HttpStatusCode.RequestTimeout: // Должно быть 499 Client Closed Request, но такаго варианта нет в перечислении HttpStatusCode
        return StatusCode.Cancelled;
      case HttpStatusCode.Conflict:
        return StatusCode.Aborted;
      case HttpStatusCode.Gone:
      case HttpStatusCode.LengthRequired:
      case HttpStatusCode.PreconditionFailed:
      case HttpStatusCode.RequestEntityTooLarge:
      case HttpStatusCode.RequestUriTooLong:
      case HttpStatusCode.UnsupportedMediaType:
      case HttpStatusCode.RequestedRangeNotSatisfiable:
      case HttpStatusCode.ExpectationFailed:
      case HttpStatusCode.MisdirectedRequest:
      case HttpStatusCode.UnprocessableEntity:
      case HttpStatusCode.Locked:
      case HttpStatusCode.FailedDependency:
      case HttpStatusCode.UpgradeRequired:
      case HttpStatusCode.PreconditionRequired:
        break;
      case HttpStatusCode.TooManyRequests:
        return StatusCode.ResourceExhausted;
      case HttpStatusCode.RequestHeaderFieldsTooLarge:
      case HttpStatusCode.UnavailableForLegalReasons:
        break;
      case HttpStatusCode.InternalServerError:
        return StatusCode.Unknown;
      case HttpStatusCode.NotImplemented:
        return StatusCode.Unimplemented;
      case HttpStatusCode.BadGateway:
        break;
      case HttpStatusCode.ServiceUnavailable:
        return StatusCode.Unavailable;
      case HttpStatusCode.GatewayTimeout:
        return StatusCode.DeadlineExceeded;
      case HttpStatusCode.HttpVersionNotSupported:
      case HttpStatusCode.VariantAlsoNegotiates:
      case HttpStatusCode.InsufficientStorage:
      case HttpStatusCode.LoopDetected:
      case HttpStatusCode.NotExtended:
      case HttpStatusCode.NetworkAuthenticationRequired:
        break;
    }

    return null;
  }

  public static HttpStatusCode? ToHttpStatusCode(this StatusCode grpcStatusCode)
  {
    switch (grpcStatusCode)
    {
      case StatusCode.OK:
        return HttpStatusCode.OK;
      case StatusCode.Cancelled:
        return HttpStatusCode.RequestTimeout; // Должно быть 499 Client Closed Request, но такаго варианта нет в перечислении HttpStatusCode
      case StatusCode.Unknown:
        return HttpStatusCode.InternalServerError;
      case StatusCode.InvalidArgument:
        return HttpStatusCode.BadRequest;
      case StatusCode.DeadlineExceeded:
        return HttpStatusCode.GatewayTimeout;
      case StatusCode.NotFound:
        return HttpStatusCode.NotFound;
      case StatusCode.AlreadyExists:
        return HttpStatusCode.Conflict;
      case StatusCode.PermissionDenied:
        return HttpStatusCode.Forbidden;
      case StatusCode.Unauthenticated:
        return HttpStatusCode.Unauthorized;
      case StatusCode.ResourceExhausted:
        return HttpStatusCode.TooManyRequests;
      case StatusCode.FailedPrecondition:
        return HttpStatusCode.BadRequest;
      case StatusCode.Aborted:
        return HttpStatusCode.Conflict;
      case StatusCode.OutOfRange:
        return HttpStatusCode.BadRequest;
      case StatusCode.Unimplemented:
        return HttpStatusCode.NotImplemented;
      case StatusCode.Internal:
        return HttpStatusCode.InternalServerError;
      case StatusCode.Unavailable:
        return HttpStatusCode.ServiceUnavailable;
      case StatusCode.DataLoss:
        return HttpStatusCode.InternalServerError;
    }

    return null;
  }

  public static Result ToUnsuccessfulResult(this RpcException ex)
  {
      return ex.StatusCode switch
      {
        StatusCode.Aborted or StatusCode.AlreadyExists => Result.Conflict(),
        StatusCode.PermissionDenied => Result.Forbidden(),
        StatusCode.NotFound => Result.NotFound(),
        StatusCode.DataLoss => Result.Unavailable(),
        StatusCode.Unauthenticated => Result.Unauthorized(),
        StatusCode.InvalidArgument or StatusCode.OutOfRange or StatusCode.FailedPrecondition => Result.Invalid(new ValidationError(ex.Message)),
        StatusCode.Unknown => Result.Error(ex.Message),
        _ => Result.CriticalError(ex.Message),
      };
  }

  private static void ThrowRpcExceptionIfNotSuccess(this IResult result)
  {
    StatusCode statusCode;
    string message;
    Exception? exception = null;

    switch (result.Status)
    {
      case ResultStatus.Error:
        statusCode = StatusCode.InvalidArgument;
        message = "Something went wrong.";
        break;
      case ResultStatus.Forbidden:
        statusCode = StatusCode.PermissionDenied;
        message = "Forbidden.";
        break;
      case ResultStatus.Unauthorized:
        statusCode = StatusCode.Unauthenticated;
        message = "Unauthorized.";
        break;
      case ResultStatus.Invalid:
        statusCode = StatusCode.InvalidArgument;
        message = "Bad request.";
        break;
      case ResultStatus.NotFound:
        statusCode = StatusCode.NotFound;
        message = "Resource not found.";
        break;
      case ResultStatus.Conflict:
        statusCode = StatusCode.Aborted;
        message = "There was a conflict.";
        break;
      case ResultStatus.CriticalError:
        statusCode = StatusCode.Unknown;
        message = "Something went wrong.";
        break;
      case ResultStatus.Unavailable:
        statusCode = StatusCode.Unavailable;
        message = "Service unavailable.";
        break;
      case ResultStatus.Ok:
      case ResultStatus.Created:
      case ResultStatus.NoContent:
        return;
      default:
        statusCode = StatusCode.Unknown;
        message = "Something went wrong.";
        exception = new NotSupportedException($"Result {result.Status} conversion is not supported.");
        break;
    }

    throw result.ToRpcException(statusCode, message, exception);
  }

  private static RpcException ToRpcException(
    this IResult result,
    StatusCode statusCode,
    string message,
    Exception? debugException)
  {
    string detail = string.Empty;

    if (result.ValidationErrors.Any())
    {
      var stringBuilder = new StringBuilder("Validation error(s) occurred:");

      foreach (var error in result.ValidationErrors)
      {
        stringBuilder.Append("* ").Append(error.ToGrpcStatusDetail()).AppendLine();
      }

      detail = stringBuilder.ToString();
    }
    else if (result.Errors.Any())
    {
      var stringBuilder = new StringBuilder("Next error(s) occurred:");

      foreach (string error in result.Errors)
      {
        stringBuilder.Append("* ").Append(error).AppendLine();
      }

      detail = stringBuilder.ToString();
    }

    return new RpcException(new Status(statusCode, detail, debugException), message);
  }

  private static string ToGrpcStatusDetail(this ValidationError validationError)
  {
    var parts = new List<string>(4)
    {
      $"Severity: {validationError.Severity}"
    };

    if (!string.IsNullOrWhiteSpace(validationError.Identifier))
    {
      parts.Add($"Identifier: {validationError.Identifier}");
    }

    if (!string.IsNullOrWhiteSpace(validationError.ErrorCode))
    { 
      parts.Add($"ErrorCode: {validationError.ErrorCode}");
    }

    if (!string.IsNullOrWhiteSpace(validationError.ErrorMessage))
    {
      parts.Add($"ErrorMessage: {validationError.ErrorMessage}");
    }

    return string.Join(", ", parts);
  }
}
