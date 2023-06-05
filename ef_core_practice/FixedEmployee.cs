using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_core_practice
{
    public class FixedEmployee : Emplyee
    {
        public override int Average_Salary()
        {
            return Salary;
        }
    }
}
