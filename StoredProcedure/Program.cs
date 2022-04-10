using StoredProcedure;
using StoredProcedure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("***** Stored Function *****");

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\ndb.Users.FromSqlRaw(\"GetUsersByCompany@name\", param).ToList()\n");

    SqlParameter param = new SqlParameter("@name", "Microsoft");
    var users = db.Users.FromSqlRaw("GetUsersByCompany @name", param).ToList();

    foreach (var user in users)
    {
        Console.WriteLine(user);
    }
}