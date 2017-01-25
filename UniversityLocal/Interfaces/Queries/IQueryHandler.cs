using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Queries
{
    public interface IQueryHandler<TParameter, TResult> 
        where TResult: IQueryResult
        where TParameter: IQuery
    {
        Task<TResult> Retrieve(TParameter query);
    }
}
