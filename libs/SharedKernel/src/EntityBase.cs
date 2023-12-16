namespace Makc2024.SharedKernel;

/// <summary>
/// Базовый класс для сущностей DDD. Включает поддержку отправки доменных событий после сохранения данных.
/// Используемый в классе идентификатор имеет тип int.
/// Если нужен тип идентификатора, отличный от int, можно использовать EntityBase&lt;TId&gt; с TId как тип для Id.
/// </summary>
public abstract class EntityBase : ArdalisSharedKernel.EntityBase
{
}

/// <summary>
/// Базовый класс для сущностей DDD. Включает поддержку отправки доменных событий после сохранения данных.
/// </summary>
/// <typeparam name="TId">Тип идентификатора.</typeparam>
public abstract class EntityBase<TId> : ArdalisSharedKernel.EntityBase<TId>
  where TId : struct, IEquatable<TId>
{
}
