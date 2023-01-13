using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singly_linked_list
{

    class Node
    {
        public int rollNumber;
        public string name;
        public string Gender;
        public string Class;
        public string HomeTown;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNote()
        {
            int nim;
            string nm;
            string gndr;
            string Clss;
            string HT;
            Console.Write("\nEnter The roll Number Of The Student :     ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter The Name Of The Student :            ");
            nm = Console.ReadLine();
            Console.Write("\nEnter The Gender of The Student (L / P) :  ");
            gndr = Console.ReadLine();
            Console.Write("\nEnter The CLass Of Student ( A,B,C,D) :    ");
            Clss = Console.ReadLine();
            Console.Write("\nEnter The Home Town Of Student :           ");
            HT = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = nim;
            newnode.name = nm;
            newnode.Gender = gndr;
            newnode.Class = Clss;
            newnode.HomeTown = HT;
            if (START == null || nim <= START.rollNumber)
            {
                if ((START != null) && (nim == START.rollNumber))
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
            Node Previous, current;
            Previous = START;
            current = START;

            while ((current != null) && (nim >= current.rollNumber))
            {
                if (nim == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }
                Previous = current;
                current = current.next;
            }
            newnode = current;
            Previous.next = newnode;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty.\n");
            else
            {
                Console.WriteLine("\nThe records in the list are : ");
                Node CurrentNode;
                for (CurrentNode = START; CurrentNode != null;
                    CurrentNode = CurrentNode.next) ;

                Console.Write(CurrentNode.rollNumber + " " + CurrentNode.name + "\n" + CurrentNode.Gender + "\n"
                    + CurrentNode.Class + "\n" + CurrentNode.HomeTown + "\n");

                Console.WriteLine();
            }
        }
        public bool delNode(string HT)
        {
            Node previous, current;
            previous = current = null;
            if (Search(HT, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;
        }
        public bool Search(string HT, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (HT != current.HomeTown))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. Add a record to the list ");
                    Console.WriteLine("2. Delete a record from the list ");
                    Console.WriteLine("3. View all the records in the list ");
                    Console.WriteLine("4. Search for a second in the list ");
                    Console.WriteLine("5. EXIT");
                    Console.Write("\nEnter your choice (1-5) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the HomeTown Of the Student" + "the student whose record is to be deleted :");
                                string HT = Console.ReadLine();
                                Console.WriteLine();
                                if (obj.delNode(HT) == false)
                                    Console.WriteLine("\n Record not found.");
                                else
                                    Console.WriteLine("Record with roll number " + HT + "Deleted");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nEnter the HomeTown of the Student " + "student whose record is to be searched: ");
                                string HT = Console.ReadLine();
                                if (obj.Search(HT, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found. ");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + current.rollNumber);
                                    Console.WriteLine("\nName: " + current.name);
                                    Console.WriteLine("\nGender: " + current.Gender);
                                    Console.WriteLine("\nClass: " + current.Class);
                                    Console.WriteLine("\nHomeTown: " + current.HomeTown);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nCheck for the value entered");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("\nCheck for the value entered ");
                }
            }
        }
    }
}

// 2. Single Linked list, Karena data yang dimasukan perlu menggunakan operasi delete, search and traversal, kegunaan single linked list juga
//    dapat membantu mencari data yang sama dengan mudah.
// 3. Double linked list, Des
// 4. A) Array : Mencari dan menyusun elemen yang sudah pasti nilainya
//    B) Linked List : Mencari barang atau nama yang akan dicari
// 5. A) Parent : 10, 30, 25
//       Children : 5, 12, 16, 20, 28
//    B) Inorder : 10,12,10,18,15,5,15,10,20,25,28,20,20,32,30,20