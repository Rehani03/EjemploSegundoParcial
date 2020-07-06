using EjemploSegundoParcial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjemploSegundoParcial.DAL
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DATA\EjemploSegundoParcial.db");
        }

        public DbSet<Pais> Pais { get; set; }
        public DbSet<Llamada> Llamadas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>().HasData(new Pais
            {
                paisId = 1,
                pais = "Haiti",
                precio = 10
                
            });
        }
    }
}
