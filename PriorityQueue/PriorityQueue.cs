using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class PriorityQueue<T> : IPriorityQueue<T> where T : IPriority<T>
    {
        private LinkedList<T> _list;
        private IOutput _writer;


        public PriorityQueue(IOutput writer)
        {
            _list = new LinkedList<T>();
            _writer = writer;
        }

        /// <summary>
        /// Добавляет элемент в очередь с учётом его приоритета
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            
            if (_list.IsEmpty)
            {
                _list.AddToHead(item);
            }
            else
            {
                // Если приоритет выше первого элемента
                if (PriorityRule(item, _list.First()))
                {
                    _list.AddToHead(item);
                }
                else
                {
                    T prev = _list.First();

                    foreach (var elem in _list)
                    {
                        // Если больше текущего, то вставить после предыдущего
                        if (PriorityRule(item, elem))
                        {
                            _list.AddAfter(prev, item);
                            return;
                        }
                        prev = elem;
                    }
                    // Добавить в конец
                    _list.AddToTail(item);
                }
            }
        }

        /// <summary>
        /// Извлекает самый приоритетный элемент очереди 
        /// </summary>
        public T Extract()
        {
            if (!_list.IsEmpty)
            {
                var first = _list.First();
                _list.Remove(first);

                return first;
            }
            else
            {
                throw new Exception("Очередь пуста.");
            }
        }


        private bool PriorityRule(T first, T second)
        {
            return first.GetPriority() > second.GetPriority();
        }

        public void DisplayAll()
        {
            if (!_list.IsEmpty)
            {
                foreach (var elem in _list)
                {
                    _writer.Write(elem.ToString());
                }
            }
            else
            {
                _writer.Write("Элементов в очереди нет.");
            }
        }
    }
}
