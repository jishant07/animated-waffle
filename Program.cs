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
            if(this.front == -1 && this.rear == -1)
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
        public void enqueue(string input, int inputPriority)
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

            myCircularLinkedList.enqueue("Test", 1);
            myCircularLinkedList.enqueue("Test3", 3);
            myCircularLinkedList.enqueue("Test4", 4);
            myCircularLinkedList.enqueue("Test2", 2);
            myCircularLinkedList.PrintAll();

            /*int choice = 1;
            while (choice != 4) // Exit at 4
            {
                Console.WriteLine("1. Add new Patient");
                Console.WriteLine("2. Remove Patient (Dequeue)");
                Console.WriteLine("3. Print Pateints(Print all)");
                choice = Convert.ToInt32(Console.ReadLine());
                //use switch
                if (choice == 1)
                {
                    Console.WriteLine("Enter Name");
                    string inputString = Console.ReadLine();
                    Console.WriteLine("Enter priority");
                    int pr = Convert.ToInt32(Console.ReadLine());
                    PatientData tempPatient = new PatientData(inputString, pr); // check if priority is between 1-5
                    myArrayCircularQueue.enqueue(tempPatient);
                    Console.WriteLine("printLineee");
                    myArrayCircularQueue.PrintAll();
                }
                else if (choice == 2)
                {
                    // check here if the queueu is empty then dont dequeue
                    PatientData temp = myArrayCircularQueue.dequeue();
                    Console.WriteLine("Dequeued");
                    temp.printPatientData();
                }
                else if (choice == 3)
                {
                    myArrayCircularQueue.PrintAll();
                }
            }*/


            // Console.WriteLine("Hello world");
            // for (int i = 0; i < 5; i++)
            // {
            //     Console.WriteLine("Data for Patient");
            //     string inputString = Console.ReadLine();
            //     PatientData tempPatient = new PatientData(inputString,i);
            //     myArrayCircularQueue.enqueue(tempPatient);
            //     Console.WriteLine("printLineee");
            //     myArrayCircularQueue.PrintAll();
            // }
            // myArrayCircularQueue.PrintAll();
            // Console.WriteLine("Starting Dequeue");
            // for (int i = 0; i < 5; i++)
            // {
            //     PatientData temp = myArrayCircularQueue.dequeue();
            //     Console.WriteLine("Dequeued");
            //     temp.printPatientData();
            // }
        }
    }
}