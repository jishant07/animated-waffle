using System;
using System.Globalization;

namespace CircularPriorityQueue
{
    class ArrayCircularQueue
    {
        private int capacity;
        public ArrayCircularQueue()
        {
            this.capacity = 20;
        }
        public ArrayCircularQueue(int capacity)
        {
            this.capacity = capacity;
        }

        public void enqueue(String input, int inputPriority)
        {

        }
        public String dequeue()
        {
            return "";
        }
        public void PrintAll()
        {

        }
        public void DeleteAll()
        {

        }
    }

    class QueueNode
    {
        public QueueNode? front = null;
        public QueueNode? back = null;
        public String? data = null;
    }

    class CircularLinkedList
    {
        CircularLinkedList()
        {
            QueueNode? front = null;
            QueueNode? back = null;
        }
        public void enqueue(string input, int inputPriority) 
        {

        }
        public String dequeue() 
        {
            return "";
        }

        public void PrintAll()
        {

        }
        public void DeleteAll()
        {

        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            ArrayCircularQueue myArrayCircularQueue = new ArrayCircularQueue();
            CircularLinkedList myCircularLinkedList = new CircularLinkedList();

            Console.WriteLine("Hello world");
        }
    }
}