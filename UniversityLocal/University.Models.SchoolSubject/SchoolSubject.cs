using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Interfaces.Queries;
using University.Generic;
using University.Generic.Enums;
using University.Generic.Exceptions;

namespace University.Models.StudyYear
{
    public class SchoolSubject : ValueObject<SchoolSubject>, IQueryResult
    {
        public UniqueIdentifier Id { get; internal set; }
        public PlainText Name { get; internal set; }
        public Proportion ExamProportion { get; internal set; }

        public Credits Credits { get; internal set; }
        public EvaluationType EvaluationType { get; internal set; }

        public List<Course> Courses { get; internal set; } 
        public List<Laboratory> Laboratories { get; internal set; }
        public StudentSituation StudentFinalSituation{get; internal set; } 

        public List<UniqueIdentifier> SchoolSubjectProfessorsIds { get; internal set; }//list of ProfessorsIds that a schoolSubject can have    

        private List<Student> _registeredStudents;
        public ReadOnlyCollection<Student> RegisteredStudents { get { return _registeredStudents.AsReadOnly(); } }


        public SchoolSubject() { }
        public SchoolSubject(UniqueIdentifier Id, PlainText name, Proportion examProportion, Credits credits, EvaluationType evaluationType, List<Laboratory> laboratories = null , List<Course> courses = null)
        {
            this.Id = Id;
            this.Name = name;
            this.EvaluationType = evaluationType;
            this.Credits = credits;
            this.ExamProportion = examProportion;
            this.Laboratories = laboratories;
            this.Courses = courses;

        }
        public SchoolSubject(UniqueIdentifier Id, PlainText name, Proportion examProportion, Credits credits, EvaluationType evaluationType, List<Student> registeredStudents, List<Laboratory> laboratories, List<Course> courses )
            :this(Id, name, examProportion, credits, evaluationType, laboratories, courses)
        {
            ExamProportion = examProportion;
            _registeredStudents = registeredStudents;
        }

        //public SchoolSubject(PlainText name, Proportion examProportion, Credits credits, EvaluationType evaluationType, List<Student> registeredStudents, Guid schoolSubjectProfessorId, List<Laboratory> laboratories, List<Course> courses)
        //    : this(name, examProportion, credits, evaluationType, registeredStudents, laboratories, courses)
        //{
        //    ExamProportion = examProportion;
        //    SchoolSubjectProfessorId = schoolSubjectProfessorId;
        //}
    }
}
