using bases.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace bases.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Persona> Persona { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Persona>(a => {

                a.HasKey(e => e.Codigo);

                a.Property(e => e.Nombre)
                //.IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                a.Property(e => e.Apellido)
               //.IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

                a.Property(e => e.Direccion)
               //.IsRequired()
               .HasMaxLength(250)
               .IsUnicode(false);

                a.Property(e => e.Estado)
                .IsRequired()
                .IsUnicode(false);


            });

        }

    }
}
