using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using University.Generic;

namespace University.Models.StudyYear
{
    public class StudentSituation : IQueryResult
    {
        public Grade ActivityGrade { get; internal set; }
        public Grade ExamGrade { get; internal set; }
        public Grade FinalGrade { get; internal set; }


        public StudentSituation(Grade activitygrades, Grade examGrade, Grade finalGrade )
        {
            this.ActivityGrade = activitygrades;
            this.ExamGrade = examGrade;
            this.FinalGrade = finalGrade;
        }
    }
}
