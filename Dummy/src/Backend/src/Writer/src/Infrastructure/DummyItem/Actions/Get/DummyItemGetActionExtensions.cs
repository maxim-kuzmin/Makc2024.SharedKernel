namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Get;

public static class DummyItemGetActionExtensions
{
  public static DummyItemGetActionQuery ToDummyItemGetActionQuery(this DummyItemGetActionGrpcRequest request)
  {
    return new(request.Id);
  }

  public static DummyItemGetActionGrpcReply ToDummyItemGetActionGrpcReply(this DummyItemGetActionDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      Name = dto.Name,
    };
  }
}
