using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;

namespace University.Models.StudyYear
{
    public class StudyYear : IQueryResult
    {
        public int YearNumber { get; internal set; }

        public List<Student> registeredStudents { get; internal set; }

        public StudyYear(int yearNumber)
        {
            YearNumber = yearNumber;
        } 
    }
}
