using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DataLayer.Repositories;

namespace University.DataLayer.Implementation.Repositories
{
    public class StudentRepository: BaseRepositoryWithSinglePk<Students>, IRepository
    {
        //todo delete this repo because I need only one per aggregation route
    }
}
