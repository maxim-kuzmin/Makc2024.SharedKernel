namespace Makc2024.Dummy.Shared.Infrastructure.Db;

/// <summary>
/// Исполнитель базы данных.
/// </summary>
public class DbExecutor : IDbExecutor
{
  private readonly DbContext _dbContext;

  private bool _isExecuting;
  private bool _isSaveChangesEnabled;
  private IsolationLevel _isolationLevel;
  private IDbContextTransaction? _transaction;

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="dbContext">Контекст базы данных.</param>
  public DbExecutor(DbContext dbContext)
  {
    _dbContext = dbContext;

    Reset();
  }

  /// <summary>
  /// Уровень изоляции по умолчанию.
  /// </summary>
  public const IsolationLevel DefaultIsolationLevel = IsolationLevel.ReadCommitted;

  /// <inheritdoc/>
  public Task Execute(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken)
  {
    return Execute(funcToExecute, false, cancellationToken);
  }

  /// <inheritdoc/>
  public Task ExecuteInTransaction(Func<CancellationToken, Task> funcToExecute, CancellationToken cancellationToken)
  {
    return Execute(funcToExecute, true, cancellationToken);
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

  private async Task Execute(
    Func<CancellationToken, Task> funcToExecute,
    bool shouldBeExecutedInTransaction,
    CancellationToken cancellationToken)
  {
    if (shouldBeExecutedInTransaction)
    {
      _transaction = _dbContext.Database.CurrentTransaction;

      if (_transaction == null)
      {
        var task = _dbContext.Database.BeginTransactionAsync(_isolationLevel, cancellationToken);

        _transaction = await task.ConfigureAwait(false);
      }
    }

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
        try
        {
          await funcToExecute.Invoke(cancellationToken).ConfigureAwait(false);

          if (_isSaveChangesEnabled)
          {
            await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
          }

          if (_transaction != null)
          {
            await _transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
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
          if (_transaction != null)
          {
            await _transaction.DisposeAsync();
          }
        }
      }

      Reset();
    }
  }

  private void Reset()
  {
    _isExecuting = false;
    _isSaveChangesEnabled = false;
    _isolationLevel = DefaultIsolationLevel;
    _transaction = null;
  }
}
