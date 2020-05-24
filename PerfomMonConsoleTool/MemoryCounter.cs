using System.Collections.Generic;
using System.Diagnostics;

namespace PerfomMonConsoleTool
{
    class MemoryCounter : CounterBase, ICounter
    {
        internal override List<PerformanceCounter> counters { get; set; } = new List<PerformanceCounter>();

        public MemoryCounter()
        {
            this.counters.Add(
                new PerformanceCounter("Memory", "Available Mbytes")
            );
        }

        public string MakeHeaders()
        {
            string header = "";
            header += "Memory(Available Mbytes)";
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
