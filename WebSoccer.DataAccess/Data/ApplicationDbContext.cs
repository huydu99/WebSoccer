using WebSoccer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "A", Status=true ,Description="1"},
                new Category { Id = 2, Name = "B", Status = true, Description = "1" } 
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Cơm chiên",
                    ShortDescription = "Cơm",
                    Description = "Cơm chiên với trứng",
                    Status = true,
                    PromotionPrice = 25000,
                    Price = 30000,
                    CategoryId = 1,         
                    CreateAt = DateTime.Now,
                },
                new Product
                {
                    Id = 2,
                    Name = "Cháo gà",  
                    ShortDescription = "Cháo",
                    Description = "Cháo gà",
                    Status = true,
                    PromotionPrice = 25000,
                    Price = 30000,
                    CategoryId = 2,
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
