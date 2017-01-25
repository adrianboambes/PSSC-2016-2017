using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Common.Interfaces;
using University.DataLayer.Repositories;
using System.Collections.Generic;
using University.Common;

namespace University.DataLayer.Implementation.Repositories
{
    public class StudyYearRepository<T>: BaseRepositoryWithSinglePk<T> where T : class, IStudyYearRepository, IDatabaseObjectEntity, IDatabaseObjectEntityWithoutId, new()
    {
    }
}
