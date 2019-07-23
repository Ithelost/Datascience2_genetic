using DataScience2_2019_genetic.Scripts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Script
{
    interface ICrossover
    {
        void Crossover(double percentChance);
        List<Seed> Calculate(Seed seed1, Seed seed2);
    }
}
