using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreArgumentExceptionIssue.Data
{
    public class FooContext : DbContext
    {
        public FooContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Foo> Foos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Foo>().HasData(
                new Foo { Id = 1 },
                new Foo { Id = 2 },
                new Foo { Id = 3 }
            );
        }
    }
}
