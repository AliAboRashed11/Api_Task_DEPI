using Microsoft.EntityFrameworkCore;
namespace ApiDayOne.Models
{
    public class CompanyDBContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-TJ7110K\\SQLEXPRESS ; database=ApiCompany ; Integrated Security=true ; Encrypt=false");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
