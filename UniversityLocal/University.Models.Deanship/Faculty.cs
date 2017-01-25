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
   public  class Faculty: ValueObject<Faculty>, IQueryResult, IEntity
    {
        public UniqueIdentifier Id { get; internal set; }
        public PlainText Name { get; internal set; }
        public string Website { get; internal set; }

       internal Faculty() { }
       internal Faculty(UniqueIdentifier id, PlainText name, string websiteLink)
       {
           Id = id;
           Name = name;
           Website = websiteLink;
       }

       internal void ActualizingContent(string url)
       {
            Website = url;
       }

        #region overrride objects
        public override bool Equals(object obj)
       {
           var faculty = (Faculty) obj;
           if (faculty != null)
           {
               return Name.Equals(faculty.Name);
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
