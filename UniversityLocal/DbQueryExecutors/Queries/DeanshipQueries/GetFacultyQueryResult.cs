using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using University.Models.Deanship;

namespace DbQueryExecutors.Queries.DeanshipQueries
{
    public class GetFacultyQueryResult : IQueryResult
    {
        public List<Faculty> FacultiesList { get; set; }
        public bool IsSuccess { get; set; }
    }
}
