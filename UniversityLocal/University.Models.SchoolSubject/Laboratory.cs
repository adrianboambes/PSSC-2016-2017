using System;
using System.Diagnostics.Contracts;
using Interfaces.Queries;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.StudyYear
{
    public class Laboratory : ValueObject<Laboratory>, IQueryResult
    {
        public UniqueIdentifier Id { get; internal set; }
        public PlainText Name { get; internal set; }

        public string ContentLink { get; internal set; }

        internal Laboratory(UniqueIdentifier id, PlainText name, string contentLink)
        {
            Contract.Requires(Id != null, "The course name cannot be empty");
            Id = id;
            Name = name;
            ContentLink = contentLink;
        }

        #region operations

        internal void ActualizingContentLink(string url)
        {
            Contract.Requires(url != null, "The Laboratory url is null");
            ContentLink = url;
        }

        #endregion

        #region override objects

        public override string ToString()
        {
            return Name.ToString();
        }

        public override bool Equals(object obj)
        {
            var laboratory = (Laboratory) obj;

            if (laboratory != null)
            {
                return Name.Equals(laboratory.Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        #endregion
    }
}