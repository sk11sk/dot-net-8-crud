using Microsoft.EntityFrameworkCore;
using studentManagementSystem.Models.Entities;

namespace studentManagementSystem.Data
{
    public class StudentDbContext : DbContext // inherit from db context from the package  Microsoft.EntityFrameworkCore
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) // generate contructor
        {
        }

        public DbSet<Student> Students { get; set; } // create db set 

    }
}
