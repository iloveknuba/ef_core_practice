using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ef_core_practice;

public partial class EmployeeDbContext : DbContext
{
    public EmployeeDbContext()
    {
    }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emplyee> Emplyees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=andbut; Database=EmployeeDB; Encrypt=False; Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emplyee>(entity =>
        {
            entity.Property(e => e.FirstName).HasColumnName("firstName");
            entity.Property(e => e.LastName).HasColumnName("lastName");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Salary).HasColumnName("salary");
            entity.Property(e => e.SalaryType).HasColumnName("salaryType");
            entity.Property(e => e.WorkedHours).HasColumnName("workedHours");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    public void resfreshList<T>(List<T> employees) where T : Emplyee // Створюємо метод для виведення даних списку
    {
        Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}", "Id", "Ім'я", "Прізвище", "По-Батькові", "Посада", "Тип зарплати", "Зарплата", "Відпрацьовані години");
        foreach (T employee in employees)
        {
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}", employee.Id, employee.FirstName, employee.LastName, employee.Surname, employee.Position, employee.SalaryType, employee.Salary, employee.WorkedHours);
        }
    }
}
