using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Generic
{
    public class Credits: ValueObject<Credits>
    {

        private const int _maxCredits = 60;
        public static int MAX { get { return _maxCredits; } }

        public Nullable<int> _credits;
        public int Count { get { return (int) _credits; } set { _credits = value; } }

        public Credits()
        {
        }

        public Credits(int credits)
        {
            _credits = credits;
        }

    }
}
