using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Generic.Exceptions;

namespace University.Common
{
    public interface IAggregationRoot
    {
        Guid Id { get; set; }
    }
}
