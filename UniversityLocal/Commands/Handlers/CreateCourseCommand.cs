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
    public class CreateCourseCommand : ICommand
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string ContentLink { get; set; }

        public CreateCourseCommand() { }

        public CreateCourseCommand(Course course)
        {
            this.Id = course.Id.UniqueId;
            this.Name = course.Name.Name;
            this.ContentLink = course.ContentLink;
        }
    }
}
