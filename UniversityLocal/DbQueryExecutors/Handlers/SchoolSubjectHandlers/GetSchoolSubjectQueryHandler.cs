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

namespace DbQueryExecutors.Handlers.SchoolSubjectHandlers
{
    public class GetSchoolSubjectQueryHandler : IQueryHandler<GetSchoolSubjectQuery, GetSchoolSubjectQueryResult>
    {
        public async Task<GetSchoolSubjectQueryResult> Retrieve(GetSchoolSubjectQuery query)
        {
            try
            {
                var getSchoolSubjectQueryResult = new GetSchoolSubjectQueryResult();
                getSchoolSubjectQueryResult.IsSuccess = false;

                var schoolSubjectRepository = new StudyYearRepository<SchoolSubjects>();
                List<SchoolSubjects> databaseQuerySchoolSubjects = (List<SchoolSubjects>)await schoolSubjectRepository.GetAllAsync().ConfigureAwait(false);


                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<SchoolSubjects, SchoolSubject>()
                    //.DisableCtorValidation()
                    //.ReverseMap()
                    //.ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.RegistrationNumber))
                    //.ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name.Text))
                    //.ForMember(dbUsr => dbUsr.Credits, vmUsr => vmUsr.MapFrom(vm => vm.Credits._credits));

                     .ForMember(vm => vm.Id, dbUsr => dbUsr.MapFrom(db => new UniqueIdentifier { UniqueId = db.Id }))
                     .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => new PlainText { Name = db.Name }))
                     .ForMember(vm => vm.ExamProportion, dbUsr => dbUsr.MapFrom(db => new Proportion{ FinalProportion = db.ExamProportion }))
                     .ForMember(vm => vm.Credits, dbUsr => dbUsr.MapFrom(db => new Credits { _credits = db.Credits }));
                });

                getSchoolSubjectQueryResult.SchoolSubjectsList = StudyYearFactory.Instance.CreateSchoolSubjectsList();
                if (databaseQuerySchoolSubjects == null)
                {
                    return getSchoolSubjectQueryResult;

                }

                getSchoolSubjectQueryResult.IsSuccess = true;
                foreach (var stud in databaseQuerySchoolSubjects)
                {
                    var modelSchoolSubjectQuery = Mapper.Map<SchoolSubjects, SchoolSubject>(stud);
                    getSchoolSubjectQueryResult.SchoolSubjectsList.Add(modelSchoolSubjectQuery);
                }


                return getSchoolSubjectQueryResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
