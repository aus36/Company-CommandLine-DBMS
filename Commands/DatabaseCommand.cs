//Contains all calls to the database for each command, these are run when a command is executed

using CSCI428_SQLProject.Data;
using CSCI428_SQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CSCI428_SQLProject.Commands;

internal class DatabaseCommand //Class for handling actual interaction with database for each command
{
    public static void LIST(Arguments args)
    {
        Console.WriteLine("LISTING...");
    }

    public static void ADD(Arguments args)
    {
        Console.WriteLine("ADDING...\n");
        ProgramContext DB = new();

        PersonType personType = DB.PersonTypes.Single(PersonTypes => PersonTypes.PType == args.Data!["WorkerType"]); //Pull existing record from DB
        Person person = new()
        {
            Type = personType,
            WorkerType = args.Data!["WorkerType"],
            FirstName = args.Data!["FirstName"],
            LastName = args.Data!["LastName"],
            EmploymentDate = DateTime.Parse(args.Data!["EmploymentDate"]),
        };
        DB.Person.Add(person);
        DB.SaveChanges();
    }

    public static void UPDATE(Arguments args)
    {
        Console.WriteLine("UPDATING...");
        ProgramContext DB = new();
        Person update = DB.Person.Single(Person => Person.ID == args.PersonId);
        update.FirstName = args.Data!["FirstName"];
        update.LastName = args.Data!["LastName"];
        update.EmploymentDate = DateTime.Parse(args.Data!["EmploymentDate"]);
        DB.Person.Update(update);
        DB.SaveChanges();
    }

    public static void DELETE(Arguments args)
    {
        Console.WriteLine("DELETING...\n");
        ProgramContext DB = new();
        if (args.Asterisk)
        {
            var toList = DB.Person.ToList();
            DB.Person.RemoveRange(toList);
        }
        else
        {
            Person removal = DB.Person.Single(Person => Person.ID == args.PersonId);
            DB.Person.Remove(removal);
        }
        DB.SaveChanges();
    }
}