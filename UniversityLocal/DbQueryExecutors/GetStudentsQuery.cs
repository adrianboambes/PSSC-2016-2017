using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;

namespace DbQueryExecutors
{
    public class GetStudentsQuery: IQuery
    {
        public Guid TeacherId { get; set; }
        public Guid FacultyId { get; set; }
        public Guid MajorId { get; set; }
        
        public int StudyYearNumber { get; set; }

        public GetStudentsQuery()
        {
            
        }

        public GetStudentsQuery(Guid proffId, Guid FacId, Guid MjrId)
        {
            this.TeacherId = proffId;
            this.FacultyId = FacId;
            this.MajorId = MjrId;
        }
    }
}
