using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.Teacher
{
    public class Teacher : ValueObject<Teacher>, IQueryResult
    {
        //agregation root 

        public UniqueIdentifier Id { get; internal set; }
        public PlainText Name { get; internal set; }

        public List<UniqueIdentifier> SchoolSubjectsIds { get; internal set; }//list of schoolSubjectsIds that a  teacher can teach

        internal Teacher() { }
        internal Teacher(UniqueIdentifier id, PlainText name, List<UniqueIdentifier> schoolSubjectsIds)
        {
            this.Name = name;
            this.Id = id;
            this.SchoolSubjectsIds = schoolSubjectsIds;
        }
    }
}
