﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace TrainingProject.tables
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cell> cells { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Stand> stands { get; set; }
        public DbSet<StoreDepartment> storeDepartments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoreDepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StandConfiguration());
            modelBuilder.ApplyConfiguration(new CellConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        //// static readonly ILoggerFactory loggerFactory = new LoggerFactory().AddConsole(LogLevel.Information);

        //public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        //{
        //    builder.AddProvider(new MyLoggerProvider());    // указываем наш провайдер логгирования
        //    //    builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name
        //    //                && level == LogLevel.Information)
        //    //.AddProvider(new MyLoggerProvider());
        //    //builder.AddConsole();
        //});
    }
}