using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modele.Generic.Exceptions;

namespace University.Generic
{
    public class PlainText: ValueObject<PlainText>
    {
        private string _text;
        public string Name { get { return _text; } set { _text = value; } }
        //public string Name { get; set; }
        public PlainText() { }
        public PlainText(string text)
        {
            Contract.Requires<ArgumentNullException>(text != null, "text");
            Contract.Requires<ArgumentCannotBeEmptyStringException>(!string.IsNullOrEmpty(text), "text");

            _text = text;
        }

        #region override object
        //public override string ToString()
        //{
        //    return Name;
        //}

        //public override bool Equals(object obj)
        //{
        //    var nume = (PlainText)obj;
        //    return Name.Equals(nume.Name);
        //}

        //public override int GetHashCode()
        //{
        //    return Name.GetHashCode();
        //}
        #endregion
    }
}
