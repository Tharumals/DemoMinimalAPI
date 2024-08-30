﻿using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models.Entities;

namespace MinimalAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users{ get; set; }
    }
}
