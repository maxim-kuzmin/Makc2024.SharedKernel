// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2024.SharedKernel.App;

/// <summary>
/// Интерфейс окружения приложения.
/// </summary>
public interface IAppEnvironment
{
    #region Properties

    /// <summary>
    /// Культура по умолчанию.
    /// Переменная окружения: "App__Language".
    /// Значение по умолчанию: "ru".
    /// </summary>
    string DefaultCulture { get; }

    /// <summary>
    /// Признак включения повторной попытки оркестратором.
    /// Переменная окружения: "App__IsRetryEnabledByOrchestrator".
    /// Значение по умолчанию: "false".
    /// </summary>
    bool IsRetryEnabledByOrchestrator { get; }

    /// <summary>
    /// Поддерживаемые культуры.
    /// Значения: "ru", "en".
    /// </summary>
    string[] SupportedCultures { get; }

    #endregion Properties
}
