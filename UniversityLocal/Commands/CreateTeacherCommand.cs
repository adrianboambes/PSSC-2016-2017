using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Commands;
using University.Models.Teacher;

namespace Commands
{
    public class CreateTeacherCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public CreateTeacherCommand(Teacher teacher)
        {
            this.Id = teacher.Id.UniqueId;
            this.Name = teacher.Name.Name;
        }

    }
}
