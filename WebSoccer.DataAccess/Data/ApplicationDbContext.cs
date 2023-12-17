using WebSoccer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebSoccer.DataAccess.Configuration;

namespace WebSoccer.DataAcess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products{ get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Câu lạc bộ", Status=true ,Description="1"}
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Barcelona",  
                    ShortDescription = "Barcelona",
                    Description = "Barcelona Barcelona",
                    Status = true,
                    Price = 30000,
                    CategoryId = 1,
                    CreateAt = DateTime.Now,
                });
   //         modelBuilder.Entity<IdentityUserClaim<Guid>>();
   //         modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(x => new { x.UserId,x.RoleId }) ;
			//modelBuilder.Entity<IdentityUserLogin<Guid>>().HasKey(x=>x.UserId);
			//modelBuilder.Entity<IdentityRoleClaim<Guid>>();
			//modelBuilder.Entity<IdentityUserToken<Guid>>().HasKey(x=>x.UserId);
			base.OnModelCreating(modelBuilder);
        }

    }
}
