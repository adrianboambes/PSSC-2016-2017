using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using University.DataLayer;
using University.Models.StudyYear;

namespace DbQueryExecutors
{
    public class GetStudentsQueryResult: IQueryResult
    {
        public List<Student> Students { get; set; }
        public bool IsSuccess { get; set; }
    }
}
