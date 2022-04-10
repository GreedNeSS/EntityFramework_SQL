using InitilizeDB;
using InitilizeDB.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("***** Initilize DB *****");

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureCreated();

    Company microsoft = new Company { Name = "Microsoft" };
    Company apple = new Company { Name = "Apple" };
    User ruslan = new User { Name = "Ruslan", Age = 30, Company = microsoft };
    User marcus = new User { Name = "Marcus", Age = 45, Company = microsoft };
    User tod = new User { Name = "Tod", Age = 22, Company = apple };
    User terry = new User { Name = "Terry", Age = 18, Company = apple };

    db.Companies.AddRange(microsoft, apple);
    db.Users.AddRange(ruslan, marcus, tod, terry);
    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.ExecuteSqlRaw(
        @"CREATE FUNCTION [dbo].[GetUsersByAge]
        (
            @age int
        )
        RETURNS @returntable TABLE
        (
            Id int,
            CompanyId int,
            Name nvarchar(50),
            Age int
        )
        AS
        BEGIN
            INSERT @returntable
            SELECT Id, CompanyId, Name, Age FROM Users WHERE Age < @age
            RETURN
        END"
    );
}

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.ExecuteSqlRaw(
        @"CREATE PROCEDURE [dbo].[GetUsersByCompany]
            @name nvarchar(50) 
        AS
            SELECT * FROM Users 
            WHERE CompanyId = (SELECT Id FROM Companies WHERE Name = @name)
        "
    );
}