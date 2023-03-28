using System;
using System.Globalization;

namespace CircularPriorityQueue
{
    class PatientData
    {
        public string? name;
        public int priority = 0;
        public PatientData(String name, int pr)
        {
            this.name = name;
            this.priority = pr;
        }
        public void printPatientData()
        {
            Console.WriteLine("Patient Name: " + this.name);
            Console.WriteLine("Priority Patient : " + this.priority.ToString());
        }
        public int getPriority()
        {
            return this.priority;
        }
    }
    class ArrayCircularQueue
    {
        private int capacity;
        private PatientData[] ele;
        private int front = -1;
        private int rear = -1;
        public ArrayCircularQueue()
        {
            this.capacity = 20;
            this.ele = new PatientData[this.capacity];
        }
        public ArrayCircularQueue(int capacity)
        {
            this.capacity = capacity;
            this.ele = new PatientData[this.capacity];
        }

        public void enqueue(PatientData newPateint)
        {
            if (this.checkIfFull())
            {
                Console.Write("Array is full");
                return;
            }
            if (this.front == -1)
            {
                this.front += 1;
            }
            this.rear = (this.rear + 1) % this.capacity;
            ele[this.rear] = newPateint;
            this.sequenceQueue();
        }
        public PatientData dequeue()
        {
            if (this.front == -1)
            {
                Console.WriteLine("Empty Queue");
                return new PatientData("NULL", -1);
            }
            else
            {
                PatientData returnPatient = this.ele[this.front];
                if (this.front == this.rear)
                {
                    this.front = -1;
                    this.rear = -1;
                }
                else
                {
                    this.front = (this.front + 1) % this.capacity;
                }
                return returnPatient;
            }

        }
        public void PrintAll()
        {
            Console.WriteLine("*** Current Circular Array ***");
            if (this.front == -1 && this.rear == -1)
            {
                Console.WriteLine("Empty Queue");
            }
            else
            {
                for (int i = this.front; i <= this.rear; i++)
                {
                    Console.WriteLine(i);
                    this.ele[i].printPatientData();
                }
            }
        }
        public void DeleteAll()
        {

        }
        public int lengthOfQueue()
        {
            if (this.rear == -1 || this.front == -1)
            {
                return 0;
            }
            return this.rear - this.front + 1;
        }
        void sequenceQueue()
        {
            if (this.lengthOfQueue() < 2)
            {
                return;
            }
            int last = this.rear;
            while (last > this.front)
            {
                if (this.ele[last].getPriority() > this.ele[last - 1].getPriority())
                {
                    PatientData tempSwap = this.ele[last];
                    this.ele[last] = this.ele[last - 1];
                    this.ele[last - 1] = tempSwap;
                }
                else
                {
                    break;
                }
                last -= 1;
            }
            // To be called to bring the item with higher priority above
        }
        bool checkIfFull()
        {
            if (((this.rear + 1) % this.capacity) == this.front)
            {
                return true;
            }
            return false;
        }
    }


    class QueueNode
    {
        public QueueNode? next = null;
        public String? data = null;
        public int priority = -1;
    }

    class CircularLinkedList
    {
        QueueNode? front;
        QueueNode? back;
        public CircularLinkedList()
        {
            this.front = null;
            this.back = null;
        }
        public void enqueue(String input, int inputPriority)
        {
            QueueNode newNode = new QueueNode();
            newNode.data = input;
            newNode.priority = inputPriority;
            newNode.next = null;
            if(this.front == null)
            {
                this.front = newNode;
                this.back = this.front;
            }
            else
            {
                QueueNode? current = this.front;
                while (current?.next != null && newNode.priority < current.priority)
                {
                    current = current.next;
                }
                if(current.next == null)
                {
                    current.next = newNode;
                }
                else
                {
                    newNode.next = current.next;
                    current.next = newNode;
                }
            }
        }
        public String dequeue()
        {
            if(this.front == null)
            {
                Console.WriteLine("Empty Queue");
            }
            else
            {
                String returnString = front.data;
                this.front = this.front.next;

                if(this.front == null)
                {
                    this.back = null;
                }
                return returnString;
            }
            return "";
        }

        public void PrintAll()
        {
            Console.WriteLine("*** Current Linked List ***");
            if (this.front == null)
            {
                Console.WriteLine("Empty Queue");
            }
            else
            {
                QueueNode temp = this.front;
                while(temp != null)
                {
                    Console.WriteLine(temp.data);
                    temp = temp.next;
                }
            }
        }
        public void DeleteAll()
        {
            this.front = null;
            this.back = null;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            ArrayCircularQueue myArrayCircularQueue = new ArrayCircularQueue();
            CircularLinkedList myCircularLinkedList = new CircularLinkedList();

            int ch;

            do
            {
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. Remove Patient");
                Console.WriteLine("3. Print All Patients");
                Console.WriteLine("4. Delete All Patients");
                Console.WriteLine("0. To Exit The Loop");

                ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        myArrayCircularQueue.enqueue(new PatientData("Test", 1));
                        myCircularLinkedList.enqueue("Test", 1);
                        break;
                    case 2:
                        myArrayCircularQueue.dequeue();
                        myCircularLinkedList.dequeue();
                        break;
                    case 3:
                        myArrayCircularQueue.PrintAll();
                        myCircularLinkedList.PrintAll();
                        break;
                    case 4:
                        myArrayCircularQueue.DeleteAll();
                        myCircularLinkedList.DeleteAll();
                        break;
                    default:
                        Console.WriteLine("Incorrect Option, Please Try Again");
                        break;
                }

            } while (ch != 0);
        }
    }
}