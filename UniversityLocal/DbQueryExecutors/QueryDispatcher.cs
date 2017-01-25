using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using Ninject;

namespace DbQueryExecutors
{
    public class QueryDispatcher: IQueryDispatcher
    {
        //selects and executes the appropriate query
        //getting the information for what do we need from database
        private readonly IKernel _kernel;

        public QueryDispatcher(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException(nameof(kernel));
            }

            _kernel = kernel;
        }

        public async Task<TResult> Dispatch<TParameter, TResult>(TParameter query)
            where TParameter : IQuery
            where TResult : IQueryResult
        {
            // Find the appropriate handler to call from those registered with Ninject based on the type parameters
            var handler = _kernel.Get<IQueryHandler<TParameter, TResult>>();
            return await handler.Retrieve(query);
        }
    }
}
