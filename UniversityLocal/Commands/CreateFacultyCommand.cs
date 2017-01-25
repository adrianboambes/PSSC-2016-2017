using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Commands;
using University.Models.Deanship;

namespace Commands
{
    public class CreateFacultyCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }

        public CreateFacultyCommand() { }

        public CreateFacultyCommand(Faculty faculty)
        {
            this.Id = faculty.Id.UniqueId;
            this.Name = faculty.Name.Name;
            this.Website = faculty.Website;
        }
    }
}
