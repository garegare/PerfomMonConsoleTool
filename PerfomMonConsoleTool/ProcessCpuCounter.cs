using System.Collections.Generic;
using System.Diagnostics;

namespace PerfomMonConsoleTool
{
    class ProcessCpuCounter : CounterBase, ICounter
    {
        internal override List<PerformanceCounter> counters { get; set; } = new List<PerformanceCounter>();
        private string processName = "";

        public ProcessCpuCounter(string processName = null)
        {
            this.processName = processName ?? Process.GetCurrentProcess().ProcessName;
            this.counters.Add(
                new PerformanceCounter("Process", "% Processor Time", this.processName)
            );
        }

        public string MakeHeaders()
        {
            string header = "";
            header += "ProcessTime(Total) " + this.processName;
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
