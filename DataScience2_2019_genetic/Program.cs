using DataScience2_2019_genetic.Script;
using System;
using System.Collections.Generic;

namespace DataScience2_2019_genetic.Scripts
{
    class Program
    {
        private static List<Seed> allSeeds = new List<Seed>();

        static void Main(string[] args)
        {
            Random random = new Random();

            Reader reader = new Reader();
            List<double> pregList = reader.GetPregnantData();
            allSeeds = reader.GetAllUserData();

            int min = -1;
            int max = 1;
            double mR = 0.08;
            double cR = 0.6;
            bool elitism = true;
            int populationSeedListSize = 50;
            int seedDataSize = 20;

            // Generate list of seeds and add them to a populations
            SeedGenerator seedGenerator = new SeedGenerator();
            List<Seed> seeds = seedGenerator.CreateListOfSeeds(populationSeedListSize, seedDataSize, random, max, min);
            Population population = new Population(seeds);

            IFitness fitness = new FitnessSSE();
            fitness.Fitness(allSeeds, pregList);
            ICrossover crossover = new SinglePointCrossover();
            crossover.Crossover(cR);

            ISelection selection = new Roulette();
            Mutation mutation = new Mutation(mR, max, min);
            Elitisme elitisme = new Elitisme();

            Genetic genetic = new Genetic(population, selection, crossover, fitness, elitisme, mutation, elitism);

            int iterations = 500;
            for (int i = 0; i < iterations; i++)
            {
                genetic.Run();
            }

            genetic.IsPregnent(elitisme.BestSeed, 8, allSeeds);

            Console.ReadLine();
        }
    }
}
