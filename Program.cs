using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EFGetStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class BloggingContext : DbContext
        {
            public DbSet<Blog> Blogs { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
                => options.UseNpgsql("Host=127.0.0.1; Database=my_db;Username=my_user;Password=my_pwd");

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            }
        }

        public class Blog
        {
            public int BlogId { get; set; }
            public string NewProperty { get; set; }
        }

        public class BlogConfiguration : IEntityTypeConfiguration<Blog>
        {
            public void Configure(EntityTypeBuilder<Blog> builder)
            {
                builder.HasKey(x => x.BlogId);
                builder.Property(x => x.NewProperty).HasMaxLength(100); 
                builder.HasCheckConstraint("prop_ctx", "new_property IN ('1', '2')");
            }
        }
    }
}
