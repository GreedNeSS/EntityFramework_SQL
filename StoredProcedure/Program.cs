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

using (ApplicationContext db = new ApplicationContext())
{
    Console.WriteLine("\ndb.Users.FromSqlRaw(\"GetUserWithMaxAge @userName OUT:\", param)\n");

    SqlParameter param = new SqlParameter
    {
        ParameterName = "@userName",
        SqlDbType = System.Data.SqlDbType.VarChar,
        Direction = System.Data.ParameterDirection.Output,
        Size = 50
    };
    
    db.Database.ExecuteSqlRaw("GetUserWithMaxAge @userName OUT", param);

    Console.WriteLine(param.Value);
}