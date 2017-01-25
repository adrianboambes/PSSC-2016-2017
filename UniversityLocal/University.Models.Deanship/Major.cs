using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using University.Common;
using University.Common.Interfaces;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.Deanship
{
    public class Major: ValueObject<Major>, IQueryResult, IEntity
    {
        public UniqueIdentifier Id { get; internal set; }
        public PlainText Name { get; internal set; }
        public string Website { get; internal set; }

        internal Major(UniqueIdentifier id, PlainText name, string spcializationWebsite)
        {
            Id = id;
            Name = name;
            Website = spcializationWebsite;
        }

        #region override objects

        public override bool Equals(object obj)
        {
            var specialization = (Major) obj;
            if (specialization != null)
            {
                return Name.Equals(specialization.Name);
            }
            return false;
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        #endregion
    }
}
