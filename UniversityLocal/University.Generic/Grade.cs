using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Generic
{
    public class Grade : ValueObject<Grade>
    {
        private decimal _value;

        public decimal GradeValue
        {
            get { return _value; }
        }
        
        public Grade(decimal value)
        {
            Contract.Requires<ArgumentException>(value > 0, "This is not a valid grade !");
            Contract.Requires<ArgumentException>(value <= 10, "This is not a valid grade !");

            _value = value;
        }

        #region override object

        public override bool Equals(object obj)
        {
            var grade = (Grade) obj;
            return GradeValue == grade.GradeValue;
        }

        public override string ToString()
        {
            return $"{GradeValue}";
        }
        #endregion
    }


}