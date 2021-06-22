using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement5.Models
{
    public class StudentManagementContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public string DateValueConverter(DateTime date)
        {
            return date.Year.ToString();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "Data Source=DESKTOP-38IAPAP;" +
                "Initial Catalog=StudentManagement;" +
                "Integrated Security=True"
            );
        }
    }
}
