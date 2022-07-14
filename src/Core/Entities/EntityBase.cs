namespace ClubApp.Core.Entities
{
    public abstract class EntityBase<TKey>
    {
        public virtual TKey Id { get; protected set; } = default!;
    }
}
