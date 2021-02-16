using System;
using System.Collections.Generic;

namespace Task_3
{
    namespace A
    {
        class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data)
            {
                Data = data;
            }
            public override string ToString()
            {
                return $"{Data}";
            }
        }

        class LinkedList
        {
            Node head;
            Node tail;

            public int Count { get; set; }

            public void Add(int data)
            {
                Node node = new Node(data);
                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;
                Count++;
            }
            public void AddFirst(int data)
            {
                Node node = new Node(data);

                node.Next = head;
                head = node;

                if (Count == 0)
                    tail = head;

                Count++;
            }
            public void Clear()
            {
                Count = 0;
                head = null;
                tail = null;
            }
            public bool Contains(int data)
            {
                Node current = head;
                while (current != null)
                {
                    if (current.Data == data)
                        return true;
                    current = current.Next;
                }
                return false;
            }
            public void Print()
            {
                Node current = head;
                int i = 1;
                while (current != null)
                {
                    Console.WriteLine($"{i} - {current}");
                    current = current.Next;
                    i++;
                }
            }

            public Node Max()
            {
                Node current = head;
                Node maxNode = null;
                if (current != null)
                {
                    while (current != null)
                    {
                        if (current.Data > maxNode.Data)
                            maxNode = current;
                        current = current.Next;
                    }
                    return maxNode;
                }
                else
                    return null;
                
            }

            public Node Min()
            {
                Node current = head;
                Node minNode = null;
                if (current != null)
                {
                    while (current != null)
                    {
                        if (current.Data < minNode.Data)
                            minNode = current;
                        current = current.Next;
                    }
                    return minNode;
                }
                else
                    return null;
            }

            public Node Middle()
            {
                // 1 2 3 4 5 6 7 -> 4
                // 1 2 3 4 5 6 -> 4
                int index = Count / 2;
                int pointer = 0;
                Node current = head;
                while (current != null)
                {
                    if (pointer == index)
                        return current;
                    current = current.Next;
                    pointer++;
                }
                return null;
            }

            public bool Remove(int data)
            {
                // 1 2 3 4 5 6 7 8 5, 5 -> 1 2 3 4 6 7 8 5
                // если список пуст, если список из 1 элемента, если удаляемый элемент стоит в середине, в конце, в начале
                if (Count == 0)
                    return false;
                else if (Count == 1)
                {
                    Clear();
                    return true;
                }
                else
                {
                    int pointer = 0;
                    Node current = head;
                    while (current != null)
                    {
                        if (current.Data == data)
                            break;
                        current = current.Next;
                        pointer++;
                    }

                }
                return false;
            }
        }

        class MainClass
        {
            public static void Main()
            {
                LinkedList linkedList = new LinkedList();
                linkedList.Add(1);
                linkedList.Add(2);
                linkedList.AddFirst(3);
                linkedList.Add(4);
                linkedList.Print();

            }
        }
    }
}
