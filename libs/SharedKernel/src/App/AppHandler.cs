// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2024.SharedKernel.App;

/// <summary>
/// Обработчик приложения.
/// </summary>
/// <param name="_logger">Регистратор.</param>
public abstract class AppHandler(ILoggerOfNLog _logger) : IDisposable
{
    #region Fields

    private bool _disposedValue;

    #endregion Fields

    #region Public methods

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);

        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Обработать ошибку.
    /// </summary>
    /// <param name="exception">Исключение.</param>
    public void HandleError(Exception exception)
    {
        _logger.Error(exception, nameof(HandleError));
    }

    /// <summary>
    /// Обработать начало.
    /// </summary>
    /// <param name="appEnvironment">Окружение приложения.</param>
    public void HandleStart(IAppEnvironment appEnvironment)
    {
        CultureInfo.CurrentCulture =
            CultureInfo.CurrentUICulture =
                CultureInfo.GetCultureInfo(appEnvironment.DefaultCulture);

        _logger.Debug($$"""{{nameof(HandleStart)}}: {MachineName}""", Environment.MachineName);
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                LogManagerOfNLog.Shutdown();
            }

            _disposedValue = true;
        }
    }

    #endregion Protected methods
}
