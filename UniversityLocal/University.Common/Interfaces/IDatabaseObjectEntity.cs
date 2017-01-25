using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Common.Interfaces;

namespace University.Common
{
    public interface IDatabaseObjectEntity :IDatabaseBaseObjectEntity
    {
        Guid Id { get; set; }
    }
}
