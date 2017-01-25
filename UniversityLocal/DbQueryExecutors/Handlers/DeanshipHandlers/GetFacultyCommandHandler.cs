using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DbQueryExecutors.Queries.DeanshipQueries;
using Interfaces.Queries;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;
using University.Generic;
using University.Generic.Exceptions;
using University.Models.Deanship;

namespace DbQueryExecutors.Handlers.DeanshipHandlers
{
    public class GetFacultyCommandHandler: IQueryHandler<GetFacultyQuery, GetFacultyQueryResult>
    {
        public async Task<GetFacultyQueryResult> Retrieve(GetFacultyQuery query)
        {
            try
            {
                var getFacultiesQueryResult = new GetFacultyQueryResult();
                getFacultiesQueryResult.IsSuccess = false;

                var facultiesRepository = new DeanshipRepository<Faculties>();
                List<Faculties> databaseQueryFaculties = (List<Faculties>)await facultiesRepository.GetAllAsync().ConfigureAwait(false);


                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Faculties, Faculty>()
                        //.DisableCtorValidation()
                        //.ReverseMap()
                        //.ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.RegistrationNumber))
                        //             .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name.Text))
                        //             .ForMember(dbUsr => dbUsr.Credits, vmUsr => vmUsr.MapFrom(vm => vm.Credits._credits));

                        .ForMember(vm => vm.Id, dbUsr => dbUsr.MapFrom(db => new UniqueIdentifier { UniqueId = db.Id }))
                         .ForMember(vm => vm.Name, dbUsr => dbUsr.MapFrom(db => new PlainText { Name = db.Name }))
                         .ForMember(vm => vm.Website, dbUsr => dbUsr.MapFrom(db => db.Website));
                });

                getFacultiesQueryResult.FacultiesList = DeanshipFactory.Instance.CreateFacultiesList();
                if (databaseQueryFaculties == null)
                {
                    return getFacultiesQueryResult;

                }

                getFacultiesQueryResult.IsSuccess = true;
                foreach (var fac in databaseQueryFaculties)
                {
                    var modelFacultyQuery = Mapper.Map<Faculties, Faculty>(fac);
                    getFacultiesQueryResult.FacultiesList.Add(modelFacultyQuery);
                }


                return getFacultiesQueryResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
