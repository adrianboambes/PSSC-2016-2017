using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using University.Models.Teacher;

namespace DbQueryExecutors.Queries.TeachersQueries
{
    public class GetTeacherQueryResult: IQueryResult
    {
        public List<Teacher> TeachersList { get; set; }
        public bool IsSuccess { get; set; }
    }
}
