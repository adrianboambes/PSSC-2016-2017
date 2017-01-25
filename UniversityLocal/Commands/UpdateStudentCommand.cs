using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Commands;
using University.Generic.Exceptions;
using University.Models.StudyYear;

namespace Commands
{
    public class UpdateStudentCommand: ICommand
    {
        public Guid RegistrationNumber { get; set; }
        public string Name { get; set; }
        public Nullable<int> Credits { get; set; }

        public UpdateStudentCommand() { }
        public UpdateStudentCommand(Student student)
        {
            this.RegistrationNumber = student.RegistrationNumber.UniqueId;
            this.Name = student.Name.Name;
            this.Credits = student.Credits._credits;
        }
    }
}
