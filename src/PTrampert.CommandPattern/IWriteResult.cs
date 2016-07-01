using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public interface IWriteResult<out TEntity>
    {
        TReturn Handle<TReturn>(IWriteResultHandler<TEntity, TReturn> handler);
    }
}
