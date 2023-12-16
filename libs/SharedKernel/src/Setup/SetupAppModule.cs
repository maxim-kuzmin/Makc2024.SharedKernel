// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2024.SharedKernel.Setup;

/// <summary>
/// Модуль настройки приложения.
/// </summary>
/// <param name="_configurationSection">Раздел конфигурации.</param>
public class SetupAppModule(IConfigurationSection _configurationSection) : AppModule
{
    #region Public methods

    /// <inheritdoc/>
    public sealed override void ConfigureServices(IServiceCollection services)
    {
        services.Configure<SetupOptions>(_configurationSection);

        services.AddSingleton<IAppResource>(x => new AppResource(
            x.GetRequiredService<IStringLocalizer<AppResource>>()));
    }

    /// <inheritdoc/>
    public sealed override IEnumerable<Type> GetExports()
    {
        return new[]
            {
                typeof(IAppResource),
                typeof(SetupOptions),
            };
    }

    #endregion Public methods

    #region Protected methods

    /// <inheritdoc/>
    protected sealed override IEnumerable<Type> GetImports()
    {
        return new[]
            {
                typeof(ILogger),
                typeof(IStringLocalizer),
            };
    }

    #endregion Protected methods
}
