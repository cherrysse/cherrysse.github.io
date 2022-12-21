using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloiseLab2
{
    internal class Test //класс тест имеет два открытых свойства, доступных для чтения и записи
    {
        public string subject { // свойство типа стринг в котором храниться название предмета
            get; 
            set;
        }
        public bool isPassed { // свойство типа бул для информации сдан зачет или нет
            get;
            set; 
        }

        public Test(string subject, bool isPassed) //констр без парам с знач по умолчанию
        {
            this.subject = subject;
            this.isPassed = isPassed;
        }

        public Test()  // констр с парам
        {
            this.subject = "Predmet";
            this.isPassed = false;
        }

        public override string ToString() //определить перегруженную оверрайд версию виртуал метода стринг для формирования строки со значениями всех свойств класса
        {
            return string.Format("{0}: \n Is Passed: {1}", subject, isPassed);
        }

        public object DeepCopy()
        {
            return new Test(subject, isPassed);
        }

    }
}
