namespace Gateway.DomainModel.Invoice;

public interface IInvoiceRepository : IReadRepository<InvoiceEntity>,
  IRepository<InvoiceEntity>
{
}
