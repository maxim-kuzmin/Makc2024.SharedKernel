// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2024.SharedKernel.App;

/// <summary>
/// Ресурс приложения.
/// </summary>
/// <param name="_localizer">Локализатор.</param>
public class AppResource(IStringLocalizer<AppResource> _localizer) : IAppResource
{
    #region Public methods

    /// <inheritdoc/>
    public string GetErrorMessageForNotImportedTypes(IEnumerable<Type> types)
    {
        return _localizer["@@ErrorMessageForNotImportedTypes", string.Join(", ", types)];
    }

    #endregion Public methods
}
