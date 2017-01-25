using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using University.Models.StudyYear;

namespace DbQueryExecutors.Queries.SchoolSubjectsQueries
{
    public class GetSchoolSubjectQueryResult: IQueryResult
    {
        public List<SchoolSubject> SchoolSubjectsList { get; set; }
        public bool IsSuccess { get; set; }
    }
}
