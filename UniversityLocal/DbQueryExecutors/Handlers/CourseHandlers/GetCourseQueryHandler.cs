using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbQueryExecutors.Queries.SchoolSubjectsQueries;
using Interfaces.Queries;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;
using University.Generic;
using University.Generic.Exceptions;
using University.Models.StudyYear;
using University.Models.Teacher;

namespace DbQueryExecutors.Handlers.CourseHandlers
{
    public class GetCourseQueryHandler : IQueryHandler<GetCoursesQuery, GetCoursesQueryResult>
    {
        public async Task<GetCoursesQueryResult> Retrieve(GetCoursesQuery query)
        {
            try
            {
                var getCoursesQueryResult = new GetCoursesQueryResult();
                getCoursesQueryResult.IsSuccess = false;

                var coursesRepository = new StudyYearRepository<Courses>();
                List<Courses> databaseQueryCourses = (List<Courses>)await coursesRepository.GetAllAsync().ConfigureAwait(false);


                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Courses, Course>()
                        //.DisableCtorValidation()
                        //.ReverseMap()
                        //.ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.RegistrationNumber))
                        //             .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name.Text))
                        //             .ForMember(dbUsr => dbUsr.Credits, vmUsr => vmUsr.MapFrom(vm => vm.Credits._credits));

                        .ForMember(vm => vm.Id, dbUsr => dbUsr.MapFrom(db => new UniqueIdentifier { UniqueId = db.Id }))
                         .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => new PlainText { Name = db.Name }))
                         .ForMember(vm => vm.ContentLink, dbUsr => dbUsr.MapFrom(db => db.ContentLink));
                });

                getCoursesQueryResult.CoursesList = StudyYearFactory.Instance.CreateCoursesList();
                if (databaseQueryCourses == null)
                {
                    return getCoursesQueryResult;

                }

                getCoursesQueryResult.IsSuccess = true;
                foreach (var cours in databaseQueryCourses)
                {
                    var modelCoursQuery = Mapper.Map<Courses, Course>(cours);
                    getCoursesQueryResult.CoursesList.Add(modelCoursQuery);
                }


                return getCoursesQueryResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
 