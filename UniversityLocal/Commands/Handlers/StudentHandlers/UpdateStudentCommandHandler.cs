using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Commands;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;

namespace Commands.Handlers.StudentHandlers
{
    public class UpdateStudentCommandHandler: ICommandHandler<UpdateStudentCommand>
    {
        public async Task<CommandResult> Execute(UpdateStudentCommand command)
        {
            if (command != null)
            {
                try
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<UpdateStudentCommand, Students>()
                        //.DisableCtorValidation()
                        .ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.RegistrationNumber))
                        .ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name))
                        .ForMember(dbUsr => dbUsr.Credits, vmUsr => vmUsr.MapFrom(vm => vm.Credits));
                    });

                    Mapper.Configuration.AssertConfigurationIsValid();

                    var studentRepository = new StudentRepository();
                    var modelCommand = Mapper.Map<UpdateStudentCommand, Students>(command);

                    await studentRepository.UpdateAsync(modelCommand).ConfigureAwait(false);
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
