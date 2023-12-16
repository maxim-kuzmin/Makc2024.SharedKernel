// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2024.SharedKernel.App;

/// <summary>
/// Расширения приложения.
/// </summary>
public static class AppExtensions
{
    #region Public methods

    /// <summary>
    /// Добавить модули приложения.
    /// </summary>
    /// <param name="services">Сервисы.</param>
    /// <param name="modules">Модули.</param>
    public static void AddAppModules(this IServiceCollection services, IEnumerable<AppModule> modules)
    {
        var exports = Enumerable.Empty<Type>();

        foreach (var module in modules)
        {
            exports = exports.Union(module.GetExports());

            var dependencies = module.GetDependencies();

            foreach (var dependency in dependencies)
            {
                exports = exports.Union(dependency.GetExports());
            }
        }

        var allExports = exports.ToHashSet();

        var notImportedTypes = Enumerable.Empty<Type>();

        foreach (var module in modules)
        {
            var moduleNotImportedtTypes = module.GetNotImportedtTypes(allExports);

            if (moduleNotImportedtTypes.Any())
            {
                notImportedTypes = notImportedTypes.Union(moduleNotImportedtTypes);
            }
        }

        if (notImportedTypes.Any())
        {
            ThrowExceptionForNotImportedTypes(notImportedTypes);
        }

        foreach (var module in modules)
        {
            module.ConfigureServices(services);
        }
    }

    /// <summary>
    /// Настроить опции локализации.
    /// </summary>
    /// <param name="options">Опции.</param>
    public static void ConfigureLocalization(this LocalizationOptions options)
    {
        options.ResourcesPath = "ResourceFiles";
    }

    #endregion Public methods

    #region Private methods

    private static void ThrowExceptionForNotImportedTypes(IEnumerable<Type> types)
    {
        var localizationOptions = new LocalizationOptions();

        localizationOptions.ConfigureLocalization();

        var options = Options.Create(localizationOptions);

        var factory = new ResourceManagerStringLocalizerFactory(options, NullLoggerFactory.Instance);

        var localizer = new StringLocalizer<AppResource>(factory);

        var resource = new AppResource(localizer);

        throw new LocalizedException(resource.GetErrorMessageForNotImportedTypes(types));
    }

    #endregion Private methods
}
