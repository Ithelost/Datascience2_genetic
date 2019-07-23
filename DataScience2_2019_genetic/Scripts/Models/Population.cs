using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class Population
    {
        private List<Seed> seeds = new List<Seed>();
        
        public Population() { }

        public Population(List<Seed> _seeds)
        {
            seeds = _seeds;
        }

        public List<Seed> Seeds { get => seeds; set => seeds = value; }
    }
}
