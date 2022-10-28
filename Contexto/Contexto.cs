using ApiAppCot.Models;
using Microsoft.EntityFrameworkCore;
using ApiAppCot.Models;

namespace ApiAppCot.Contexto
{
    public class Contexto : DbContext 
    {
        public Contexto(DbContextOptions<Contexto> options) { }
    

        public DbSet<Ativos> Ativos { get; set; }


    }
}
