namespace Makc2024.Dummy.Shared.Infrastructure.Db;

/// <summary>
/// Исполнитель базы данных.
/// </summary>
/// <param name="_dbContext">Контекст базы данных.</param>
public class DbExecutor<TDbContext>(TDbContext _dbContext) : IDbExecutor where TDbContext : DbContext
{
  private bool _isExecuting = false;

  /// <inheritdoc/>
  public Task Execute(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken)
  {
    return Execute(null, (t, ct) => funcToExecute(ct), cancellationToken);
  }

  /// <inheritdoc/>
  public Task ExecuteInTransaction(
    Func<IDbContextTransaction?, CancellationToken, Task> funcToExecute,
    CancellationToken cancellationToken)
  {
    return Execute(_dbContext.Database.BeginTransactionAsync, funcToExecute, cancellationToken);
  }

  /// <inheritdoc/>
  public Task ExecuteInTransaction(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken)
  {
    return Execute(_dbContext.Database.BeginTransactionAsync, (t, ct) => funcToExecute(ct), cancellationToken);
  }

  private async Task<IDbContextTransaction?> CreateTransaction(
    Func<CancellationToken, Task<IDbContextTransaction>>? funcToCreateTransaction,
    CancellationToken cancellationToken)
  {
    if (_dbContext.Database.CurrentTransaction != null)
    {
      return null;
    }

    return funcToCreateTransaction != null
      ? await funcToCreateTransaction.Invoke(cancellationToken).ConfigureAwait(false)
      : null;
  }

  private async Task Execute(
    Func<CancellationToken, Task<IDbContextTransaction>>? funcToCreateTransaction,
    Func<IDbContextTransaction?, CancellationToken, Task> funcToExecute,
    CancellationToken cancellationToken)
  {
    if (_isExecuting)
    {
      await funcToExecute.Invoke(_dbContext.Database.CurrentTransaction, cancellationToken).ConfigureAwait(false);
    }
    else
    {
      _isExecuting = true;

      var isCommited = false;

      while (!isCommited)
      {
        var transaction = await CreateTransaction(funcToCreateTransaction, cancellationToken).ConfigureAwait(false);

        try
        {
          await funcToExecute.Invoke(transaction, cancellationToken).ConfigureAwait(false);

          transaction?.Commit();

          isCommited = true;
        }
        catch (DbUpdateConcurrencyException ex)
        {
          foreach (var entry in ex.Entries)
          {
            var databaseValues = await entry.GetDatabaseValuesAsync(cancellationToken).ConfigureAwait(false);

            if (databaseValues == null)
            {
              throw;
            }

            entry.OriginalValues.SetValues(databaseValues);
          }
        }
        finally
        {
          transaction?.Dispose();
        }
      }
    }
  }
}
