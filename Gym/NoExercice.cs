using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym
{
    public class NoExercice : Exception
    {

        public NoExercice(string exercice) 
            : base(exercice) 
        {

        }
    }
}
