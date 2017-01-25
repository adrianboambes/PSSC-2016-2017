using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Commands;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;

namespace Commands.Handlers.FacultyHandlers
{
    public class CreateFacultyCommandHandler : ICommandHandler<CreateFacultyCommand>
    {
        public async  Task<CommandResult> Execute(CreateFacultyCommand command)
        {
            if (command != null)
            {
                try
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<CreateFacultyCommand, Faculties>()
                        .ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.Id))
                        .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name))
                        .ForMember(dbUsr => dbUsr.Website, vmUsr => vmUsr.MapFrom(vm => vm.Website));
                    });

                    Mapper.Configuration.AssertConfigurationIsValid();

                    var facultyRepositoryRepository = new DeanshipRepository<Faculties>();
                    var modelCommand = Mapper.Map<CreateFacultyCommand, Faculties>(command);

                    await facultyRepositoryRepository.CreateAsync(modelCommand).ConfigureAwait(false);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return null;
        }
    }
}
