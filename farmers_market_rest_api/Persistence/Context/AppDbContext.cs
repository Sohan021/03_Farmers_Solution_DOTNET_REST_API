using farmers_market_rest_api.Domain.Models.Area;
using farmers_market_rest_api.Domain.Models.Business;
using farmers_market_rest_api.Domain.Models.Shop;
using farmers_market_rest_api.Domain.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace farmers_market_rest_api.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        //User
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }

        //FounderShop
        public virtual DbSet<Instrument> Instruments { get; set; }
        public virtual DbSet<InstrumentCategory> InstrumentCategories { get; set; }
        public virtual DbSet<InstrumentOrderDetails> InstrumentOrderDetails { get; set; }
        public virtual DbSet<OrderShop> OrderShops { get; set; }

        //Business
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        ///Area
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Upozila> Upozillas { get; set; }
        public virtual DbSet<UnionOrWard> UnionOrWards { get; set; }
        public virtual DbSet<Market> Markets { get; set; }
    }
}
