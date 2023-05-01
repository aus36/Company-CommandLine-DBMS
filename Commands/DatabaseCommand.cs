//Contains all calls to the database for each command, these are run when a command is executed

using CSCI428_SQLProject.Data;
using CSCI428_SQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CSCI428_SQLProject.Commands;

internal class DatabaseCommand //Class for handling actual interaction with database for each command
{
    public static void LIST(Arguments args) //Lists records of the DB with parameters
    {
        Console.WriteLine("LISTING...\n");

        string tableName = DecideTable(args.Type!);

        switch (tableName)
        {
            case ("Person"):
                string query1 = $"SELECT * FROM {tableName} ORDER BY {args.Orderby} {args.Direction}"; //Make an SQL query using arguments

                List<Person> searchResults1 = QueryPerson(query1);

                int numPages1 = (int)Math.Ceiling((double)searchResults1.Count / args.Count!.Value);

                int index1 = 0;
                for (int i = 1; i <= args.Page && i <= numPages1; i++) //Loop to print out each page of results
                {
                    Console.WriteLine($"Page: {i}\n");

                    for (int j = 1; j <= args.Count! && index1 < searchResults1.Count; j++, index1++)
                    {
                        Console.WriteLine($"ID: {searchResults1.ElementAt(index1).ID}");
                        Console.WriteLine($"Name: {searchResults1.ElementAt(index1).FirstName} {searchResults1.ElementAt(index1).LastName}");
                        Console.WriteLine($"Worker Type: {searchResults1.ElementAt(index1).WorkerType}");
                        Console.WriteLine($"Employment Date: {searchResults1.ElementAt(index1).EmploymentDate}\n");
                    }
                    Console.WriteLine();
                }
                break;

            case ("PreHire"):
                string query2 = $"SELECT * FROM {tableName} ORDER BY {args.Orderby} {args.Direction}"; //Make an SQL query using arguments

                List<PreHire> searchResults2 = QueryPreHire(query2);

                int numPages2 = (int)Math.Ceiling((double)searchResults2.Count / args.Count!.Value);

                int index2 = 0;
                for (int i = 1; i <= args.Page && i <= numPages2; i++) //Loop to print out each page of results
                {
                    Console.WriteLine($"Page: {i}\n");

                    for (int j = 1; j <= args.Count! && index2 < searchResults2.Count; j++, index2++)
                    {
                        Console.WriteLine($"ID: {searchResults2.ElementAt(index2).ID}");
                        Console.WriteLine($"Offer Extended Date: {searchResults2.ElementAt(index2).OfferExtendedDate}");
                        Console.WriteLine($"Offer Accepted Date: {searchResults2.ElementAt(index2).OfferAcceptedDate}\n");
                    }
                    Console.WriteLine();
                }
                break;

            case ("Employees"):
                string query3 = $"SELECT * FROM {tableName} ORDER BY {args.Orderby} {args.Direction}"; //Make an SQL query using arguments

                List<Employee> searchResults3 = QueryEmployee(query3);

                int numPages3 = (int)Math.Ceiling((double)searchResults3.Count / args.Count!.Value);

                int index3 = 0;
                for (int i = 1; i <= args.Page && i <= numPages3; i++) //Loop to print out each page of results
                {
                    Console.WriteLine($"Page: {i}\n");

                    for (int j = 1; j <= args.Count! && index3 < searchResults3.Count; j++, index3++)
                    {
                        Console.WriteLine($"ID: {searchResults3.ElementAt(index3).ID}");
                        Console.WriteLine($"Job Title: {searchResults3.ElementAt(index3).JobTitle}");
                        Console.WriteLine($"Monthly Salary: {searchResults3.ElementAt(index3).MonthlySalary}\n");
                    }
                    Console.WriteLine();
                }
                break;

            case ("Retiree"):
                string query4 = $"SELECT * FROM {tableName} ORDER BY {args.Orderby} {args.Direction}"; //Make an SQL query using arguments
                List<Retiree> searchResults4 = QueryRetiree(query4);
                int numPages4 = (int)Math.Ceiling((double)searchResults4.Count / args.Count!.Value);
                int index4 = 0;
                for (int i = 1; i <= args.Page && i <= numPages4; i++) //Loop to print out each page of results
                {
                    Console.WriteLine($"Page: {i}\n");
                    for (int j = 1; j <= args.Count! && index4 < searchResults4.Count; j++, index4++)
                    {
                        Console.WriteLine($"ID: {searchResults4.ElementAt(index4).ID}");
                        Console.WriteLine($"Retirement Program: {searchResults4.ElementAt(index4).RetirementProgram}");
                        Console.WriteLine($"Retirement Date: {searchResults4.ElementAt(index4).RetirementDate}\n");
                    }
                    Console.WriteLine();
                }
                break;
        }
    }

