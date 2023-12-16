// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2024.SharedKernel.App;

/// <summary>
/// Помощник приложения.
/// </summary>
public class AppHelper
{
    /// <summary>
    /// Создать конфигурацию.
    /// </summary>
    /// <returns>Конфигурация.</returns>
    public static IConfiguration CreateConfiguration()
    {
        return new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables()
           .Build();
    }
}
