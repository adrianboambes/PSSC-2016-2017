using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Commands;
using Ninject;

namespace Commands
{
    public class CommandDispatcher: ICommandDispatcher
    {
        //sending the information about our event directly to the external system  to send it to the database
        private readonly IKernel _kernel;

        public CommandDispatcher(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }

            _kernel = kernel;
        }

        public async Task<CommandResult> Dispatch<TParameter>(TParameter command) where TParameter : ICommand
        {
            // Find the appropriate handler to call from those registered with Ninject based on the type parameters  
            var handler = _kernel.Get<ICommandHandler<TParameter>>();
            return await handler.Execute(command);
        }
    }
}
