namespace PTrampert.CommandPattern
{
    public class CreatedResult<TEntity> : IWriteResult<TEntity>
    {
        public TEntity Entity { get; set; }

        public CreatedResult(TEntity entity = default(TEntity))
        {
            Entity = entity;
        }

        public TReturn Handle<TReturn>(IWriteResultHandler<TEntity, TReturn> handler)
        {
            return handler.Created(Entity);
        }
    }
}