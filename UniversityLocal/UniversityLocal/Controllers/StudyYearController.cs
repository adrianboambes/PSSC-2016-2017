using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Commands;
using Commands.Handlers;
using DbQueryExecutors.Queries.SchoolSubjectsQueries;
using Interfaces.Commands;
using Interfaces.Queries;
using University.Generic;
using University.Generic.Exceptions;
using University.Models.Deanship;
using University.Models.StudyYear;

namespace UniversityLocal.Controllers
{
    public class StudyYearController : BaseController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        //private readonly StudentService _service;

        public StudyYearController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        public async Task<ActionResult> GetAllCourses(GetCoursesQuery courseQuery)
        {
            if (courseQuery == null)
            {
                courseQuery = new GetCoursesQuery();
            }

            var courses  = await _queryDispatcher.Dispatch<GetCoursesQuery, GetCoursesQueryResult>(courseQuery);
            if (!courses.IsSuccess)
            {
                courses.CoursesList = StudyYearFactory.Instance.CreateCoursesList();
            }

            return View("ListCourses", courses.CoursesList);
        }

        [HttpPost]
        public async Task<JsonResult> AddCourse(CreateCourseCommand createCourseCommand)
        {
            var course = StudyYearFactory.Instance.CreateCourse(Guid.NewGuid(),createCourseCommand.Name,createCourseCommand.ContentLink);

            try
            {
                _commandDispatcher.Dispatch(new CreateCourseCommand(course));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json("");
        }

        public async Task<ActionResult> GetAllLaboratories(GetLaboratoriesQuery laboratoryQuery)
        {
            if (laboratoryQuery == null)
            {
                laboratoryQuery = new GetLaboratoriesQuery();
            }

            var laboratory = await _queryDispatcher.Dispatch<GetLaboratoriesQuery, GetLaboratoriesQueryResult>(laboratoryQuery);
            if (!laboratory.IsSuccess)
            {
                laboratory.LaboratoriesList = StudyYearFactory.Instance.CreateLaboratoriesList();
            }

            return View("ListLaboratories", laboratory.LaboratoriesList);
        }



        [HttpPost]
        public async Task<JsonResult> AddLaboratory(CreateLaboratoryCommand createLaboratoryCommand)
        {
            var laboratory = StudyYearFactory.Instance.CreateLaboratory(Guid.NewGuid(), createLaboratoryCommand.Name, createLaboratoryCommand.ContentLink);

            try
            {
                await _commandDispatcher.Dispatch(new CreateLaboratoryCommand(laboratory));

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json("");
        }
        [HttpPost]
        public async Task<JsonResult> AddSchoolSubject(CreateSchoolSubjectCommand schoolSubjectCommand)
        {
            //here I must to have an parameter like CreateSchoolSubject command without complex properties like PlainText
            var schoolSubject = StudyYearFactory.Instance.CreateSchoolSubject(Guid.NewGuid(), schoolSubjectCommand.Name,
                schoolSubjectCommand.ExamProportion, schoolSubjectCommand.Credits, schoolSubjectCommand.EvaluationType,
                new List<Laboratory>(), new List<Course>());
            try
            {
                await _commandDispatcher.Dispatch(new CreateSchoolSubjectCommand(schoolSubject));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json("");
        }


        public async Task<ActionResult> GetAllSchoolSubjects(GetSchoolSubjectQuery schoolSubjectQuery = null)
        {
            if (schoolSubjectQuery == null)
            {
                schoolSubjectQuery = new GetSchoolSubjectQuery();
            }
            var schoolSubjects =
                await _queryDispatcher.Dispatch<GetSchoolSubjectQuery, GetSchoolSubjectQueryResult>(schoolSubjectQuery);
            if (!schoolSubjects.IsSuccess)
            {
                return View("ListSchoolSubjects", new List<SchoolSubject>());
            }

            return View("ListSchoolSubjects", schoolSubjects.SchoolSubjectsList);
        }

        public ActionResult AddSchoolSubject()
        {
            return View("CreateSchoolSubject");
        }
        public virtual async Task<SchoolSubject> GetSchoolSubjectsById()
        {
            return null;
        }

        public virtual async Task<SchoolSubject> SetExamGradeForSchoolSubject()
        {
            return null;
        }

        public virtual async Task<SchoolSubject> UpdateExameGradeForSchoolSubject()
        {
            return null;
        }

        public virtual async Task<Deanship> SetGradeForStudentActivity()
        {
            return null;
        }

        public virtual async Task<Deanship> SetLaboratoryPresenceLevel(List<Student> students)
        {
            return null;
        }

        public virtual async Task<Deanship> SetPercentOfStudentActivityForFinalAverageGrades(List<Student> students)
        {
            return null;
        }
    }
}