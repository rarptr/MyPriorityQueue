using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public interface IPriorityQueue<T>
    {
        void Add(T item);

        T Extract();
        
        void DisplayAll();
    }
}
