using AutomapperApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutomapperApi.Context
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // setar tamanho coluna automaticamente == evitar varchar(max)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string)))
                )
            {
                property.SetColumnType("varchar(100)");
            }

            //aplicar todos os mappings class
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);

            // remover delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
