using System;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            while (true)
            {
                Console.Write("Enter:" +
                                 "\n 1:To enter new student" +
                                 "\n 2:To print the students" +
                                 "\n 3:To Exite");
                int c = Convert.ToInt32(Console.ReadLine());
                switch (c)
                {
                    case 1:
                        var student = Student.Insert();
                        list.Insert(student);
                        break;

                    case 2:
                        list.Print();
                        break;

                    case 3: break;
                }
                if (c == 3)
                    break;
            }

        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double FirstExample { get; set; }
        public double SecoundExample { get; set; }
        public string Grade { get; private set; }
        public double Avreage { get; private set; }
        public void CalucAvrege()
        {
            Avreage = (FirstExample + SecoundExample) / 2;
            if (Avreage <= 60)
            {
                Grade = "راسب";
            }
            else if (Avreage >= 80 && Avreage >= 100)
            {
                Grade = "ممتاز";
            }
            else if (Avreage >= 70 && Avreage >= 80)
            {
                Grade = "جيد جدا";
            }
            else if (Avreage >= 60 && Avreage >= 70)
            {
                Grade = "جيد";
            }
        }
        public static Student Insert()
        {
            Console.WriteLine("Enter Number");
            int Number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the name");
            string Name = Console.ReadLine();

            Console.WriteLine("Enter Firest Mark");
            double FirstMark = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Secound Mark");
            double SecoundMark = Convert.ToDouble(Console.ReadLine());

            var student = new Student
            {
                Id = Number,
                Name = Name,
                SecoundExample = SecoundMark,
                FirstExample = FirstMark,
            };

            student.CalucAvrege();
            return student;
        }
        public override string ToString()
        {
            return $"Name:{Name}\n" +
                   $"FirstExample:{FirstExample}\n" +
                   $"SecoundExample:{SecoundExample}\n" +
                   $"Avreage: {Avreage}\n" +
                   $"Grade:{Grade}\n";
        }
    }
    public class Node
    {
        public Node Next { get; set; }
        public Student Data { get; set; }
    }
    public class LinkedList
    {
        public Node First { get; set; }
        public void Insert(Student student)
        {
            Node newNode = new Node { Data = student };
            if (First == null || First.Data.Avreage >= student.Avreage)
            {
                newNode.Next = First;
                First = newNode;
            }
            else
            {
                Node current = First;
                while (current.Next != null && current.Next.Data.Avreage < student.Avreage)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }
        }
        public void Print()
        {
            var node = First;
            while (node != null)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
        }
    }
}
