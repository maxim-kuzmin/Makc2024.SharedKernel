using Ardalis.Result;

namespace Makc2024.Dummy.Shared.Http;

public static class HttpExtensions
{
  public static Result ToResult(this HttpResponseMessage? httpResponse)
  {
    if (httpResponse == null)
    {
      return Result.CriticalError();
    }

    var result = httpResponse.ToUnsuccessfulResult();

    return result ?? Result.Success();
  }

  public async static Task<Result<T>> ToResultFromJsonAsync<T>(
    this HttpResponseMessage? httpResponse,
    CancellationToken cancellationToken)
  {
    if (httpResponse == null)
    {
      return Result.CriticalError();
    }

    var result = httpResponse.ToUnsuccessfulResult();

    if (result != null)
    {
      return result;
    }

    var data = await httpResponse.Content.ReadFromJsonAsync<T>(cancellationToken);

    return data != null ? Result.Success(data) : Result.NotFound();
  }

  private static Result? ToUnsuccessfulResult(this HttpResponseMessage httpResponse)
  {
    switch (httpResponse.StatusCode)
    {
      case HttpStatusCode.Conflict:
        return Result.Conflict();
      case HttpStatusCode.Forbidden:
        return Result.Forbidden();
      case HttpStatusCode.NoContent:
        return Result.NoContent();
      case HttpStatusCode.NotFound:
        return Result.NotFound();
      case HttpStatusCode.ServiceUnavailable:
        return Result.Unavailable();
      case HttpStatusCode.Unauthorized:
        return Result.Unauthorized();
    }

    try
    {
      httpResponse.EnsureSuccessStatusCode();
    }
    catch (HttpRequestException ex)
    {
      return ex.StatusCode switch
      {        
        HttpStatusCode.BadRequest => Result.Invalid(new ValidationError(ex.Message)),
        HttpStatusCode.UnprocessableEntity => Result.Error(ex.Message),
        _ => Result.CriticalError(ex.Message),
      };
    }
    catch (Exception ex)
    {
      Result.CriticalError(ex.Message);
    }

    return null;
  }
}