    public static void ADD(Arguments args) //Adds a record to the DB with parameters
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
        switch (args.Data!["WorkerType"])
        {
            case ("PreHire"):
                Person p = DB.Person.Single(Person => Person.FirstName == args.Data!["FirstName"]); //Retrieve newly created record from DB
                PreHire preHire = new()
                {
                    OfferExtendedDate = DateTime.Parse(args.Data!["OfferExtendedDate"]),
                    OfferAcceptedDate = DateTime.Parse(args.Data!["OfferAcceptedDate"]),
                    Person = p,
                };
                DB.PreHire.Add(preHire);
                DB.SaveChanges();
                break;

            case ("Employee"):
                Person p2 = DB.Person.Single(Person => Person.FirstName == args.Data!["FirstName"]);
                
                Employee employee = new()
                {
                    JobTitle = args.Data!["JobTitle"],
                    MonthlySalary = float.Parse(args.Data!["MonthlySalary"]),
                    Person = p2,
                };
                DB.Employees.Add(employee);
                DB.SaveChanges();
                break;

            case ("Retiree"):
                Person p3 = DB.Person.Single(Person => Person.FirstName == args.Data!["FirstName"]);
                Retiree retiree = new()
                {
                    RetirementDate = DateTime.Parse(args.Data!["RetirementDate"]),
                    RetirementProgram = args.Data!["RetirementProgram"],
                    Person = p3,
                };
                DB.Retiree.Add(retiree);
                DB.SaveChanges();
                break;
        }
    }

    public static void UPDATE(Arguments args) //Changes the values of a record in the DB with parameters
    {
        Console.WriteLine("UPDATING...\n");
        ProgramContext DB = new();
        Person update = DB.Person.Single(Person => Person.ID == args.PersonId);
        update.FirstName = args.Data!["FirstName"];
        update.LastName = args.Data!["LastName"];
        update.EmploymentDate = DateTime.Parse(args.Data!["EmploymentDate"]);
        DB.Person.Update(update);
        DB.SaveChanges();
    }

    public static void DELETE(Arguments args) //Deletes either a single record or all records from the DB based on parameters
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

    public static string DecideTable(string input) //Decides which table to query based on input
    {
        return input switch
        {
            ("ALL") => "Person",
            ("PreHire") => "PreHire",
            ("Employee") => "Employees",
            ("Retiree") => "Retiree",
            _ => "Person",
        };
    }

    public static List<Person> QueryPerson(string query)
    {
        ProgramContext DB = new();
        List<Person> searchResults;
        var queryList = DB.Person.FromSqlRaw(query).ToList(); //Run the SQL query and retrieve search results
        searchResults = queryList.ToList();
        return searchResults;
    }

    public static List<PreHire> QueryPreHire(string query)
    {
        ProgramContext DB = new();
        List<PreHire> searchResults;
        var queryList = DB.PreHire.FromSqlRaw(query).ToList(); //Run the SQL query and retrieve search results
        searchResults = queryList.ToList();
        return searchResults;
    }

    public static List<Employee> QueryEmployee(string query)
    {
        ProgramContext DB = new();
        List<Employee> searchResults;
        var queryList = DB.Employees.FromSqlRaw(query).ToList(); //Run the SQL query and retrieve search results
        searchResults = queryList.ToList();
        return searchResults;
    }

    public static List<Retiree> QueryRetiree(string query)
    {
        ProgramContext DB = new();
        List<Retiree> searchResults;
        var queryList = DB.Retiree.FromSqlRaw(query).ToList(); //Run the SQL query and retrieve search results
        searchResults = queryList.ToList();
        return searchResults;
    }
}