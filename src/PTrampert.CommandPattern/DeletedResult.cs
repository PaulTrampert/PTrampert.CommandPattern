namespace PTrampert.CommandPattern
{
    public class DeletedResult<TEntity> : IWriteResult<TEntity>
    {
        public TEntity Entity { get; set; }

        public DeletedResult(TEntity entity = default(TEntity))
        {
            Entity = entity;
        }

        public TReturn Handle<TReturn>(IWriteResultHandler<TEntity, TReturn> handler)
        {
            return handler.Deleted(Entity);
        }
    }
}