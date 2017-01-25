using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Generic.Exceptions;

namespace University.Generic
{
    public class RegistrationNumber: ValueObject<RegistrationNumber>
    {
        private string _number;
        public string Number { get { return _number; } }

        public RegistrationNumber() { }
        public RegistrationNumber(string number)
        {
            Contract.Requires<ArgumentNullException>(number != null, "text");
            Contract.Requires<ArgumentCannotBeEmptyStringException>(!string.IsNullOrEmpty(number), "text");
            Contract.Requires<ArgumentException>(number.Length == 7, "The registration number must have exactly 7 characters.");

            _number = number;
        }


        #region override object
        public override string ToString()
        {
            return Number;
        }

        public override bool Equals(object obj)
        {
            var nume = (RegistrationNumber)obj;
            return Number.Equals(nume.Number);
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }

        #endregion
    }
}
