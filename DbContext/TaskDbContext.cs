using AppTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTest.DbContext
{
    public class TaskDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<TasksModel> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tasks.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }

}
