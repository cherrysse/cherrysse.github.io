using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloiseLab2
{
    internal interface IDateAndCopy // Реализовать интерфейс
    {
        object DeepCopy();
        bool Equals(object obj);

        DateTime Date { 
            get;
            set;
        }
    }
}
