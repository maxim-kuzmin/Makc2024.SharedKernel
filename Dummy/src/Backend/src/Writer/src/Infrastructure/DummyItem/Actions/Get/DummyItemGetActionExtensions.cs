namespace Makc2024.Dummy.Writer.Infrastructure.DummyItem.Actions.Get;

public static class DummyItemGetActionExtensions
{
  public static DummyItemGetActionQuery ToDummyItemGetActionQuery(this DummyItemGetActionRequest request)
  {
    return new(request.Id);
  }

  public static DummyItemGetActionReply ToDummyItemGetActionReply(this DummyItemGetActionDTO dto)
  {
    return new()
    {
      Id = dto.Id,
      Name = dto.Name,
    };
  }
}
