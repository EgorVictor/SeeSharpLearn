using System;
using System.Collections.Generic;

namespace GenericClassInCSharp
{
    //使用泛型实现简单的迭代器
    public class GenericList<T>
    {
        private class Node
        {
            public Node(T t)
            {
                Next = null;
                Data = t;
            }
            public Node Next { get; init; }
            public T Data { get; }
        }

        private Node _head;

        public GenericList()
        {
            _head = null;
        }

        public void AddHead(T t)
        {
            Node n = new Node(t) {Next = _head};
            _head = n;
        }

      
        public IEnumerator<T> GetEnumerator()
        {
            Node current = _head;
            while (current!=null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        internal static void TestGenericList()
        {
            GenericList<int> list = new GenericList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddHead(i);
            }

            foreach (var item in list)
            {
                Console.WriteLine(item+" ");
            }
            System.Console.WriteLine("\nDone");
        }


    }
}
