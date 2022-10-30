using ApiAppCot.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiAppCot.Contexto
{
    public class Contexto : DbContext 
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options) => Database.EnsureCreated();
    

        public DbSet<Ativos> Ativos { get; set; } = null!;


    }
}
