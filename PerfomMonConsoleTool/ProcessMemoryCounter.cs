using System.Collections.Generic;
using System.Diagnostics;

namespace PerfomMonConsoleTool
{
    class ProcessMemoryCounter : CounterBase, ICounter
    {
        internal override List<PerformanceCounter> counters { get; set; } = new List<PerformanceCounter>();

        private string processName = "";

        public ProcessMemoryCounter(string processName = null)
        {
            this.processName = processName ?? Process.GetCurrentProcess().ProcessName;

            this.counters.Add(
                new PerformanceCounter("Process", "Working Set", this.processName)
            );
        }

        public string MakeHeaders()
        {
            string header = "";
            header += "ProcessMemory(WorkingSet) " + this.processName;
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
