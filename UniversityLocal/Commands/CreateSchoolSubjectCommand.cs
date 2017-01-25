using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Commands;
using University.Generic.Enums;
using University.Models.StudyYear;

namespace Commands
{
    public class CreateSchoolSubjectCommand : ICommand
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public int ExamProportion { get; set; }

        public int Credits { get;  set; }
        public int EvaluationType { get;  set; }

        public CreateSchoolSubjectCommand() { }
        public CreateSchoolSubjectCommand(SchoolSubject schoolSubject)
        {
            this.Id = schoolSubject.Id.UniqueId;
            this.Name = schoolSubject.Name.Name;
            this.ExamProportion = (int) schoolSubject.ExamProportion.Fraction;
            this.Credits = schoolSubject.Credits.Count;
            this.EvaluationType = (int)schoolSubject.EvaluationType;
        }
    }
}
