using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Interfaces.Queries;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.StudyYear
{
    //Entity
    public class Student : ValueObject<Student>, IQueryResult
    {
        public UniqueIdentifier RegistrationNumber { get; internal set; }
        public PlainText Name { get; internal set; }
        public Credits Credits { get; internal set; }

        internal Student() { }
        internal Student(UniqueIdentifier regNumber, PlainText name)
        {
            Contract.Requires(regNumber != null, "The registration numebr cannot be null !");
            Contract.Requires(name != null, "The student name cannot be null !");
            RegistrationNumber = regNumber;
            Name = name;
        }

        internal Student(UniqueIdentifier regNumber, PlainText name, Credits credits)
            : this(regNumber, name)
        {
            Credits = credits;
        }

    }
}
