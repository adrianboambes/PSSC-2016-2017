using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Common;
using University.Common.Interfaces;
using University.DataLayer.Repositories;
using University.Models.Deanship;

namespace University.DataLayer.Implementation.Repositories
{
    public class DeanshipRepository<T> : BaseRepositoryWithSinglePk<T> where T : class, IDeanshipRepository, IDatabaseObjectEntity, IDatabaseObjectEntityWithoutId, new()
    {
    }
}
