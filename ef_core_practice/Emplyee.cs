using System;
using System.Collections.Generic;

namespace ef_core_practice;

public partial class Emplyee : IComparable
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string SalaryType { get; set; } = null!;

    public int Salary { get; set; }

    public int WorkedHours { get; set; }

    public virtual int Average_Salary() { return 0; }

    public int CompareTo(object? obj) // реалізуємо метод інтерфейсу і порівнюємо об'єкти
    {
        Emplyee b;
        b = (Emplyee)obj;
        return Average_Salary().CompareTo(b.Average_Salary);
    }
}
