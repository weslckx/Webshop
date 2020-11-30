using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Webshop.Data.Persistence.EntityConfigurations;
using Webshop.Domain.Models;

namespace Webshop.Data
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options)
            : base(options)
        {
        }

      
        public virtual DbSet<Product> Products { get; set; }


        //Old way: DBcontext uses his method OnModelCreating with param ModelBuilder. Is called when context is first created
        // It is possible to override this.
        // https://www.learnentityframeworkcore.com/configuration/fluent-api 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
        }

    }


}
