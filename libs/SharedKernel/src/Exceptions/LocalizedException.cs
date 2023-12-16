// Copyright (c) 2023 Maxim Kuzmin. All rights reserved. Licensed under the MIT License.

namespace Makc2024.SharedKernel.Exceptions;

/// <summary>
/// Локализованное исключение.
/// Сообщение, передаваемое в это исключение, должно быть переведено на язык,
/// соответствующий текущей культуре приложения.
/// </summary>
/// <param name="message">Сообщение.</param>
public class LocalizedException(string message) : Exception(message)
{
}

