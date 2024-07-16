namespace Makc2024.Dummy.Writer.DomainModel.Invoice;

public interface IInvoiceRepository : IReadRepository<InvoiceEntity>,
  IRepository<InvoiceEntity>
{
}
