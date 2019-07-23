using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class Roulette : ISelection
    {
        List<Seed> kopiePop = new List<Seed>();
        List<Seed> population = new List<Seed>();

        List<double> selection = new List<double>();

        Random random = new Random();
        double minFit = double.MaxValue;
        double maxFit = 0;

        double normMinFit = double.MaxValue;
        double normMaxFit = 0;

        public Seed Select(List<Seed> _population)
        {
            Deepcopy copy = new Deepcopy();
            kopiePop = copy.CreateList(_population);
            population = copy.CreateList(_population);

            TurnFitNegToPos();
            GetMaxMin();

            for (int i = 0; i < kopiePop.Count; i++)
            {
                double normFit = NormLowerBeter(kopiePop[i].Fitness);
                selection.Add(normFit + normMaxFit);

                if (normMinFit > normFit) normMinFit = normFit;
                normMaxFit += normFit;
            }

            Seed seed = GetParent();
            ResetData();

            return seed;
        }
        private void TurnFitNegToPos()
        {
            double neg = 0;
            for (int i = 0; i < kopiePop.Count; i++)
            {
                double fit = kopiePop[i].Fitness;
                if (fit < neg) neg = fit;
            }
            for (int i = 0; i < kopiePop.Count; i++)
            {
                kopiePop[i].Fitness += -neg;
            }
        }
        private void GetMaxMin()
        {
            for (int i = 0; i < kopiePop.Count; i++)
            {
                double fit = kopiePop[i].Fitness;
                if (minFit > fit) minFit = fit;
                if (maxFit < fit) maxFit = fit;
            }
        }
        private Seed GetParent()
        {
            double rangeMin = 0;
            double rangeMax = normMaxFit;
            double randomDouble = rangeMin + (rangeMax - rangeMin) * random.NextDouble();

            Seed seed = new Seed(new List<double>());

            for (int i = 0; i < selection.Count; i++)
            {
                if (i == 0)
                {
                    if (randomDouble >= 0 && randomDouble < selection[i + 1])
                    {
                        seed = population[i];
                        break;
                    }
                }
                else if (i == kopiePop.Count)
                {
                    seed = population[population.Count - 1];
                    break;
                }
                else if (randomDouble > selection[i] && randomDouble <= selection[i + 1])
                {
                    seed = population[i];
                    break;
                }
            }
            return seed;
        }

        private double NormLowerBeter (double fit)
        {
            return 1 - ((fit - minFit) / (maxFit - minFit));
        }

        private void ResetData()
        {
            kopiePop = new List<Seed>();
            population = new List<Seed>();
            selection = new List<double>();

            random = new Random();
            minFit = double.MaxValue;
            maxFit = 0;

            normMinFit = double.MaxValue;
            normMaxFit = 0;
        }
    }
}
