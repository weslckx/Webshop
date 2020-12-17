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
        public virtual DbSet<Customer> Customers { get; set; }


        //Old way: DBcontext uses his method OnModelCreating with param ModelBuilder. Is called when context is first created
        // It is possible to override this.
        // https://www.learnentityframeworkcore.com/configuration/fluent-api 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Problem with Id IdentityUserLogin
            //https://stackoverflow.com/questions/40703615/the-entity-type-identityuserloginstring-requires-a-primary-key-to-be-defined
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ProductConfiguration());
        }

    }


}
