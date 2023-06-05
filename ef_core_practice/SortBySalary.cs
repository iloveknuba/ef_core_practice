using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_core_practice
{
    public class SortBySalary : IComparer<Emplyee>
    {

        public int Compare(Emplyee? x, Emplyee? y) // Релізуємо метод інтерфейсу для порівняння середньої зарплати 
        {
            Emplyee t1 = x;
            Emplyee t2 = y;
            if (t1.Average_Salary() < t2.Average_Salary()) return 1;
            if (t1.Average_Salary() > t2.Average_Salary()) return -1;
            return 0;
        }
    }
}
