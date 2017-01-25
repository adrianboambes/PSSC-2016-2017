using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Commands;
using DbQueryExecutors;
using Interfaces.Commands;
using Interfaces.Queries;
using University.Models.StudyYear;
using University.Services;

namespace UniversityLocal.Controllers
{
    public class StudentController : BaseController
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        //private readonly StudentService _service;

        public StudentController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }



        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Create");
        }

        [HttpPost]
        public virtual async Task<JsonResult> AddStudent(string studentName)
        {
                //using the factory to create a student
                var student = StudyYearFactory.Instance.CreateStudent(Guid.NewGuid(), studentName, 0);

                var createStudentCommand = new CreateStudentCommand(student);               
                await _commandDispatcher.Dispatch<CreateStudentCommand>(createStudentCommand);
           //_service.AddStudent(student);

            //return student;
            return Json("HGJ");
        }

        public async Task<ActionResult> GetAllStudents(GetStudentsQuery studentsQuery = null)
        {
            if (studentsQuery == null)
            {
            studentsQuery = new GetStudentsQuery();
            }

            var students = await _queryDispatcher.Dispatch<GetStudentsQuery, GetStudentsQueryResult>(studentsQuery);

            return View("List",students.Students);
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> UpdateStudent(Guid studentId)
        {
            var updateStudentQuery = new UpdateStudentQuery(studentId);
            var student =
                await _queryDispatcher.Dispatch<UpdateStudentQuery, UpdateStudentQueryResult>(updateStudentQuery);

            ViewBag.StudentId = studentId;
            ViewBag.StudeName = student.UpdatedStudent.Name.Name;
            ViewBag.StudentCredits = student.UpdatedStudent.Credits._credits;

            return View("Edit",student.UpdatedStudent);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public async Task<JsonResult> UpdateStudentPost(UpdateStudentCommand student)
        {
            try
            {
                await _commandDispatcher.Dispatch(student);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Json("DSADAS");
        }

        //public ActionResult UpdateStudent(int id, FormCollection collection)the synthax when you are waiting for a form =>>FormCollection


        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
