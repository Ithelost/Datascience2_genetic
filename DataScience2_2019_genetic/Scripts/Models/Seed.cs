using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class Seed
    {
        Random random = new Random();
        int dim = 0;
        List<double> data = new List<double>();
        double fitness = double.MaxValue;

        int maximum;
        int minimum;

        public Seed(int _dimensions, Random _random, int _max, int _min)
        {
            dim = _dimensions;
            random = _random;
            maximum = _max;
            minimum = _min;
            GenerateSeed();
        }

        public Seed (List<double> _data)
        {
            data = _data;
            dim = data.Count;
        }

        private void GenerateSeed()
        {
            for (int i = 0; i < dim; i++)
            {
                data.Add(random.NextDouble() * (maximum - minimum) + minimum);
            }
        }

        public List<double> Data { get => data; set => data = value; }
        public double Fitness { get => fitness; set => fitness = value; }

    }
}
