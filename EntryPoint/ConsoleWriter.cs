using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriorityQueue;

namespace EntryPoint
{
    internal class ConsoleWriter : IOutput
    {
        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }
}
