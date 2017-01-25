using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;

namespace DbQueryExecutors
{
    public class UpdateStudentQuery: IQuery
    {
        public Guid StudentId { get; set; }

        public UpdateStudentQuery(Guid studentId)
        {
            this.StudentId = studentId;
        }
    }
}
