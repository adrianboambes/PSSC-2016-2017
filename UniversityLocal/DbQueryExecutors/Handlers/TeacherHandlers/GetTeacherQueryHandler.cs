using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbQueryExecutors.Queries.TeachersQueries;
using Interfaces.Queries;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;
using University.Generic;
using University.Generic.Exceptions;
using University.Models.StudyYear;
using University.Models.Teacher;

namespace DbQueryExecutors.Handlers.TeacherHandlers
{
    public class GetTeacherQueryHandler: IQueryHandler<GetTeacherQuery, GetTeacherQueryResult>
    {
        public async Task<GetTeacherQueryResult> Retrieve(GetTeacherQuery query)
        {
            try
            {
                var getTeacherQueryResult = new GetTeacherQueryResult();
                getTeacherQueryResult.IsSuccess = false;

                var teachersRepository = new TeacherRepository();
                List<Teachers> databaseQueryTeachers= (List<Teachers>)await teachersRepository.GetAllAsync().ConfigureAwait(false);


                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Teachers, Teacher>()
                        //.DisableCtorValidation()
                        //.ReverseMap()
                        //.ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.RegistrationNumber))
                        //             .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name.Text))
                        //             .ForMember(dbUsr => dbUsr.Credits, vmUsr => vmUsr.MapFrom(vm => vm.Credits._credits));

                        .ForMember(vm => vm.Id, dbUsr => dbUsr.MapFrom(db => new UniqueIdentifier {UniqueId = db.Id}))
                        .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => new PlainText {Name = db.Name}));
                    //.ForMember(vm => vm, dbUsr => dbUsr.MapFrom(db => new Credits { _credits = db.Credits }));
                });

                getTeacherQueryResult.TeachersList = TeacherFactory.Instance.CreateTeachersList();
                if (databaseQueryTeachers == null)
                {

                    return getTeacherQueryResult;

                }

                getTeacherQueryResult.IsSuccess = true;
                foreach (var teacher in databaseQueryTeachers)
                {
                    var modelTeacherQuery = Mapper.Map<Teachers, Teacher>(teacher);
                    getTeacherQueryResult.TeachersList.Add(modelTeacherQuery);
                }


                return getTeacherQueryResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
