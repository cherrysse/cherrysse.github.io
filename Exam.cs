using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloiseLab2
{
    internal class Exam : IDateAndCopy
    {
        public string Subject { 
            get;
            set;
        }
        public int Mark { 
            get;
            set;
        }
        public System.DateTime ExamDate { 
            get;
            set;
        }


        public Exam(string subject, int marks, DateTime examDate) //Конструктор  с  параметрами  типа  string,  int  и  DateTime  для  инициализации  всех свойств класса
        {
            Subject = subject;
            Mark = marks;
            ExamDate = examDate;
        }
        public Exam() //Конструктор без параметров, инициализирующий все свойства класса некоторыми значениями по умолчанию
        {
            Subject = "Default_subject";
            Mark = 0;
            ExamDate = DateTime.Now;
        }

        public override string ToString() //Перегруженная версия  виртуального  метода  string  ToString()  для формирования строки со значениями всех свойств класса; 
        {
            return string.Format("{0}:\n Mark = {1}.\n Date = {2}", Subject, Mark, ExamDate);
        }

        public object DeepCopy()
        {
            return new Exam(Subject, Mark, ExamDate);
        }

        DateTime IDateAndCopy.Date  //Реализовать интерфейс IDateAndCopy
        {
            get { 
                return ExamDate; 
            }
            set { 
                ExamDate = value;
            }

        }
    

    }
}
