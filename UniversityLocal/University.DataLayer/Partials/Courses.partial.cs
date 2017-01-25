using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Common;
using University.Common.Interfaces;

namespace University.DataLayer
{
    public partial class Courses : IDatabaseObjectEntity, IStudyYearRepository, IDatabaseObjectEntityWithoutId
    {
    }
}
