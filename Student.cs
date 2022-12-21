using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EloiseLab2
{
    internal class Student : Person, IDateAndCopy
    {
        private Person _person; 
        private Education _education; //закрытое поле для информации о форме обучения
        private int _groupNumber; // для номера группы
        private ArrayList _exams; //для списка экзаменов
        private ArrayList _tests; // для списка зачетов
        public Student(Person person, Education education, int groupNumber) //констр с пар
        {
            _person = person;
            _education = education;
            _groupNumber = groupNumber;
            _exams = new ArrayList();
            _tests = new ArrayList();
        }
        public Student() //констр без пар
        {
            _person = new Person();
            _education = Education.Specialist;
            _groupNumber = 1;
            _exams = new ArrayList();
            _tests = new ArrayList();
        }

        public Person Person {
            get {
                return _person;
            }
            set { _person = value;
            }
        } // метод гет свойства возвращает объект сет присваивает значения из подоъекта
        public Education Education {
            get {
                return _education;
            }
            set {
                _education = value;
            }
        }
        public ArrayList Exams {
            get {
                return _exams;
            } 
            set { 
                _exams = value; 
            }
        }
        public ArrayList Tests {
            get { 
                return _tests;
            }
            set {
                _tests = value;
            }
        }

        new public string Name { 
            get { 
                return Person.Name;
            } 
            set { 
                Person.Name = value;
            }
        }
        new public string Surname {
            get {
                return Person.Surname;
            } 
            set { 
                Person.Surname = value; 
            } 
        }

        public int GroupNumber
        {
            get {
                return _groupNumber;
            }
            set {
                if (value <= 100 || value >= 599) {
                    throw new ArgumentOutOfRangeException("No, only from 100 to 599 :)");
                }
                _groupNumber = value;
            }
        }

        public double AverageMark // среднее значение оценок в списке экзаменов метод  void  AddExams  (  params  Exam[]  )    для  добавления  элементов  в  список экзаменов;  
        {
            get {
                if (_exams.Count == 0) return 0;

                double sum = 0;

                foreach (Exam exam in _exams) {
                    sum += exam.Mark;
                }

                return sum / _exams.Count;
            }
        }
        public bool this[Education prof]
        {
            get {
                bool result;
                if (prof == _education) {
                    result = true;
                }
                else {
                    result = false;
                }

                return result;
            }
        }
        public void AddExams(params Exam[] exams) //добавление элементов в список экзаменов
        {
            _exams.AddRange(exams);
        }

        public void AddTests(params Test[] tests)
        {
            _tests.AddRange(tests);
        }

        public override string ToString() //для форм строки со значениями всех полей класса
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("{0} \nGroup number: {1} \nEducation: {2}", Person.ToString(), _groupNumber, _education);
            str.Append("\n============================================================================================\n");

            foreach (Exam exam in Exams)
                str.AppendLine(exam.ToString());
            foreach (Test test in Tests)
                str.AppendLine(test.ToString());
            return str.ToString();
        }

        public override string ToShortString() //тоже самое но без списка зачетов, но со средним баллом
        {
            return string.Format("Student: {0}\nForm of education: {1}\nGroup number: {2}\nAverage Mark: {3}\n", Person, Education, GroupNumber, AverageMark);
        }

        public override object DeepCopy() //опр перегружженую версию метода
        {
            Student stud = new Student(new Person(_person.Name, _person.Surname, _person.Date), _education, _groupNumber);
            foreach (Exam exam in this.Exams) {
                stud.AddExams(exam);
            }
            foreach (Test test in Tests) {
                stud.AddTests(test);
            }
            return stud;
        }

        public IEnumerable GetResults() //интерфейс для перебора всех экзаменов и зачетов
        {
            Console.WriteLine("Exams: \n");
            foreach (Exam exam in this.Exams) {
                yield return exam;
            }
            Console.WriteLine("\n");
            Console.WriteLine("Tests: \n");

            foreach (Test test in this.Tests) {
                yield return test;
            }
        }

        public IEnumerable GetExamsResults(int MinMark)
        {
            foreach (Exam exam in Exams) {
                if (exam.Mark > MinMark) {
                    yield return exam;
                }
            }
        }

    }
}
