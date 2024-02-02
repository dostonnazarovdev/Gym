using Gym.Models;

namespace Gym
{
    public class GymManagment
    {
        private List<Athlete> athleteList = new List<Athlete>();
        private List<Exercice> exerciceList = new List<Exercice>();

        public void addAthlete(string name, double weight)
        {
            var exist = getAthleteByName(name);
            if (exist != null)
            {
                Console.WriteLine("Athlete already exists!");
            }
            Athlete athlete = new Athlete()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Weight = weight
            };
            athleteList.Add(athlete);
        }

        public Athlete getAthleteByName(string name)
        {
            foreach (var item in athleteList)
            {
                if (item != null && item.Name.Equals(name))
                {
                    return item;
                }
            }
            return null;
        }

        public string getAthlete(string name)
        {
            foreach (var item in athleteList)
            {
                if (item.Name.Equals(name))
                {
                    return item.Name + " " + item.Weight;
                }
            }
            throw new NoAthlete("Sportsnam qani???");
        }

        public void addExercise(string name, double coefficient)
        {
            Exercice exist = getExerciseByName(name);
            if(exist != null)
            {
                Console.WriteLine("This Exercise already exist!!!");
            }
            Exercice exercice = new Exercice()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Coefficient = coefficient
            };
        }

        public Exercice getExerciseByName(string name)
        {
            foreach (var item in exerciceList)
            {
                if (item != null && item.Name.Equals(name))
                {
                    return item;
                }
            }
            return null;
        }

        public string getExercise(string name)
        {
            foreach (var item in exerciceList)
            {
                if (item != null && item.Name.Equals(name))
                {
                    return item.Name + " " + item.Coefficient;
                }
            }
            throw new NoExercice("Where is Exercise?");
        }

        public void addExerciseToProgram(string nameAthlete, string nameExercise, int series,
                                         int repetitions, double weight)
        {

        }

        public void trainingStart(string nameAthlete, string nameExercise)
        {

        }

        public void trainingEnd(string nameAthlete, string nameExercise)
        {

        }

        public double caloriesBurnt(string nameAthlete)
        {
            return 0;
        }

        public double caloriesTarget(string nameAthlete)
        {
            return 0;
        }

        public string score(string nameAthlete)
        {
            return null;
        }

        public string worstExercise(string nameAthlete)
        {
            return null;
        }

        public string bestExercise(string nameAthlete)
        {
            return null;
        }

        public string exercisesByPerformance(string nameAthlete)
        {
            return null;
        }

        public string exercisesByExecutionOrder(string nameAthlete)
        {
            return null;
        }
    }
}
