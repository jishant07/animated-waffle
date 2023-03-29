using System;
using System.Globalization;

namespace CircularPriorityQueue
{
    class PatientData
    {
        private String first_name { get; set; }
        private String last_name { get; set; }
        private int age { get; set; }
        private int priority { get; set; }
        // Default constructor for Patient Data.
        public PatientData(Boolean isNull)
        {
            if (!isNull)
            {
                Console.WriteLine("Enter Patient's First Name:");
                this.first_name = Console.ReadLine();
                Console.WriteLine("Enter Patient's Second Name:");
                this.last_name = Console.ReadLine();
                Console.WriteLine("Enter Patient's Age:");
                this.age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Emergency Level:");
                this.priority = Convert.ToInt32(Console.ReadLine());
            }
        }
        // Print Object Data
        public void printPatientData()
        {
            Console.WriteLine("*** Patient Data Print *** ");
            Console.WriteLine("First Name => " + this.first_name);
            Console.WriteLine("Last Name => " + this.last_name);
            Console.WriteLine("Age => "+ this.age.ToString());
            Console.WriteLine("Priority Patient : " + this.priority.ToString());
        }
        // Gets the "emergencyLevel" or Priority of the Patient
        public int getPriority()
        {
            return this.priority;
        }
    }
    // Class that has all the methods and attributes necessary for
    // CircularArrayQueue
    class ArrayCircularQueue
    {
        //Capacity of the CircularArrayQueue
        private int capacity;
        private PatientData[] ele;
        private int front = -1;
        private int rear = -1;
        // Default Constructor
        public ArrayCircularQueue()
        {
            this.capacity = 20;
            this.ele = new PatientData[this.capacity];
        }
        // Parameterised Constructor
        public ArrayCircularQueue(int capacity)
        {
            this.capacity = capacity;
            this.ele = new PatientData[this.capacity];
        }
        // Functions to add data to the Queue
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
        // Removing one Patient from the Queue
        public PatientData dequeue()
        {
            if (this.front == -1)
            {
                Console.WriteLine("Empty Queue");
                return new PatientData(true);
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
        // Print all Patients in the Queue
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
        // Delete all the patients
        public void DeleteAll()
        {
            this.front = -1;
            this.rear = -1;
        }
        // Returns the length of the Queue
        public int lengthOfQueue()
        {
            if (this.rear == -1 || this.front == -1)
            {
                return 0;
            }
            return this.rear - this.front + 1;
        }
        // This is to be called, when priority needs to be set
        // according to the emergencyLevel(Priority)
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
        // Returns result if the Queue is Full.
        bool checkIfFull()
        {
            if (((this.rear + 1) % this.capacity) == this.front)
            {
                return true;
            }
            return false;
        }
    }

    // Queue Node
    class QueueNode
    {
        public QueueNode? next = null;
        public PatientData? data = null;
        public int priority = -1;
    }
    // Circular Linked List Methods and Attributes
    class CircularLinkedList
    {
        QueueNode? front;
        QueueNode? back;
        // Default Constructor
        public CircularLinkedList()
        {
            this.front = null;
            this.back = null;
        }
        // Add Patient Data to the Queue
        public void enqueue(PatientData input)
        {
            QueueNode newNode = new QueueNode();
            newNode.data = input;
            newNode.next = null;
            if(this.front == null)
            {
                this.front = newNode;
                this.back = this.front;
                this.back.next = this.front;
            }
            else
            {
                this.back.next = newNode;
                this.back = newNode;
                this.back.next = this.front;
            }
            sequenceQueue();
        }
        // Call when the queue is needed to set in Priority.
        public void sequenceQueue()
        {
            QueueNode? current = this.front;
            if(current == null)
            {
                return ;
            }
            while (current?.next!=null)
            {
                QueueNode next = current.next;
                if(next.priority>current.priority)
                {
                    //Data type change here
                    PatientData tempData = current.data;
                    int tempPriority = current.priority;
                    current.data = next.data;
                    current.priority = next.priority;
                    next.data = tempData;
                    next.priority = tempPriority;
                }
                current = current.next;
                //Circular queue break if current comes back to front
                if(current == this.front)
                {
                    break;
                }
            }
        }
        // Remove Patient node from the Linked List
        public PatientData dequeue()
        {
            if(this.front == null)
            {
                Console.WriteLine("Empty Queue");
            }
            else if(this.front ==  this.back)
            {
                PatientData returnString = this.front.data;
                this.front = null;
                this.back = null;
                return returnString;
            }
            else
            {
                PatientData returnString = this.front.data;
                this.front = this.front.next;

                if(this.front == null)
                {
                    this.back = null;
                }
                return returnString;
            }
            return new PatientData(false);
        }
        // Print The Entire Linked List
        public void PrintAll()
        {
            Console.WriteLine("*** Current Linked List ***");
            if (this.front == null)
            {
                Console.WriteLine("Empty Queue");
            }
            else
            {
                int index = 0;
                QueueNode temp = this.front;
                while(temp != null)
                {
                    Console.WriteLine(index);
                    temp.data.printPatientData();
                    temp = temp.next;
                    if(temp==this.front)
                    {
                        break;
                    }
                    index++;
                }
            }
        }
        // Reset the Linked List
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
                        PatientData newPatient = new PatientData(false);
                        myArrayCircularQueue.enqueue(newPatient);
                        myCircularLinkedList.enqueue(newPatient);
                        break;
                    case 2:
                        PatientData circularDequeue = myArrayCircularQueue.dequeue();
                        circularDequeue.printPatientData();
                        PatientData linkedListDequeue = myCircularLinkedList.dequeue();
                        linkedListDequeue.printPatientData();
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
