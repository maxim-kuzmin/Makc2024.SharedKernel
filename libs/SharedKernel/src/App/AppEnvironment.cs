// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2024.SharedKernel.App;

/// <summary>
/// Окружение приложения.
/// </summary>
public class AppEnvironment : IAppEnvironment
{
    #region Properties

    /// <inheritdoc/>
    public string DefaultCulture { get; }

    /// <inheritdoc/>
    public bool IsRetryEnabledByOrchestrator { get; }

    /// <inheritdoc/>
    public string[] SupportedCultures { get; }

    #endregion Properties

    #region Constructors

    /// <summary>
    /// Конструктор.
    /// </summary>
    public AppEnvironment()
    {
        SupportedCultures = ["ru", "en"];

        DefaultCulture = GetDefaultCulture(SupportedCultures[0]);

        IsRetryEnabledByOrchestrator = GetIsRetryEnabledByOrchestrator();
    }

    #endregion Constructors

    #region Private methods

    private string GetDefaultCulture(string defaultValue)
    {
        string? value = Environment.GetEnvironmentVariable("App__Language");

        string result = !string.IsNullOrWhiteSpace(value) && SupportedCultures.Contains(value)
            ? value
            : defaultValue;

        return result;
    }

    private static bool GetIsRetryEnabledByOrchestrator()
    {
        string? value = Environment.GetEnvironmentVariable("App__IsRetryEnabledByOrchestrator");

        return bool.TryParse(value, out bool result) && result;
    }

    #endregion Private methods
}
