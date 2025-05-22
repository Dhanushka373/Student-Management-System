using System;

class Student
{
    public int IndexNumber { get; set; }
    public string Name { get; set; }
    public double GPA { get; set; }
    public int AdmissionYear { get; set; }
    public string NIC { get; set; }

    public Student(int index, string name, double gpa, int year, string nic)
    {
        IndexNumber = index;
        Name = name;
        GPA = gpa;
        AdmissionYear = year;
        NIC = nic;
    }

    public override string ToString()
    {
        return $"Index: {IndexNumber}, Name: {Name}, GPA: {GPA}, Year: {AdmissionYear}, NIC: {NIC}";
    }
}

class Node
{
    public Student Data;
    public Node Next;
    public Node(Student student) { Data = student; Next = null; }
}

class SinglyLinkedList
{
    private Node head;

    public void Insert(Student student)
    {
        if (Search(student.IndexNumber) != null)
        {
            Console.WriteLine("Student with this index already exists.");
            return;
        }

        Node newNode = new Node(student);
        if (head == null || student.IndexNumber < head.Data.IndexNumber)
        {
            newNode.Next = head;
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.Next != null && current.Next.Data.IndexNumber < student.IndexNumber)
                current = current.Next;
            newNode.Next = current.Next;
            current.Next = newNode;
        }
        Console.WriteLine("Student inserted.");
    }

    public Student Search(int index)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.IndexNumber == index)
                return current.Data;
            current = current.Next;
        }
        return null;
    }

    public void Remove(int index)
    {
        if (head == null) { Console.WriteLine("List is empty."); return; }
        if (head.Data.IndexNumber == index) { head = head.Next; Console.WriteLine("Student removed."); return; }

        Node current = head;
        while (current.Next != null && current.Next.Data.IndexNumber != index)
            current = current.Next;

        if (current.Next == null) Console.WriteLine("Student not found.");
        else { current.Next = current.Next.Next; Console.WriteLine("Student removed."); }
    }

    public void PrintAll()
    {
        if (head == null) { Console.WriteLine("No students to display."); return; }
        Node current = head;
        while (current != null) { Console.WriteLine(current.Data); current = current.Next; }
    }
}

class Program
{
    static void Main()
    {
        SinglyLinkedList list = new SinglyLinkedList();
        int choice;

        do
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1. Insert Student");
            Console.WriteLine("2. Search Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Print All Students");
            Console.WriteLine("5. Exit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Index Number: ");
                    int index = int.Parse(Console.ReadLine());
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("GPA: ");
                    double gpa = double.Parse(Console.ReadLine());
                    Console.Write("Admission Year: ");
                    int year = int.Parse(Console.ReadLine());
                    Console.Write("NIC: ");
                    string nic = Console.ReadLine();
                    list.Insert(new Student(index, name, gpa, year, nic));
                    break;

                case 2:
                    Console.Write("Enter Index to Search: ");
                    int search = int.Parse(Console.ReadLine());
                    Student found = list.Search(search);
                    Console.WriteLine(found != null ? $"Found: {found}" : "Student not found.");
                    break;

                case 3:
                    Console.Write("Enter Index to Remove: ");
                    int remove = int.Parse(Console.ReadLine());
                    list.Remove(remove);
                    break;

                case 4:
                    list.PrintAll();
                    break;

                case 5:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        } while (choice != 5);
    }
}
