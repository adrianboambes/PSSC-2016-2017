using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;

namespace DbQueryExecutors.Queries.SchoolSubjectsQueries
{
    public class GetSchoolSubjectQuery : IQuery
    {
        public Guid TeacherId { get; set; }

        public Guid SchoolSubjectId { get; set; }
        
        public Guid StudentId { get; set; }

        public Guid StudyYearId { get; set; }

        public GetSchoolSubjectQuery() { }
        public GetSchoolSubjectQuery(Guid teacherId, Guid schoolSubjectId, Guid studentId)
        {
            this.TeacherId = teacherId;
            this.SchoolSubjectId = schoolSubjectId;
            this.StudentId = studentId;
        }
    }
}
