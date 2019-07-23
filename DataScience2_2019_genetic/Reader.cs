using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class Reader
    {
         public List<double> GetPregnantData()
        {
            StreamReader reader = new StreamReader(@"C:\Users\jacob\Documents\Visual Studio 2017\Projects\DataScience2_2019_genetic\DataScience2_2019_genetic\Resources\preg_data.csv");

            List<double> preg_list = new List<double>();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');

                preg_list.Add(Convert.ToDouble(values[0]));
            }
            reader.Close();

            return preg_list;
        }

        public List<Seed> GetAllUserData()
        {
            StreamReader reader = new StreamReader(@"C:\Users\jacob\Documents\Visual Studio 2017\Projects\DataScience2_2019_genetic\DataScience2_2019_genetic\Resources\data.csv");

            List<Seed> seeds = new List<Seed>();

            int iteration = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();

                Seed seed = CreateSeed(line, iteration);
                seeds.Add(seed);
                iteration += 1;
            }
            reader.Close();

            return seeds;
        }

        private Seed CreateSeed(String line, int iteration)
        {
            String[] value = line.Split(';');

            List<double> seedData = new List<double>();
            for (int i = 0; i < value.Length; i++)
            {
                seedData.Add(Convert.ToDouble(value[i]));
            }
            return new Seed(seedData);
        }
    }
}
