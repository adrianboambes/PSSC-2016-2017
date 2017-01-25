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
    public class CreateCourseCommandHandler: ICommandHandler<CreateCourseCommand>
    {
        public async Task<CommandResult> Execute(CreateCourseCommand command)
        {
            if (command != null)
            {
                try
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<CreateCourseCommand, Courses>();
                        //.DisableCtorValidation()
                        //.ForMember(dbPrf => dbPrf.Id, vmPrf => vmPrf.MapFrom(vm => vm.Id))
                        //.ForMember(dbPrf => dbPrf.Name, vmPrf => vmPrf.MapFrom(vm => vm.Name));
                    });

                    Mapper.Configuration.AssertConfigurationIsValid();

                    var studyYearRepository = new StudyYearRepository<Courses>();
                    var modelCommand = Mapper.Map<CreateCourseCommand, Courses>(command);

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
