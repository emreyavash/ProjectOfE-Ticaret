using Microsoft.EntityFrameworkCore;
using ProjectOfE_Ticaret.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOfE_Ticaret.DataAccess.ContextDb
{
    public class ETicaretDbContext :DbContext
    {
        public ETicaretDbContext()
        {
        }

        public ETicaretDbContext(DbContextOptions<ETicaretDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server = (localdb)\MSSQLLocalDB;
                Database = ProjectOfETicaret;
                Trusted_Connection = True"
                );
        }
        public DbSet<User> Users { get; set; } 
        public DbSet<Role> Roles { get; set; } 
        public DbSet<UserRole> UserRoles { get; set; } 
        public DbSet<Product> Products { get; set; } 
        public DbSet<Category> Categorys { get; set; } 
    }
}
