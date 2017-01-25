using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.Teacher
{
    public class TeacherFactory
    {
        public static readonly TeacherFactory Instance = new TeacherFactory();

        private TeacherFactory()
        { }

        public Teacher CreateTeacher(Guid Id, string name, List<Guid> schoolSubjectsIds )
        {
            var uniqueIdentifiers = new List<UniqueIdentifier>();
            foreach (var schoolSubjectsId in schoolSubjectsIds)
            {
                uniqueIdentifiers.Add(new UniqueIdentifier(schoolSubjectsId));
            }

            var teacher = new Teacher(new UniqueIdentifier(Id), new PlainText(name), uniqueIdentifiers);

            return teacher;
        }

        public List<Teacher> CreateTeachersList()
        {
            return new List<Teacher>();
        }

        public Teacher CreateTeacher()
        {
            return new Teacher();
        }
    }
}
