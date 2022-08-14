using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using rock.Models;

namespace rock.Data{
	public class ApplicationDbContext :IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Category> categories { get; set; }
		public DbSet<CoverType> coverTypes { get; set; }
        public DbSet<Product> products { get; set; }
	
    }


    public class YourDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
			optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=rock4;Persist Security Info=False;User ID=sa;Password=MyPass@word;MultipleActiveResultSets=False");

			return new ApplicationDbContext(optionsBuilder.Options);
		}
	}
	
}

