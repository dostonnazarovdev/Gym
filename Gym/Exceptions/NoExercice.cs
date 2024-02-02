using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Exception
{
    public class NoExercice : NullReferenceException
    {

        public NoExercice(string name):base(name)
        { 
        }
    }
}
