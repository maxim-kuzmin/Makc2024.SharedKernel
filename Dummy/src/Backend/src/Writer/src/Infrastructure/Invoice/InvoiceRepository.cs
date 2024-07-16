namespace Makc2024.Dummy.Writer.Infrastructure.Invoice;

public class InvoiceRepository(AppDbContext dbContext) :
  AppRepositoryBase<InvoiceEntity>(dbContext),
  IInvoiceRepository
{
}
