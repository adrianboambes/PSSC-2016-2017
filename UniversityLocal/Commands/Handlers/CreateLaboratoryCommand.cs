using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Commands;
using University.DataLayer;
using University.Generic.Exceptions;
using University.Models.StudyYear;

namespace Commands.Handlers
{
    public class CreateLaboratoryCommand : ICommand
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string ContentLink { get; set; }

        public CreateLaboratoryCommand() { }

        public CreateLaboratoryCommand(Laboratory lab)
        {
            this.Id = lab.Id.UniqueId;
            this.Name = lab.Name.Name;
            this.ContentLink = lab.ContentLink;
        }
    }
}
