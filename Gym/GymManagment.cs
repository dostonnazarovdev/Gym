using Gym.Exception;
using Gym.Models;
using System.Runtime.InteropServices;

namespace Gym
{
    public class GymManagment
    {
        private List<Athlete> athleteList = new List<Athlete>();
        private List<Exercice> exerciceList = new List<Exercice>();
        private List<AthleteExercise> athleteExerciseList = new List<AthleteExercise>();


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
            throw new NoAthlete("Where is Sportsman ???");
        }

        public void addExercise(string name, double coefficient)
        {
            Exercice exist = getExerciseByName(name);
            if (exist != null)
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
            throw new NoExercice("Where is Exercise ???");
        }

        public void addExerciseToProgram(string nameAthlete, string nameExercise, int series, int repetitions, double weight)
        {
            Athlete athlete = getAthleteByName(nameAthlete);
            Exercice exercise = getExerciseByName(nameExercise);

            if (athlete == null)
            {
                throw new NoAthlete("Where is Sportsman ???");
            }
            if (exercise == null)
            {
                throw new NoAthlete("Where is Exercise ???");
            }
            AthleteExercise athleteExercise = new AthleteExercise()
            {
                Id = Guid.NewGuid(),
                NameAthlete = nameAthlete,
                NameExercise = nameExercise,
                Series = series,
                Repetitions = repetitions,
                Weigth = weight
            };
            athleteExerciseList.Add(athleteExercise);
        }

        public void trainingStart(string nameAthlete, string nameExercise)
        {
            foreach (var item in athleteExerciseList)
            {
                if (item.NameAthlete.Equals(nameAthlete) && item.NameExercise.Equals(nameExercise))
                {
                    item.Status = Status.STARTED;
                }
            }
        }

        public void trainingEnd(string nameAthlete, string nameExercise)
        {
            foreach (var item in athleteExerciseList)
            {
                if (item.NameAthlete.Equals(nameAthlete) && item.NameExercise.Equals(nameExercise))
                {
                    item.Status = Status.ENDED;
                }
            }
        }

        public double caloriesBurnt(string nameAthlete)
        {
            double burntColories = 0.0;
            foreach (var item in athleteExerciseList)
            {
                if (item.Status != null && item.Status.Equals(Status.ENDED) && item.NameAthlete.Equals(nameAthlete))
                {
                    burntColories += item.getColoriesBurnt();
                }
            }
            return burntColories;
        }

        public double caloriesTarget(string nameAthlete)
        {
            double colories = 0.0;
            foreach (var item in athleteExerciseList)
            {
                if (item != null && item.NameAthlete.Equals(nameAthlete))
                {
                    colories += item.getColoriesBurnt();
                }
            }
            return colories;
        }

        public string score(string nameAthlete)
        {
            double calorB = caloriesBurnt(nameAthlete);
            double calorT = caloriesTarget(nameAthlete);

            if (calorB / calorT >= 1)
            {
                return "Goog";
            }
            else if (calorB / calorT >= 0.8 && calorB / calorT <= 1)
            {
                return "Average";
            }
            else if (calorB / calorT <= 0.8)
            {
                return "Bad";
            }
            return null;
        }


        public string worstExercise(string nameAthlete)
        {
            double worseEx = 0.0;

            foreach (var athlete in athleteExerciseList)
            {
                bool atColors = true;
                if (athlete != null && athlete.NameAthlete.Equals(nameAthlete))
                {
                  if(atColors)
                    {    
                        worseEx = athlete.getColoriesBurnt();
                        atColors = false;
                             
                    }else if (worseEx > athlete.getColoriesBurnt())
                    {
                        worseEx =athlete.getColoriesBurnt();
                    }
                }
            }
            return null;
        }

        public string bestExercise(string nameAthlete)
        {
            double bestEx = 0.0;

            foreach (var athlete in athleteExerciseList)
            {
                bool atColors = true;
                if (athlete != null && athlete.NameAthlete.Equals(nameAthlete))
                {
                    if (atColors)
                    {
                        bestEx = athlete.getColoriesBurnt();
                        atColors = false;

                    }
                    else if (bestEx < athlete.getColoriesBurnt())
                    {
                         bestEx = athlete.getColoriesBurnt();
                    }
                }
            }
            return null;
          
        }

        public string exercisesByPerformance(string nameAthlete)
        {
            foreach (var item in athleteExerciseList)
            {
                if(item!=null && item.NameAthlete.Equals(nameAthlete))
                {
                    return item.NameExercise + ", " + item.getColoriesBurnt();
                }
            }
            return null;
        }

        public string exercisesByExecutionOrder(string nameAthlete)
        {
            foreach (var item in athleteExerciseList)
            {
                if (item != null && item.NameAthlete.Equals(nameAthlete))
                {
                    return item.Exercice.Name + ", ";
                }
            }
            return null;
    
        }
    }
}
