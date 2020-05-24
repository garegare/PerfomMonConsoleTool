using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PerfomMonConsoleTool
{
    class ProcessorCounter : CounterBase, ICounter
    {
        internal override List<PerformanceCounter> counters { get; set; } = new List<PerformanceCounter>();

        public ProcessorCounter()
        {
            foreach (var cpuCount in Enumerable.Range(0, Environment.ProcessorCount))
            {
                this.counters.Add(
                    new PerformanceCounter("Processor", "% Processor Time", cpuCount.ToString())
                );
            }
        }

        public string MakeHeaders()
        {
            string header = "";
            foreach (var i in Enumerable.Range(0, counters.Count))
            {
                if (!string.IsNullOrEmpty(header))
                {
                    header += " ,";
                }
                header += "CPU" + i.ToString();
            }
            return header;
        }

        public string MakeBodies()
        {
            List<float> coreUsageValues = GetCpuCoreUsage();
            string result = "";

            foreach(var coreUsageValue in coreUsageValues)
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
