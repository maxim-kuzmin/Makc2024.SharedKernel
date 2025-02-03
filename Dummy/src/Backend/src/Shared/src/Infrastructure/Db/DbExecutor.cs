namespace Makc2024.Dummy.Shared.Infrastructure.Db;

/// <summary>
/// Исполнитель базы данных.
/// </summary>
/// <param name="_dbContext">Контекст базы данных.</param>
public class DbExecutor(DbContext _dbContext) : IDbExecutor
{
  private bool _isExecuting = false;

  private bool _isSaveChangesEnabled = false;

  private IsolationLevel _isolationLevel = DefaultIsolationLevel;  

  /// <summary>
  /// Уровень изоляции по умолчанию.
  /// </summary>
  public const IsolationLevel DefaultIsolationLevel = IsolationLevel.ReadCommitted;

  /// <inheritdoc/>
  public Task Execute(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken)
  {
    return Execute(null, funcToExecute, cancellationToken);
  }

  /// <inheritdoc/>
  public Task ExecuteInTransaction(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken)
  {
    return Execute(_dbContext.Database.BeginTransactionAsync, funcToExecute, cancellationToken);
  }

  /// <inheritdoc/>
  public IDbExecutor WithIsolationLevel(IsolationLevel isolationLevel)
  {
    _isolationLevel = isolationLevel;

    return this;
  }

  /// <inheritdoc/>
  public IDbExecutor WithSaveChanges()
  {
    _isSaveChangesEnabled = true;

    return this;
  }

  private async Task<IDbContextTransaction?> CreateTransaction(
    Func<IsolationLevel, CancellationToken, Task<IDbContextTransaction>>? funcToCreateTransaction,
    CancellationToken cancellationToken)
  {
    if (_dbContext.Database.CurrentTransaction != null)
    {
      return null;
    }

    return funcToCreateTransaction != null
      ? await funcToCreateTransaction.Invoke(_isolationLevel, cancellationToken).ConfigureAwait(false)
      : null;
  }

  private async Task Execute(
    Func<IsolationLevel, CancellationToken, Task<IDbContextTransaction>>? funcToCreateTransaction,
    Func<CancellationToken, Task> funcToExecute,
    CancellationToken cancellationToken)
  {
    if (_isExecuting)
    {
      await funcToExecute.Invoke(cancellationToken).ConfigureAwait(false);
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
          await funcToExecute.Invoke(cancellationToken).ConfigureAwait(false);

          if (_isSaveChangesEnabled)
          {
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
          }

          if (transaction != null)
          {
            await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
          }
          
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

      _isExecuting = false;

      _isSaveChangesEnabled = false;

      _isolationLevel = DefaultIsolationLevel;
    }
  }
}
