namespace PTrampert.CommandPattern
{
    public class UpdatedResult<TEntity> : IWriteResult<TEntity>
    {
        public TEntity Entity { get; set; }

        public UpdatedResult(TEntity entity = default(TEntity))
        {
            Entity = entity;
        }

        public TReturn Handle<TReturn>(IWriteResultHandler<TEntity, TReturn> handler)
        {
            return handler.Updated(Entity);
        }
    }
}