namespace Gateway.Infrastructure.Invoice;

public class InvoiceRepository(AppDbContext dbContext) :
  AppRepositoryBase<InvoiceEntity>(dbContext),
  IInvoiceRepository
{
}
