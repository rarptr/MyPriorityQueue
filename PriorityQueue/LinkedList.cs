using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    /// <summary>
    /// Односвязный список
    /// </summary>
    public class LinkedList<T> : IEnumerable<T>
    {
        public int Count { get { return _count; } }
        public bool IsEmpty { get { return _count == 0; } }

        private Node<T> _head; 
        private Node<T> _tail;
        private int _count; 

        /// <summary>
        /// Добавляет элемент в начало списка
        /// </summary>
        public void AddToHead(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = _head;
            _head = node;
            if (_count == 0)
            {
                _tail = _head;
            }
            _count++;
        }

        /// <summary>
        /// Добавляет элемент после заданного элемента списка
        /// </summary>
        public void AddAfter(T onEdge, T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> curr = _head;
            Node<T> prev = null;

            while (curr != null)
            {
                if (curr.Data.Equals(onEdge))
                {
                    node.Next = curr.Next;
                    curr.Next = node;

                    // Если вставляли после хвоста
                    if (curr.Data.Equals(_tail.Data))
                    {
                        _tail = node;
                    }
                    _count++;
                    return;
                }
                curr = curr.Next;
            }
        }

        /// <summary>
        /// Добавляет элемент в конец списка
        /// </summary>
        public void AddToTail(T data)
        {
            Node<T> node = new Node<T>(data);

            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
            }
            _tail = node;
            _count++;
        }

        /// <summary>
        /// Удаляет элемента списка
        /// </summary>
        public bool Remove(T data)
        {
            Node<T> curr = _head;
            Node<T> prev = null;

            while (curr != null)
            {
                if (curr.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (prev != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        prev.Next = curr.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (curr.Next == null)
                        {
                            _tail = prev;
                        }
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        _head = _head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    _count--;
                    return true;
                }

                prev = curr;
                curr = curr.Next;
            }
            return false;
        }

        /// <summary>
        /// Очистка списка (обьекты из памяти очищает GC)
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        // содержит ли список элемент
        public bool Contains(T data)
        {
            Node<T> current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        // реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
