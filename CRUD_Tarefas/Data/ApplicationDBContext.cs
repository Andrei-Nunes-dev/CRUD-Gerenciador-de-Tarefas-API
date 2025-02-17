using CRUD_Tarefas.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Tarefas.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options): base(options)
        {
        }

        public DbSet<Tarefas> Tarefas { get; set; }

    }
}
