namespace Makc2024.Dummy.Shared.Core.Http;

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

  public static async Task<Result<TContent>> ToResultFromJsonAsync<TContent>(
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

    var contentTask = httpResponse.Content.ReadFromJsonAsync<TContent>(cancellationToken);

    var content = await contentTask.ConfigureAwait(false);

    return content != null ? Result.Success(content) : Result.NotFound();
  }

  public static async Task<Result<TContent>> ToResultFromJsonAsync<TContent, TResponse>(
    this HttpResponseMessage? httpResponse,
    Func<TResponse, TContent> funcToGetContent,
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

    var originalContentTask = httpResponse.Content.ReadFromJsonAsync<TResponse>(cancellationToken);

    var originalContent = await originalContentTask.ConfigureAwait(false);

    return originalContent != null ? Result.Success(funcToGetContent.Invoke(originalContent)) : Result.NotFound();
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
      return Result.CriticalError(ex.Message);
    }

    return null;
  }
}
