using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gym
{
    public class NoAthlete : Exception
    {
        public NoAthlete(string message):base(message) 
        {
            
        }
    }
}
