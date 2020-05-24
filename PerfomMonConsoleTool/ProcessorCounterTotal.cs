using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PerfomMonConsoleTool
{
    class ProcessorCounterTotal : CounterBase, ICounter
    {
        internal override List<PerformanceCounter> counters { get; set; } = new List<PerformanceCounter>();

        public ProcessorCounterTotal()
        {
            this.counters.Add(
                new PerformanceCounter("Processor", "% Processor Time", "_Total")
            );
        }

        public string MakeHeaders()
        {
            string header = "";
            header += "CPU(Total)";
            return header;
        }

        public string MakeBodies()
        {
            List<float> coreUsageValues = GetCpuCoreUsage();
            string result = "";

            foreach (var coreUsageValue in coreUsageValues)
            {
                if (!string.IsNullOrEmpty(result))
                {
                    result += " ,";
                }
                result += coreUsageValue.ToString();
            }
            return result;
        }
    }
}
