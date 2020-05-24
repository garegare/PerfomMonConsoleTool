using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PerfomMonConsoleTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var processNames = args;

            if (processNames.Length == 0)
            {
                Console.WriteLine("You must input args(target process name) this program. ");
                return;
            }

            List<ICounter> counterList = new List<ICounter>()
            {
                new ProcessorCounterTotal(),
                new ProcessorCounter(),
                new MemoryCounter(),
            };

            foreach (var name in processNames)
            {
                counterList.Add(new ProcessMemoryCounter(name));
                counterList.Add(new ProcessMemoryPrivateCounter(name));
                counterList.Add(new ProcessCpuCounter(name));
            }

            var headers = new StringBuilder();
            foreach (var counter in counterList)
            {
                headers.AppendFormat("{0}, ", counter.MakeHeaders());
            }
            Console.WriteLine(headers.ToString());

            var bodies = new StringBuilder();
            while (true)
            {
                foreach (var counter in counterList)
                {
                    bodies.AppendFormat("{0}, ", counter.MakeBodies());
                }
                Console.WriteLine(bodies.ToString());
                bodies.Clear();
                Thread.Sleep(1000);
            }
        }
    }
}
