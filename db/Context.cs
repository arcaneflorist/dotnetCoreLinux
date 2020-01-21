using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using Microsoft.EntityFrameworkCore.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

using System.Linq;
using System.Threading.Tasks;
using db.entities;

namespace db
{
    public class MyContext : DbContext
    {
        // private string ConnectionString { get; }
        // public MyContext(string argConnectionString = "Data Source=DESKTOP-PL5CAAM\\MSSQLSERVER2014;Initial Catalog=xeroexampledb;User Id=xeroeampledb;Password=galaxie500")
        // {
        //     ConnectionString = argConnectionString;
        // }
        public MyContext()
        { 
            
        }

        public DbSet<ProcessableOrder> ProcessableOrders { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=xerotest;user=root;password=galaxie500", // replace with your Connection String
                    mySqlOptions =>
                    {
                        mySqlOptions.ServerVersion(new Version(5, 7, 17), ServerType.MySql); // replace with your Server Version and Type
                    }
            );
        }        

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseLazyLoadingProxies();
        //     optionsBuilder.UseSqlServer(ConnectionString);
        // }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            return new MyContext();   
        }
    }
}