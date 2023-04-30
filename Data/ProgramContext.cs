using System;
using CSCI428_SQLProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CSCI428_SQLProject.Data;

public class ProgramContext : DbContext
{
    public DbSet<PersonType> PersonTypes { get; set; }

    public DbSet<Person> Person { get; set; }

    public DbSet<PreHire> PreHire { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Retiree> Retiree { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-TI71SK3;Initial Catalog=ProjDB;Integrated Security=True;Pooling=False;TrustServerCertificate=True");
    }
}