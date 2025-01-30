namespace Makc2024.Dummy.Shared.Core.DTOs;

/// <summary>
/// Объект передачи данных списка.
/// </summary>
/// <typeparam name="TItem">Тип элемента.</typeparam>
/// <typeparam name="TTotalCount">Тип общего количества.</typeparam>
/// <param name="Items">Элементы.</param>
/// <param name="TotalCount">Общее количество.</param>
public record ListDTO<TItem, TTotalCount>(
  List<TItem> Items,
  TTotalCount TotalCount)
  where TItem : class
  where TTotalCount: struct;
