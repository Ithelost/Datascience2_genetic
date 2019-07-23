using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    interface IFitness
    {
        void Fitness(List<Seed> allUsers, List<double> pregList);
        void Calculate(List<Seed> population);
    }
}
