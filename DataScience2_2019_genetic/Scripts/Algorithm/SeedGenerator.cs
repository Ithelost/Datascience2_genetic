using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class SeedGenerator
    {
        Random random;
        int max;
        int min;
        int seedDataSize;

        public List<Seed> CreateListOfSeeds(int _populationSize, int _seedDataSize, Random _random, int _max, int _min)
        {
            random = _random;
            max = _max;
            min = _min;
            seedDataSize = _seedDataSize;

            List<Seed> seeds = new List<Seed>();
            for (int j = 0; j < _populationSize; j++)
            {

                seeds.Add(new Seed(GenerateSeed()));
            }
            return seeds;
        }

        private List<double> GenerateSeed()
        {
            List<double> data = new List<double>();
            for (int i = 0; i < seedDataSize; i++)
            {
                data.Add(random.NextDouble() * (max - min) + min);
            }
            return data;
        }
    }
}
