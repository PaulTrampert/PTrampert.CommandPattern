using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTrampert.CommandPattern
{
    public class WriteFailedResult<TEntity> : IWriteResult<TEntity>
    {
        public Exception Exception { get; set; }

        public WriteFailedResult(Exception e = null)
        {
            Exception = e;
        }

        public TReturn Handle<TReturn>(IWriteResultHandler<TEntity, TReturn> handler)
        {
            return handler.Failed(Exception);
        }
    }
}
