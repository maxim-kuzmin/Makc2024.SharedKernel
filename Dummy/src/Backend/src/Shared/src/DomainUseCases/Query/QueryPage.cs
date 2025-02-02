namespace Makc2024.Dummy.Shared.DomainUseCases.Query;

/// <summary>
/// Страница в запросе.
/// </summary>
/// <param name="Number">Номер.</param>
/// <param name="Size">Размер.</param>
public record QueryPage(int Number, int Size);
