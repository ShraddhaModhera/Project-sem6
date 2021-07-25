using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EcommerceProject.Models
{
    public class AdminContext : DbContext
    {
        public AdminContext() : base("EcommerceConnection")
        {

        }
        public DbSet<Status> StatusTable { get; set; }
        public DbSet<Service> ServiceTable { get; set; }        
        public DbSet<Enquiry> EnquiryTable { get; set; }
        public DbSet<Lead> LeadTable { get; set; }
        public DbSet<Category> CategoryTable { get; set; }
        public DbSet<Product> ProductTable { get; set; }
        public DbSet<Page> PageTable { get; set; }
        public DbSet<PageGroup> PageGroupTable { get; set; }
        public DbSet<Banner> BannerTable { get; set; }
        public DbSet<StockStatus> StockTable { get; set; }
        public DbSet<Variant> VariantTable { get; set; }
        public DbSet<Manufacturer> ManuTable { get; set; }
        public DbSet<Shipping> ShipTable { get; set; }
        public DbSet<Brand> BrandTable { get; set; }
        public DbSet<Customer> CustomerTable  { get; set; }
        public DbSet<CustomerGroup> CGroupTable { get; set; }
        public DbSet<Rate> RateTable { get; set; }
        public DbSet<Coupon> CouponTable { get; set; }
        public DbSet<Role> RoleTable { get; set; }
        public DbSet<User> UserTable { get; set; }
        public DbSet<Country> CountryTable { get; set; }
        public DbSet<Zone> ZoneTable { get; set; }
        public DbSet<Location> LocationTable { get; set; }
        public DbSet<Language> LangTable { get; set; }
        public DbSet<Currency> CurrencyTable { get; set; }
        public DbSet<Tax> TaxTable { get; set; }
        public DbSet<OrderStatus> OrderStatusTable { get; set; }
        public DbSet<Email> EmailTable { get; set; }
        public DbSet<Setting> SettingTable { get; set; }
        public DbSet<Order> OrderTable { get; set; }
        public DbSet<Payment> PaymentTable { get; set; }
        public DbSet<CancelOrder> CancelTable { get; set; }
        public DbSet<CustomerLogin> CustomerLogin { get; set; }
        public DbSet<ResetPasswordModel> ResetPasswordModels { get; set; }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
            DateTime cDate = DateTime.Now;
            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {                   
                    ((BaseEntity)entityEntry.Entity).Created_date = cDate;
                    ((BaseEntity)entityEntry.Entity).Modified_date = DateTime.Now;
                }
                else
                {
                    ((BaseEntity)entityEntry.Entity).Created_date = cDate;
                    ((BaseEntity)entityEntry.Entity).Modified_date = DateTime.Now;
                    //((BaseEntity)entityEntry.Entity).Modified_by = currentname;
                }
            }
            return base.SaveChanges();
        }
    }
}