using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Modele.Generic.Exceptions;
using University.Generic;
using University.Generic.Enums;
using University.Generic.Exceptions;

namespace University.Models.StudyYear
{
    public class StudyYearFactory 
    {
        public static readonly StudyYearFactory Instance = new StudyYearFactory();

        private StudyYearFactory()
        { }

        public StudyYear CreateStudyYear(int yearNumber)
        {
            var studyYear = new StudyYear(yearNumber);

            return studyYear;
        }

        public SchoolSubject CreateSchoolSubject(Guid Id, string name, int proportion, int credits, int evaluationType, List<Laboratory> laboratories, List<Course> courses )
        {
            Contract.Requires<ArgumentNullException>(name != null, "The name is null !");
            Contract.Requires<ArgumentInvalidLengthException>(name.Length >= 2 && name.Length <= 50, "The name length should be between 2 and 50 characters !");

            var schoolSubject = new SchoolSubject(
                new UniqueIdentifier(Id), 
                new PlainText(name), 
                new Proportion(proportion, 1), 
                new Credits(credits),
                //(EvaluationType)Enum.Parse(typeof(EvaluationType), evaluationType, true),
                (EvaluationType)evaluationType,
                laboratories,
                courses
                );

            return schoolSubject;
        }

        public List<SchoolSubject> CreateSchoolSubjectsList()
        {
            return new List<SchoolSubject>();
        } 

        public Student CreateStudent()
        {
            return new Student();
        }
        public List<Student> CreateStudentList()
        {
           return new List<Student>();
        }
        public Student CreateStudent(Guid registrationNumber , string name, int credits)
        {
            var student =  new Student(
                new UniqueIdentifier(registrationNumber),
                new PlainText(name),
                new Credits(credits));

            return student;
        }

        public Course CreateCourse(Guid id, string name, string contentLink)
        {
            var course = new Course( 
                new UniqueIdentifier(id),
                new PlainText(name),
                contentLink);

            return course;
        }

        public Laboratory CreateLaboratory(Guid id, string name, string contentLink)
        {
            var laboratory = new Laboratory(
                new UniqueIdentifier(id),
                new PlainText(name),
                contentLink);

            return laboratory;
        }


        public List<Course> CreateCoursesList()
        {
            return new List<Course>();
        }

        public List<Laboratory> CreateLaboratoriesList()
        {
            return new List<Laboratory>();
        }
    }
}
