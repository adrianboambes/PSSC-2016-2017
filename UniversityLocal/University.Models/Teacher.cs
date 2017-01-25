using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using University.DataLayer.Interfaces;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.Teacher
{
    public class Teacher : ValueObject<Teacher>, IAggregationRoot
    {
        public UniqueIdentifier Id { get; internal set; }
        public PlainText Name { get; internal set; }

        public Teacher(UniqueIdentifier Id,PlainText name)
        {
            this.Name = name;
            this.Id = Id;
        }
    }
}
