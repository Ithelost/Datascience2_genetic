using DataScience2_2019_genetic.Script;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class TwoPointCrossover : ICrossover
    {
        Helper helper = new Helper();

        Random random = new Random();
        Seed parent1;
        Seed parent2;

        List<Seed> children = new List<Seed>();

        double chance = 0;
        public void Crossover(double percentChance)
        {
            chance = percentChance;
        }

        public List<Seed> Calculate(Seed _seed1, Seed _seed2)
        {
            children.Clear();

            parent1 = _seed1;
            parent2 = _seed2;

            int crossoverPoint1 = random.Next(0, parent1.Data.Count);
            int crossoverPoint2 = random.Next(0, parent1.Data.Count);

            if (random.NextDouble() <= chance)
            {
                if (crossoverPoint1 < crossoverPoint2) CreateChildren(crossoverPoint1, crossoverPoint2);
                else CreateChildren(crossoverPoint2, crossoverPoint1);
            }
            else
            {
                children.Add(parent1);
                children.Add(parent2);
            }

            return children;
        }

        private void CreateChildren(int crossoverPoint1, int crossoverPoint2)
        {
            List<double> p1_left = new List<double>();
            List<double> p1_mid = new List<double>();
            List<double> p1_right = new List<double>();

            List<double> p2_left = new List<double>();
            List<double> p2_mid = new List<double>();
            List<double> p2_right = new List<double>();

            for (int i = 0; i < parent1.Data.Count; i++)
            {
                if (i <= crossoverPoint1)
                {
                    p1_left.Add(parent1.Data[i]);
                    p2_left.Add(parent2.Data[i]);
                }
                else if (i > crossoverPoint2)
                {
                    p1_right.Add(parent1.Data[i]);
                    p2_right.Add(parent2.Data[i]);
                }
                else
                {
                    p1_mid.Add(parent1.Data[i]);
                    p2_mid.Add(parent2.Data[i]);
                }
            }
            children.Add(new Seed(helper.Append(p1_left, p2_mid, p1_right)));
            children.Add(new Seed(helper.Append(p2_left, p1_mid, p2_right)));
        }
    }
}
