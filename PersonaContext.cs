using Microsoft.EntityFrameworkCore;
using TryPactia.Models;
using System.Threading;

namespace TryPactia
{
    public class PersonaContext : DbContext
    {
        public DbSet<Persona> Persona { get; set; }


        public PersonaContext(DbContextOptions<PersonaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Persona>(persona =>
            {
                persona.ToTable("Persona");
                persona.HasKey(p => p.Cedula);

                persona.Property(p => p.Nombre).IsRequired().HasMaxLength(20);

                persona.Property(p => p.Apellido).IsRequired().HasMaxLength(20);


            });


        }

    }
}