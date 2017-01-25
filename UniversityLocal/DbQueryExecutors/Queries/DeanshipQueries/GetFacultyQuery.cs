using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;

namespace DbQueryExecutors.Queries.DeanshipQueries
{
    public class GetFacultyQuery: IQuery
    {
        public Guid FacultyId { get; set; }
        public Guid DeanshipId { get; set; }

        public GetFacultyQuery() { }

        public GetFacultyQuery(Guid facultyId, Guid deanshipId)
        {
            this.FacultyId = facultyId;
            this.DeanshipId = deanshipId;
        }
    }
}
