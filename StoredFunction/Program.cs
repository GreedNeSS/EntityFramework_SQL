using StoredFunction;
using StoredFunction.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("***** Stored Function *****");

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\n=> db.Users.FromSqlRaw(\"SELECT * FROM GetUsersByAge(@age)\", param).ToList()\n");

    SqlParameter param = new SqlParameter("@age", 30);
    var users = db.Users.FromSqlRaw("SELECT * FROM GetUsersByAge (@age)", param).ToList();

    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\n=> db.GetUsersByAge(30)\n");

    var users = db.GetUsersByAge(30);

    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}