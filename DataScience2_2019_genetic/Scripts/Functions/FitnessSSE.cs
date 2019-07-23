using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class FitnessSSE : IFitness
    {
        List<Seed> allUsers = new List<Seed>();
        List<double> pregList = new List<double>();

        public void Fitness(List<Seed> _allUsers, List<double> _pregList)
        {
            allUsers = _allUsers;
            pregList = _pregList;
        }

        public void Calculate(List<Seed> population)
        {
            // calculate the sum squere error of the seed
            // the sse is also the fitness in this case
            for (int i = 0; i < population.Count; i++)
            {
                Seed seed = population[i];
                double SSE = 0;
                for (int j = 0; j < allUsers.Count; j++)
                {
                    double prediction = 0;
                    for (int k = 0; k < seed.Data.Count; k++)
                    {
                        prediction += seed.Data[k] * allUsers[j].Data[k];
                    }
                    SSE += Math.Pow((pregList[j] - prediction), 2.0);
                }
                seed.Fitness = SSE;
            }
        }

    }
}
