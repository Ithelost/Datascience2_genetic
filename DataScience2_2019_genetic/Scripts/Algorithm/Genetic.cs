using DataScience2_2019_genetic.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class Genetic
    {
        Helper helper = new Helper();
        Random random = new Random();

        IFitness fitness;
        ISelection selection;
        ICrossover crossover;
        Mutation mutation;
        Elitisme elitisme;

        bool cross;
        bool mut;
        bool elit;

        Population population;

        public Genetic(Population _population, ISelection _selection, ICrossover _crossover, IFitness _fitness, Elitisme _elitisme, Mutation _mutation, bool _elit)
        {
            selection = _selection;
            crossover = _crossover;
            mutation = _mutation;
            population = _population;
            fitness = _fitness;
            elitisme = _elitisme;
            elit = _elit;

            fitness.Calculate(population.Seeds);
        }

        public void Run()
        {
            Population parents = new Population();
            for (int i = 0; i < population.Seeds.Count; i++)
            {
                parents.Seeds.Add(selection.Select(population.Seeds));
            }

            List<Seed> children = new List<Seed>();
            children.Clear();
            for (int i = 0; i < parents.Seeds.Count; i += 2)
            {
                helper.Append(children, crossover.Calculate(parents.Seeds[i], parents.Seeds[i + 1]));
            }

            for (int i = 0; i < children.Count; i += 2)
            {
                mutation.Mutate(children[i]);
            }

            fitness.Calculate(children);

            if (elit) population = new Population(elitisme.UpdateSeeds(children));

            elitisme.SaveBestSeed(population.Seeds);

            Console.WriteLine("best seed at this time " + elitisme.BestSeed.Fitness);
        }

        public void IsPregnent(Seed bestSeed, int user, List<Seed> allSeeds)
        {
            double pregnant = 0;
            for (int i = 0; i < bestSeed.Data.Count; i++)
            {
                pregnant += (bestSeed.Data[i] * allSeeds[user].Data[i]);
            }

            bool isPregnant = false;
            if (pregnant >= 0.8) isPregnant = true;
            Console.WriteLine($"Klantnr: {user} isPregnant = {isPregnant}");
        }
    }
}
