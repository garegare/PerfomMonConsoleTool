using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PerfomMonConsoleTool
{
    abstract class CounterBase
    {
        internal abstract List<PerformanceCounter> counters { get; set; }

        public List<float> GetCpuCoreUsage()
        {
            List<float> usageValues = new List<float>(counters.Count);

            foreach (var i in Enumerable.Range(0, counters.Count))
            {
                usageValues.Add(counters[i].NextValue());
            }

            return usageValues;
        }
    }
}
