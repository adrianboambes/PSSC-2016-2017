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

namespace DbQueryExecutors.Handlers.LaboratoryHandlers
{
    public class GetLaboratoryQueryHandler : IQueryHandler<GetLaboratoriesQuery, GetLaboratoriesQueryResult>
    {
        public async Task<GetLaboratoriesQueryResult> Retrieve(GetLaboratoriesQuery query)
        {
            try
            {
                var getLaboratoriesQueryResult = new GetLaboratoriesQueryResult();
                getLaboratoriesQueryResult.IsSuccess = false;

                var laboratoriesRepository = new StudyYearRepository<Laboratories>();
                List<Laboratories> databaseQueryLaboratories = (List<Laboratories>)await laboratoriesRepository.GetAllAsync().ConfigureAwait(false);


                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Laboratories, Laboratory>()
                    //.DisableCtorValidation()
                    //.ReverseMap()
                    //.ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.Id))
                    //             .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name))
                    //             .ForMember(dbUsr => dbUsr.ContentLink, vmUsr => vmUsr.MapFrom(vm => vm.ContentLink));
                    .ForMember(vm => vm.Id, dbUsr => dbUsr.MapFrom(db => new UniqueIdentifier { UniqueId = db.Id }))
                    .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => new PlainText { Name = db.Name }))
                    .ForMember(vm => vm.ContentLink, dbUsr => dbUsr.MapFrom(db => db.ContentLink));
                });

                getLaboratoriesQueryResult.LaboratoriesList = StudyYearFactory.Instance.CreateLaboratoriesList();
                if (databaseQueryLaboratories == null)
                {

                    return getLaboratoriesQueryResult;

                }

                getLaboratoriesQueryResult.IsSuccess = true;
                foreach (var lab in databaseQueryLaboratories)
                {
                    var modelLaboratoryQuery = Mapper.Map<Laboratories, Laboratory>(lab);
                    getLaboratoriesQueryResult.LaboratoriesList.Add(modelLaboratoryQuery);
                }


                return getLaboratoriesQueryResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
 