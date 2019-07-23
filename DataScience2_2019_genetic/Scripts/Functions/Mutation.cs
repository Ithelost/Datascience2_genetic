using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class Mutation
    {
        Random random = new Random();
        Seed seed;

        double chance = 0;
        int maximum = 1;
        int minimum = -1;

        public Mutation(double _percentChance, int _maximum, int _minimum)
        {
            chance = _percentChance;
            maximum = _maximum;
            minimum = _minimum;
        }

        public Seed Mutate(Seed _seed)
        {
            seed = _seed;
            for (int i = 0; i < _seed.Data.Count; i++)
            {
                if (random.NextDouble() <= chance) seed.Data[i] = random.NextDouble() * (maximum - minimum) + minimum;
            }
            return seed;
        }
    }
}
