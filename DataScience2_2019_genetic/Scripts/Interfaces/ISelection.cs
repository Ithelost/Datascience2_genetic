using System;
using System.Collections.Generic;
using System.Text;

namespace DataScience2_2019_genetic.Scripts
{
    interface ISelection
    {
        Seed Select(List<Seed> data);
    }
}
