using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class Elitisme
    {
        Seed bestSeed = new Seed(new List<double>());
        int indexBadSeed = 0;

        public Elitisme() { }

        public Seed SaveBestSeed(List<Seed> seeds)
        {
            for (int i = 0; i < seeds.Count; i++)
            {
                //if (bestSeed.Data.Count == 0) bestSeed = seeds[i];
                if (seeds[i].Fitness < BestSeed.Fitness)
                {
                    bestSeed = new Seed(seeds[i].Data);
                    bestSeed.Fitness = seeds[i].Fitness;
                }
            }
            return bestSeed;
        }

        public List<Seed> UpdateSeeds(List<Seed> seeds)
        {
            // create bad Seed
            Seed badSeed = new Seed(new List<double>());
            badSeed.Fitness = 0;

            if (BestSeed.Fitness == double.MaxValue) SaveBestSeed(seeds);

            bool excist = false;
            for (int i = 0; i < seeds.Count; i++)
            {
                if (seeds[i].Fitness == bestSeed.Fitness) excist = true;
                else if (seeds[i].Fitness > BestSeed.Fitness)
                {
                    badSeed = seeds[i];
                    indexBadSeed = i;
                }
            }
            if (!excist) seeds[indexBadSeed] = BestSeed;

            return seeds;
        }

        public Seed BestSeed { get => bestSeed; }

    }
}
