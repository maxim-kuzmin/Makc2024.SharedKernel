﻿namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.GetById;

public class DummyItemGetByIdActionSettings
{
  public static string CreateUri(DummyItemGetByIdActionQuery query)
  {
    return $"{DummyItemActionSettings.Root}/{query.Id}";
  }
}
