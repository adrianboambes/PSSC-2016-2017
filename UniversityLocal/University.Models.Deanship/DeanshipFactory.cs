using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Queries;
using Modele.Generic.Exceptions;
using University.Generic;
using University.Generic.Exceptions;

namespace University.Models.Deanship
{
    public class DeanshipFactory : IQueryResult
    {
        public static readonly DeanshipFactory Instance = new DeanshipFactory();

        private DeanshipFactory() { }

        public Deanship CreateDeanship(string name, Uri website)
        {
            Contract.Requires<ArgumentNullException>(name != null,"The name cannot be null !");
            Contract.Requires<ArgumentInvalidLengthException>(name.Length >= 2 && name.Length <= 50,"The name length should be between 2 and 50 characters !");
            var deanship = new Deanship(new UniqueIdentifier(new Guid()), new PlainText(name), (Uri)website);

            return deanship;
        }

        public Faculty CreateFaculty(Guid id, string name, string websiteLink)
        {
            var faculty = new Faculty(
                new UniqueIdentifier(id),
                new PlainText(name),
                websiteLink);

            return faculty;
        }

        internal Major CreateMajor(Guid id, string name, string specializationWebSite)
        {
            var major = new Major(
                new UniqueIdentifier(id),
                new PlainText(name),
                specializationWebSite);
            return major;

        }

        public List<Faculty> CreateFacultiesList()
        {
            return new List<Faculty>();
        }
    }
}
