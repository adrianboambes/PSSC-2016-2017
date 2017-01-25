using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;

namespace DbQueryExecutors.Queries.TeachersQueries
{
    public class GetTeacherQuery: IQuery
    {
        public Guid TeacherId { get; set; }
        public Guid FacultyId { get; set; }

        public GetTeacherQuery() { }

        public GetTeacherQuery(Guid teacherId, Guid facultyId)
        {
            this.TeacherId = teacherId;
            this.FacultyId = facultyId;
        }
    }
}
