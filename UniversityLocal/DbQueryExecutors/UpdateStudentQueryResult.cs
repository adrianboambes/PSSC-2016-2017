using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using University.Models.StudyYear;

namespace DbQueryExecutors
{
    public class UpdateStudentQueryResult: IQueryResult
    {
        public Student UpdatedStudent { get; set; }
        public bool IsSuccess { get; set; }
    }
}
