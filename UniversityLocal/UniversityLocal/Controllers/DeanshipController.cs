using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Commands;
using DbQueryExecutors.Queries.DeanshipQueries;
using Interfaces.Commands;
using Interfaces.Queries;
using University.Generic;
using University.Models;
using University.Models.Deanship;
using University.Models.StudyYear;

namespace UniversityLocal.Controllers
{
    public class DeanshipController : BaseController
    {

        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        //private readonly StudentService _service;

        public DeanshipController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
        public async Task<JsonResult> AddFaculty(CreateFacultyCommand createFacultyCmd)
        {
            var faculty = DeanshipFactory.Instance.CreateFaculty(Guid.NewGuid(), createFacultyCmd.Name, createFacultyCmd.Website);
            await _commandDispatcher.Dispatch(new CreateFacultyCommand(faculty));

            return Json("dsa");
        }

        public async Task<ActionResult> GetAllFaculties(GetFacultyQuery facultyQuery = null)
        {
            if (facultyQuery == null)
            {
                facultyQuery = new GetFacultyQuery();
            }

            var faculties = await _queryDispatcher.Dispatch<GetFacultyQuery, GetFacultyQueryResult>(facultyQuery);

            return View("ListFaculties", faculties.FacultiesList);
        }

        [HttpGet]
        public  ActionResult AddFaculty()
        {
            return View("CreateFaculty");
        }
        [HttpGet]
        public ActionResult GetAllStudents()
        {
            return null;
        }


        [HttpPost]
        public virtual async Task<SchoolSubject> DefineSchoolSubjects()
        {
            return null;
        }

        public virtual async Task<Grade> GenerateGradeRaport()
        {

            return null;
        }

    }
}
