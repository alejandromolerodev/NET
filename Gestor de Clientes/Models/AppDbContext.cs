using System.Collections.Generic;
using System.Data.Entity;
using Gestor_de_Clientes.Models;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }

    public AppDbContext() : base("ConexionDB") { }
}
