using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Exception
{
    public class NoAthlete : NullReferenceException
    {
        public NoAthlete(string name):base(name) 
        {
            
        }
    }
    
}
