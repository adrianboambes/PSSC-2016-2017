using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;

namespace DbQueryExecutors.Queries.SchoolSubjectsQueries
{
    public class GetCoursesQuery: IQuery
    {
        public Guid TeacherId { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }

        public GetCoursesQuery() { }

        public GetCoursesQuery(Guid teacherId, Guid studentId, Guid courseId)
        {
            this.TeacherId = teacherId;
            this.StudentId = studentId;
            this.CourseId = courseId;
        }
    }
}
