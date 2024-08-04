namespace Makc2024.Dummy.Shared.DTOs;

public record ListDTO<TItem, TTotalCount>(
  List<TItem> Items,
  TTotalCount TotalCount)
  where TItem : class
  where TTotalCount: struct;
