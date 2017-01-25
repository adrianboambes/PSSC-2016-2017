using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Commands;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;

namespace Commands.Handlers.TeacherHandlers
{
    public class CreateTeacherCommandHandler : ICommandHandler<CreateTeacherCommand>
    {
        public async Task<CommandResult> Execute(CreateTeacherCommand command)
        {
            if (command != null)
            {
                try
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<CreateTeacherCommand, Teachers>()
                            //.DisableCtorValidation()
                            .ForMember(dbPrf => dbPrf.Id, vmPrf => vmPrf.MapFrom(vm => vm.Id))
                            .ForMember(dbPrf => dbPrf.Name, vmPrf => vmPrf.MapFrom(vm => vm.Name));
                    });

                    Mapper.Configuration.AssertConfigurationIsValid();

                    var teacherRepository = new TeacherRepository();
                    var modelCommand = Mapper.Map<CreateTeacherCommand, Teachers>(command);

                    await teacherRepository.CreateAsync(modelCommand).ConfigureAwait(false);
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
