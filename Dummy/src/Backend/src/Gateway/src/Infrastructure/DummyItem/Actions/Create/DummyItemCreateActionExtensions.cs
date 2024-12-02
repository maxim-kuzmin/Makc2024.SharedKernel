﻿namespace Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Actions.Create;

public static class DummyItemCreateActionExtensions
{
  public static JsonContent ToHttpRequestContent(this DummyItemCreateActionCommand command)
  {
    return JsonContent.Create(command);
  }

  public static DummyItemCreateActionGrpcRequest ToDummyItemCreateActionGrpcRequest(this DummyItemCreateActionCommand command)
  {
    return new DummyItemCreateActionGrpcRequest
    {
      Name = command.Name,
    };
  }
}
