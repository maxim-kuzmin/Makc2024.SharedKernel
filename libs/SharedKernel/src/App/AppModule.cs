// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2024.SharedKernel.App;

/// <summary>
/// Модуль приложения.
/// </summary>
public abstract class AppModule
{
    #region Public methods

    /// <summary>
    /// Настроить сервисы.
    /// </summary>
    /// <param name="services">Сервисы.</param>
    public abstract void ConfigureServices(IServiceCollection services);

    /// <summary>
    /// Получить зависимости.
    /// </summary>
    /// <returns>Зависимости.</returns>
    public virtual IEnumerable<AppModule> GetDependencies()
    {
        return Enumerable.Empty<AppModule>();
    }

    /// <summary>
    /// Получить экспортированные типы.
    /// </summary>
    /// <returns>Экспортированные типы.</returns>
    public virtual IEnumerable<Type> GetExports()
    {
        return Enumerable.Empty<Type>();
    }

    /// <summary>
    /// Получить не импортированные типы.
    /// </summary>
    /// <param name="allExports">Все экспортированные типы.</param>
    /// <returns>Не импортированные типы.</returns>
    public IEnumerable<Type> GetNotImportedtTypes(HashSet<Type> allExports)
    {
        return GetImports().Where(x => !allExports.Contains(x));
    }

    #endregion Public methods

    #region Protected methods

    /// <summary>
    /// Получить импортированные типы.
    /// </summary>
    /// <returns>Импортированные типы.</returns>
    protected virtual IEnumerable<Type> GetImports()
    {
        return Enumerable.Empty<Type>();
    }

    #endregion Protected methods
}
