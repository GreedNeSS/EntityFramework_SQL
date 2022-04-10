using StoredFunction;
using StoredFunction.Models;

Console.WriteLine("***** Stored Function *****");

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureCreated();

    Company microsoft = new Company { Name = "Microsoft" };
    Company apple = new Company { Name = "Apple" };
    User ruslan = new User { Name = "Ruslan", Age = 30, Company = microsoft };
    User marcus = new User { Name = "Marcus", Age = 45, Company = microsoft };
    User tod = new User { Name = "Tod", Age = 22, Company = apple };
    User terry = new User { Name = "Terry", Age = 18, Company = apple };
    
    db.AddRange()
}