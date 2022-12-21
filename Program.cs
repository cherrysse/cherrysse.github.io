using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

// Рыбко Элоиза БСБО-15-21 
// 2 лабораторная
// 1 вариант


enum Education { Bachelor, Specialist, SecondEducation }
namespace EloiseLab2
{
    class Program
    {
        static void Main(string[] args)
        {

            var A = new Person("Stupid", "Liza", new DateTime(1987, 02, 11)); // два объекта типа персон
            var B = new Person("Stupid", "Liza", new DateTime(1987, 02, 11));
            //1
            Console.WriteLine("By links: ");
            Console.WriteLine(Object.ReferenceEquals(B, A));
            Console.WriteLine("By values: ");
            Console.WriteLine(A == B);
            Console.WriteLine("============================================================================================");
            Console.ReadKey();

            Console.WriteLine("Hash: \n 1:\n {0}  \n 2:\n {1}", A.GetHashCode(), B.GetHashCode());
            Console.WriteLine("============================================================================================");
            Console.ReadKey();
            
            Student student = new(new Person("Eloise", "Rybko", new DateTime(2003, 12, 25)), Education.Specialist, 15);// объект типа студент и сделать список экзамено и зачетов и вывести значение типа персон для студент
           
            student.AddExams(new Exam("Math", 3, new DateTime(2022, 11, 29)));
            student.AddTests(new Test("Hist", true));
            student.AddExams(new Exam("Alg", 5, new DateTime(2022, 09, 11)));
            student.AddTests(new Test("Deut", true));
            student.AddExams(new Exam("Sety", 4, new DateTime(2022, 07, 05)));
            //2
            Console.WriteLine("To string student:\n");

            Console.WriteLine(student.ToString());
            Console.WriteLine("============================================================================================");
            Console.ReadKey();
            //4
            Console.WriteLine("Person student:\n");

            Console.WriteLine(student.Person);
            Console.WriteLine("\n");
            Console.WriteLine("============================================================================================");
            Console.ReadKey();
            //5
            Console.WriteLine("Making a copy...");
            Console.WriteLine("Changing data...");
            Console.WriteLine("============================================================================================");
            Console.ReadKey();
            Console.WriteLine("\n");

            Student studentClone = (Student)student.DeepCopy();
            
            student.Name = "Lizok";
            student.Surname = "Cherry";
            //6
            Console.WriteLine("New:");
            Console.WriteLine(student.ToString());

            Console.WriteLine("Old:");
            Console.WriteLine(studentClone.ToString());
            Console.ReadKey();
            //7
            Console.WriteLine("\n");
            Console.WriteLine("============================================================================================");
            Console.WriteLine("Group change:");
            try // присвоить свойству с номером группы неккоректное зачение
            {
                student.GroupNumber = 12345; 
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("============================================================================================");
            Console.ReadKey();
            //8
            foreach (var task in student.GetResults()) // список всех зачетов и экз
                Console.WriteLine(task.ToString());

            Console.WriteLine("============================================================================================");

            foreach (var task in student.GetExamsResults(3)) // экзамены выше 3 список
                Console.WriteLine(task.ToString());
            Console.ReadKey();

        }
    }
}