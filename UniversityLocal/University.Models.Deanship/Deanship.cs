using Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using University.Common;
using University.Common.Interfaces;
using University.Generic;
using University.Generic.Enums;
using University.Generic.Exceptions;
using University.Models.StudyYear;

namespace University.Models.Deanship
{
    public class Deanship : Entity<Guid>, IAggregationRoot, IEntity,  IQueryResult //TODO : here I must to replace the Entity<Guid> with a base class like ValueObject (for the moment the value object does not accept Collection properties)
    {
        public UniqueIdentifier Id { get; private set; }
        public PlainText Name { get; private set; }
        public Uri Website { get; private set; }

        private List<SchoolSubject> _definedSchoolSubjects;
        private List<Teacher.Teacher> _definedProfessors;
        public Deanship() {}
        public Deanship(UniqueIdentifier Id, PlainText name, Uri website) 
        {
            this.Id = Id;
            this.Name = name;
            this.Website = website;
        }

        public Deanship(UniqueIdentifier Id, PlainText name, Uri website, List<SchoolSubject> definedSchoolSubjects, List<Teacher.Teacher> definedProfessors) : this(Id, name, website)
        {
            _definedSchoolSubjects = definedSchoolSubjects;
            _definedProfessors = definedProfessors;
        }

        public ReadOnlyCollection<SchoolSubject> SchoolSubjects
        {
            get { return _definedSchoolSubjects.AsReadOnly(); }
        }


        public ReadOnlyCollection<Teacher.Teacher> Professors
        {
            get { return _definedProfessors.AsReadOnly(); }
        }

        public void DefinedSchoolSubject(UniqueIdentifier Id, PlainText name, Proportion examProportion, Credits credits,
            EvaluationType evaluationType, List<Laboratory> laboratories, List<Course> courses)
        {
            _definedSchoolSubjects.Add(new SchoolSubject(Id, name, examProportion, credits, evaluationType, laboratories, courses) );
        }
        public void DefinedSchoolSubject(UniqueIdentifier Id, PlainText name, Proportion examProportion, Credits credits,
            EvaluationType evaluationType, List<Student> registeredStudents, List<Laboratory> laboratories, List<Course> courses)//profesorul care se ocupa de disciplina respectiva
        {
            _definedSchoolSubjects.Add(new SchoolSubject(Id, name, examProportion, credits, evaluationType, registeredStudents, laboratories, courses));
        }
        public void DefinedSchoolSubject(PlainText name, Proportion examProportion, Credits credits,
            EvaluationType evaluationType, List<Student> registeredStudents, Guid schoolSubjectProfessorId, List<Laboratory> laboratories, List<Course> courses)//studentii inscrisi pt fiecare disciplina
        {
            //_definedSchoolSubjects.Add(new SchoolSubject(name, examProportion, credits, evaluationType, registeredStudents, schoolSubjectProfessorId, laboratories, courses));
        }
        //above in those methodes, when I define a schoolSubject, I attach for it: students, professor, courses, laboratories, so I do not need separate methods for that
    }
}