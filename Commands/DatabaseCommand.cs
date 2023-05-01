//Contains all calls to the database for each command, these are run when a command is executed

using CSCI428_SQLProject.Data;
using CSCI428_SQLProject.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CSCI428_SQLProject.Commands;

internal class DatabaseCommand //Class for handling actual interaction with database for each command
{
    public static void LIST(Arguments args)
    {
        Console.WriteLine("LISTING... (This isn't implemented yet so just pretend its doing something)");
        Console.WriteLine(args.ToString());
    }

    public static void ADD(Arguments args)
    {
        Console.WriteLine("ADDING...\n");
        ProgramContext DB = new();
        PersonType personType = DB.PersonTypes.Single(PersonTypes => PersonTypes.PType == "Employee"/*args.WorkerType*/); //Pull existing record from DB
        Person person = new()
        {
            Type = personType,
            WorkerType = personType.PType,
            FirstName = "Austin",
            LastName = "Hale",
            EmploymentDate = DateTime.Now,
        };
        DB.Person.Add(person);
        DB.SaveChanges();

        Console.WriteLine(args.ToString());
    }

    public static void UPDATE(Arguments args)
    {
        Console.WriteLine("UPDATING...");
        ProgramContext DB = new();

    }

    public static void DELETE(Arguments args)
    {
        Console.WriteLine("DELETING...");
        ProgramContext DB = new();
        if (args.Asterisk)
        {
            //Remove all persons
        }
        else
        {
            Person removal = DB.Person.Single(Person => Person.ID == args.PersonId);
            DB.Person.Remove(removal);
        }
        DB.SaveChanges();
        Console.WriteLine(args.ToString());
    }
}