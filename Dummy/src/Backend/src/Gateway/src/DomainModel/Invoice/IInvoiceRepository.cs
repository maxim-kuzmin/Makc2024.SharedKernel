namespace Makc2024.Dummy.Gateway.DomainModel.Invoice;

public interface IInvoiceRepository : IReadRepository<InvoiceEntity>,
  IRepository<InvoiceEntity>
{
}
