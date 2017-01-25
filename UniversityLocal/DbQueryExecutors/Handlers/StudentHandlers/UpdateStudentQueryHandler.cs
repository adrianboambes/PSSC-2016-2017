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
    public class UpdateStudentQueryHandler: IQueryHandler<UpdateStudentQuery, UpdateStudentQueryResult>
    {
        public async Task<UpdateStudentQueryResult> Retrieve(UpdateStudentQuery query)
        {
            try { 
                var updateStudentQueryResult = new UpdateStudentQueryResult();
                updateStudentQueryResult.IsSuccess = false;

                var studentsRepository = new StudentRepository();
                Students databaseQueryStudent = await studentsRepository.GetAsync(query.StudentId).ConfigureAwait(false);


                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Students, Student>()
                        //.DisableCtorValidation()
                        //.ReverseMap()
                        //.ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.RegistrationNumber))
                        //             .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name.Text))
                        //             .ForMember(dbUsr => dbUsr.Credits, vmUsr => vmUsr.MapFrom(vm => vm.Credits._credits));

                        .ForMember(vm => vm.RegistrationNumber, dbUsr => dbUsr.MapFrom(db => new UniqueIdentifier { UniqueId = db.Id }))
                         .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => new PlainText { Name = db.Name }))
                         .ForMember(vm => vm.Credits, dbUsr => dbUsr.MapFrom(db => new Credits { _credits = db.Credits }));
                });


                if (databaseQueryStudent == null)
                {
                    return null;

                }

                updateStudentQueryResult.IsSuccess = true;
                updateStudentQueryResult.UpdatedStudent = StudyYearFactory.Instance.CreateStudent();

                var modelStudentQuery = Mapper.Map<Students, University.Models.StudyYear.Student>(databaseQueryStudent);
                updateStudentQueryResult.UpdatedStudent = modelStudentQuery;

                return updateStudentQueryResult;
           }
           catch (Exception ex)
           {
               throw ex;
           }

}
    }
}
