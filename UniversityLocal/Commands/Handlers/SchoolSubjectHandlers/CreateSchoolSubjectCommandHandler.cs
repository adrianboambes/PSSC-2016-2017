using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Interfaces.Commands;
using University.DataLayer;
using University.DataLayer.Implementation.Repositories;

namespace Commands.Handlers.SchoolSubjectHandlers
{
    public class CreateSchoolSubjectCommandHandler:ICommandHandler<CreateSchoolSubjectCommand>
    {
        public async Task<CommandResult> Execute(CreateSchoolSubjectCommand command)
        {
            if (command != null)
            {
                try
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<CreateSchoolSubjectCommand, SchoolSubjects>();
                        ////.DisableCtorValidation()
                        //.ForMember(dbUsr => dbUsr.Id, vmUsr => vmUsr.MapFrom(vm => vm.RegistrationNumber))
                        //.ForMember(dbUsr => dbUsr.Name, vmUsr => vmUsr.MapFrom(vm => vm.Name.Name))
                        //.ForMember(dbUsr => dbUsr.Credits, vmUsr => vmUsr.MapFrom(vm => vm.Credits._credits));
                    });

                    Mapper.Configuration.AssertConfigurationIsValid();

                    var schoolSubjectRepository = new StudyYearRepository<SchoolSubjects>();
                    var modelCommand = Mapper.Map<CreateSchoolSubjectCommand, SchoolSubjects>(command);

                    await schoolSubjectRepository.CreateAsync(modelCommand).ConfigureAwait(false);
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
