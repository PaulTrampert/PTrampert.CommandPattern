using System;

namespace PTrampert.CommandPattern
{
    public interface IWriteResultHandler<in TEntity, out TReturn>
    {
        TReturn Created(TEntity entity);

        TReturn Deleted(TEntity entity);

        TReturn Updated(TEntity entity);

        TReturn Failed(Exception e);
    }
}