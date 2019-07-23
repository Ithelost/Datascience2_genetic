using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    class Helper
    {
        public List<T> Append<T>(List<T> list1, List<T> list2)
        {
            for (int i = 0; i < list2.Count; i++)
            {
                list1.Add(list2[i]);
            }
            return list1;
        }

        public List<T> Append<T>(List<T> list1, List<T> list2, List<T> list3)
        {
            for (int i = 0; i < list2.Count; i++)
            {
                list1.Add(list2[i]);
            }
            for (int i = 0; i < list3.Count; i++)
            {
                list1.Add(list3[i]);
            }
            return list1;
        }


    }
}
