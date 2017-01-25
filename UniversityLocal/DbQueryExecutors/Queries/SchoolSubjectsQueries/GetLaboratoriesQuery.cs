using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;

namespace DbQueryExecutors.Queries.SchoolSubjectsQueries
{
    public class GetLaboratoriesQuery: IQuery
    {
        public Guid TeacherId { get; set; }
        public Guid StudentId { get; set; }
        public Guid LaboratoryId { get; set; }

        public GetLaboratoriesQuery() { }

        public GetLaboratoriesQuery(Guid teacherId, Guid studentId, Guid laboratoryId)
        {
            this.TeacherId = teacherId;
            this.StudentId = studentId;
            this.LaboratoryId = laboratoryId;
        }
    }
}
