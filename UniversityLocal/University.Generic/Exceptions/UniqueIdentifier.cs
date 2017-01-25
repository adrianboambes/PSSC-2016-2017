using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Generic.Exceptions;

namespace University.Generic.Exceptions
{
    public class UniqueIdentifier
    {
        public Guid UniqueId { get;  set; }
        public List<Guid> UniqueIds { get; internal set; } 

        public UniqueIdentifier() { }
        public UniqueIdentifier(Guid uniqueId)
        {
            Contract.Requires<ArgumentNullException>(uniqueId != null, "The unique id cannot be null !");
            Contract.Requires<ArgumentCannotBeEmptyStringException>(string.IsNullOrEmpty(uniqueId.ToString()), "The unique id cannot be empty !");
            UniqueId = uniqueId;
        }

        public UniqueIdentifier(List<Guid> uniqueIds)
        {
            foreach (var uniqueId in uniqueIds)
            {
                Contract.Requires<ArgumentNullException>(uniqueId != null, "The unique id cannot be null !");
                Contract.Requires<ArgumentCannotBeEmptyStringException>(string.IsNullOrEmpty(uniqueId.ToString()), "The unique id cannot be empty !");
            }
           
            UniqueIds = uniqueIds;
        }
    }
    
}
