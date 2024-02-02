using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym
{
    public class AthleteExercise
    {
        public Guid Id { get; set; }
        public string NameAthlete { get; set; }
        public string NameExercise { get; set; }
        public int Series { get; set; }
        public int Repetitions { get; set; }
        public double Weigth { get; set; }

        public Status Status { get; set; }

    }
}
