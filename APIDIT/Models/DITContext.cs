using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIDIT.Models
{
    public partial class DITContext : DbContext
    {
        public DITContext()
        {
        }

        public DITContext(DbContextOptions<DITContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<Case> Case { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:ditserver.database.windows.net,1433;Initial Catalog=DIT;Persist Security Info=False;User ID=ditadmin;Password=Ctd8cvw7s7.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Database=DIT;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdminName)
                    .IsRequired()
                    .HasColumnName("admin_name")
                    .HasMaxLength(50);

                entity.Property(e => e.AdminPassword)
                    .IsRequired()
                    .HasColumnName("admin_password")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.BillId)
                    .HasColumnName("bill_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BillDate)
                    .HasColumnName("bill_date")
                    .HasColumnType("date");

                entity.Property(e => e.BillPayment)
                    .IsRequired()
                    .HasColumnName("bill_payment")
                    .HasMaxLength(50);

                entity.Property(e => e.BillValidityTime)
                    .HasColumnName("bill_validity_time")
                    .HasColumnType("date");

                entity.Property(e => e.ShoppingCartId).HasColumnName("shopping_cart_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.ShoppingCart)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.ShoppingCartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bill_ShoppingCart");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bill)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bill_User1");
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.Property(e => e.CampaignId)
                    .HasColumnName("campaign_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CampaignDetail)
                    .IsRequired()
                    .HasColumnName("campaign_detail")
                    .HasMaxLength(50);

                entity.Property(e => e.CampaignType)
                    .IsRequired()
                    .HasColumnName("campaign_type")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ValidationTime)
                    .HasColumnName("validation_time")
                    .HasColumnType("date");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Campaign_Product1");
            });

            modelBuilder.Entity<Case>(entity =>
            {
                entity.Property(e => e.CaseId)
                    .HasColumnName("case_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.MoneyAmount).HasColumnName("money_amount");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Case)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Case_Employee");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(50);

                entity.Property(e => e.CategoryType)
                    .IsRequired()
                    .HasColumnName("category_type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeeAddress)
                    .IsRequired()
                    .HasColumnName("employee_address")
                    .HasMaxLength(100);

                entity.Property(e => e.EmployeeBirthdate)
                    .HasColumnName("employee_birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.EmployeeInsurance)
                    .IsRequired()
                    .HasColumnName("employee_insurance")
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasColumnName("employee_name")
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeePhone).HasColumnName("employee_phone");

                entity.Property(e => e.EmployeeSalary).HasColumnName("employee_salary");

                entity.Property(e => e.EmployeeWorkhour).HasColumnName("employee_workhour");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ProductBarcode).HasColumnName("product_barcode");

                entity.Property(e => e.ProductCount).HasColumnName("product_count");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductWeight).HasColumnName("product_weight");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.Property(e => e.ShoppingCartId)
                    .HasColumnName("shopping_cart_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BillId).HasColumnName("bill_id");

                entity.Property(e => e.ShoppingHistory)
                    .IsRequired()
                    .HasColumnName("shopping_history")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.BillNavigation)
                    .WithMany(p => p.ShoppingCartNavigation)
                    .HasForeignKey(d => d.BillId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingCart_Bill");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.UserAddress)
                    .IsRequired()
                    .HasColumnName("user_address")
                    .HasMaxLength(100);

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("user_email")
                    .HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("user_password")
                    .HasMaxLength(50);

                entity.Property(e => e.UserPhone).HasColumnName("user_phone");
            });
        }
    }
}
