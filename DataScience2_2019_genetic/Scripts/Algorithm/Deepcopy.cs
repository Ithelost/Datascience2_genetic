using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class Deepcopy
    {
        public List<T> CreateList<T>(List<T> List)
        {
            List<T> copy = new List<T>();
            for (int i = 0; i < List.Count; i++)
            {
                copy.Add(List[i]);
            }
            return copy;
        }
    }
}
