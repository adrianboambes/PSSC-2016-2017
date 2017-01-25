using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Commands;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;

namespace Commands.Handlers.CourseHandlers
{
    public class CreateLaboratoryCommandHandler: ICommandHandler<CreateLaboratoryCommand>
    {
        public async Task<CommandResult> Execute(CreateLaboratoryCommand command)
        {
            if (command != null)
            {
                try
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<CreateLaboratoryCommand, Laboratories>();
                        //.DisableCtorValidation()
                        //.ForMember(dbPrf => dbPrf.Id, vmPrf => vmPrf.MapFrom(vm => vm.Id))
                        //.ForMember(dbPrf => dbPrf.Name, vmPrf => vmPrf.MapFrom(vm => vm.Name));
                    });

                    Mapper.Configuration.AssertConfigurationIsValid();

                    var studyYearRepository = new StudyYearRepository<Laboratories>();
                    var modelCommand = Mapper.Map<CreateLaboratoryCommand, Laboratories>(command);

                    await studyYearRepository.CreateAsync(modelCommand).ConfigureAwait(false);
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
