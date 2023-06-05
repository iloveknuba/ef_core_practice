

using ef_core_practice;
using Microsoft.EntityFrameworkCore;

static void Main(string[] args) {

   
}


string? input = String.Empty;
while (input != "5")
{
    Console.WriteLine("Введіть 1 - add або 2 - show or 3 - delete or 4 - replace");
    input = Console.ReadLine();
    if (input == "1")
    {
        addInfo();
    }
    if (input == "2") {
       using (EmployeeDbContext db = new EmployeeDbContext())
        {
            var list = db.Emplyees.ToList();
            
            db.resfreshList(list);
      
        }
    }
    if(input == "3")
    {
        using (EmployeeDbContext db = new EmployeeDbContext())
        {
            Console.WriteLine("Id to delete");
            int id = int.Parse(Console.ReadLine());

            Emplyee objectToDelete = db.Emplyees.FirstOrDefault(obj => obj.Id == id);

            if (objectToDelete != null)
            {
                db.Emplyees.Remove(objectToDelete);
               
                db.SaveChanges();
            }
        }
    }
    if( input == "4")
    {
        UpdateInfo();
    }


}

void UpdateInfo()
{
    using (EmployeeDbContext db = new EmployeeDbContext())
    {
        Console.WriteLine("Id to replace");
        int id = int.Parse(Console.ReadLine());
        var objectToUpdate = db.Emplyees.FirstOrDefault(obj => obj.Id == id);

        string[] inputParameters = new string[] { "Ім'я", "Прізвище", "По-батькові", "Посаду", "Тип зарплати(fixed/byhour)", "Зарплату", "Відроблені години" }; // ініціалізуємо вхідні дані

        for (int i = 0; i < inputParameters.Length; i++)
        {
            Console.WriteLine("Введіть {0}:", inputParameters[i]);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) // перевірка на входження пустого рядка
            {
                Console.WriteLine("Помилка! Введене значення є порожнім або містить тільки пробіли. Спробуйте ще раз.");
                i--; // повторити цикл для тієї ж вхідної змінної
                continue;
            }

            inputParameters[i] = input; // перевизначаємо дані
        }

        objectToUpdate.FirstName = inputParameters[0];
        objectToUpdate.LastName = inputParameters[1];
        objectToUpdate.Surname = inputParameters[2];
        objectToUpdate.Position = inputParameters[3];
        objectToUpdate.SalaryType = inputParameters[4];
        objectToUpdate.Salary = int.Parse(inputParameters[5]);
        objectToUpdate.WorkedHours = int.Parse(inputParameters[6]);

        db.SaveChanges();
    }
}
void addInfo()
{
    using (AppContext context = new AppContext())
    {
        string[] inputParameters = new string[] { "Ім'я", "Прізвище", "По-батькові", "Посаду", "Тип зарплати(fixed/byhour)", "Зарплату", "Відроблені години" }; // ініціалізуємо вхідні дані

        for (int i = 0; i < inputParameters.Length; i++)
        {
            Console.WriteLine("Введіть {0}:", inputParameters[i]);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input)) // перевірка на входження пустого рядка
            {
                Console.WriteLine("Помилка! Введене значення є порожнім або містить тільки пробіли. Спробуйте ще раз.");
                i--; // повторити цикл для тієї ж вхідної змінної
                continue;
            }

            inputParameters[i] = input; // перевизначаємо дані
        }
        context.Emplyees.Add(new Emplyee()
        {
            
            FirstName = inputParameters[0],
            LastName = inputParameters[1],
            Surname = inputParameters[2],
            Position = inputParameters[3],
            SalaryType = inputParameters[4],
            Salary = int.Parse(inputParameters[5]),
            WorkedHours = int.Parse(inputParameters[6]),

        });;
        context.SaveChanges();
    }
}



class AppContext : DbContext
{
    public DbSet<Emplyee> Emplyees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=andbut; Database=EmployeeDB; Encrypt=False; Trusted_Connection=True");
    }
}
