using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Queries;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;
using University.Generic;
using University.Generic.Exceptions;
using University.Models.StudyYear;

namespace DbQueryExecutors.Handlers.StudentHandlers
{
   public class GetStudentsQueryHandler: IQueryHandler<GetStudentsQuery, GetStudentsQueryResult>
   {
       public async Task<GetStudentsQueryResult> Retrieve(GetStudentsQuery query)
       {
           try
           {
               var getStudentsQueryResult = new GetStudentsQueryResult();
               getStudentsQueryResult.IsSuccess = false;

                var studentsRepository = new StudentRepository();
                List<Students> databaseQueryStudents = (List<Students>)await studentsRepository.GetAllAsync().ConfigureAwait(false);

              
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<Students, Student>()
                            //.DisableCtorValidation()
                            //.ReverseMap()
                            //.ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.RegistrationNumber))
                            //             .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name.Text))
                            //             .ForMember(dbUsr => dbUsr.Credits, vmUsr => vmUsr.MapFrom(vm => vm.Credits._credits));

                            .ForMember(vm => vm.RegistrationNumber, dbUsr => dbUsr.MapFrom(db => new UniqueIdentifier{UniqueId = db.Id}))
                             .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => new PlainText {Name = db.Name }))
                             .ForMember(vm => vm.Credits, dbUsr => dbUsr.MapFrom(db => new Credits {_credits = db.Credits}));
                    });

                getStudentsQueryResult.Students = StudyYearFactory.Instance.CreateStudentList();
                if (databaseQueryStudents == null)
               {
                   return getStudentsQueryResult;

               }

               getStudentsQueryResult.IsSuccess = true;
               foreach (var stud in databaseQueryStudents)
               {
                    var modelStudentQuery = Mapper.Map<Students, University.Models.StudyYear.Student>(stud);
                    getStudentsQueryResult.Students.Add(modelStudentQuery);
               }
                 

                return getStudentsQueryResult;
            }
           catch (Exception ex)
           {

               throw ex;
           }
           
       }
   }
}
