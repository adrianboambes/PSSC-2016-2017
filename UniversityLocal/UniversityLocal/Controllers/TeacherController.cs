using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Commands;
using DbQueryExecutors.Queries.TeachersQueries;
using Interfaces.Commands;
using Interfaces.Queries;
using University.DataLayer.Implementation.Repositories;
using University.Models;
using University.Models.Deanship;
using University.Models.StudyYear;
using University.Models.Teacher;

namespace UniversityLocal.Controllers
{
    public class TeacherController : BaseController
    {

        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        //private readonly StudentService _service;

        public TeacherController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public virtual async Task<SchoolSubject> GetSchoolSubjectsById()
        {
            //createStudentCommand
            //pt fiecare actiune o comanda
            //o lista de comenzi
            //bag comanda in lista 
            //odata ce handlerul a luat o comanda o scot din lista 
            //din handler
            //event pe lista (cand scot sau bag comenzi)
            //conceptul de bus  
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

        public virtual async Task<Deanship> SetLaboratoryPresenceLevel(List<Student> students )
        {
            return null;
        }

        public virtual async Task<Deanship> SetPercentOfStudentActivityForFinalAverageGrades(List<Student> students)
        {
            return null;
        }



        // GET: Teacher/Details/5
        public async Task<ActionResult> GetAll()
        {
            var getAllTeachersQuery = new GetTeacherQuery();
            var teachers = await _queryDispatcher.Dispatch<GetTeacherQuery, GetTeacherQueryResult>(getAllTeachersQuery);

            return View("List",teachers.TeachersList);
        }

        // GET: Teacher/Create
        [HttpGet]
        public ActionResult Add()
        {
            return View("Create");
        }

        // POST: Teacher/Create
        [HttpPost]
        public async Task<JsonResult> AddTeacher(string teacherName)
        {
            try
            {
                //for the moment I can't create a teacher because I need first to create some schoolSubjects
                //var schoolSubjects = StudyYearFactory.Instance.CreateSchoolSubjectsList();
                var teacher = TeacherFactory.Instance.CreateTeacher(Guid.NewGuid(), teacherName.ToString(), new List<Guid>() );
                var createTeacherCommand = new CreateTeacherCommand(teacher);

                await _commandDispatcher.Dispatch(createTeacherCommand);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return Json("");
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
