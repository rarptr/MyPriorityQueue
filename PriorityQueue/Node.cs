using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    /// <summary>
    /// Узел списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }
        /// <summary>
        /// Данные узла
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Ссылка на соседний узел
        /// </summary>
        public Node<T> Next { get; set; }
    }
}
