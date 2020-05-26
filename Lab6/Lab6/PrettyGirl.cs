using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{

    [Couple(Pair = "Student", Probability = 0.4, ChildType = "PrettyGirl")]
    [Couple(Pair = "Botan", Probability = 0.1, ChildType = "PrettyGirl")]
    sealed class PrettyGirl : Human
    {
        public PrettyGirl(string name) : base(name)
        {
        }
    }


}