using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Commands
{
    public interface ICommandHandler<TParameter> where TParameter: ICommand
    {
        //handling the command - preparing the data for our dispatcher
        //send out data/event to the dispatcher
        Task<CommandResult> Execute(TParameter command);
    }
}
