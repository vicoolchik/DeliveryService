using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DeliveryService.DAL.Models
{
    public partial class ProductcompanyContext : DbContext
    {
        public ProductcompanyContext()
        {
        }

        public ProductcompanyContext(DbContextOptions<ProductcompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderdetail> Orderdetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=qaz16073011;Database=Product company");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_Ukraine.1251");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("category_name");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.RowInsertTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_insert_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.RowUpdateTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_update_time")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Counrty)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("counrty");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("customer_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.RowInsertTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_insert_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.RowUpdateTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_update_time")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.BankCard)
                    .HasMaxLength(19)
                    .HasColumnName("bank_card");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Counrty)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("counrty");

                entity.Property(e => e.EmployeeFname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("employee_fname");

                entity.Property(e => e.EmployeeLname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("employee_lname");

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(15)
                    .HasColumnName("home_phone");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.RowInsertTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_insert_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.RowUpdateTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_update_time")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.Counrty)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("counrty");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("order_date");

                entity.Property(e => e.RequiredDate)
                    .HasColumnType("date")
                    .HasColumnName("required_date");

                entity.Property(e => e.RowInsertTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_insert_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.RowUpdateTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_update_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ShippedDate)
                    .HasColumnType("date")
                    .HasColumnName("shipped_date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_employees");
            });

            modelBuilder.Entity<Orderdetail>(entity =>
            {
                entity.HasKey(e => e.OrderdetailsId)
                    .HasName("orderdetails_pkey");

                entity.ToTable("orderdetails");

                entity.Property(e => e.OrderdetailsId)
                    .HasColumnName("orderdetails_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("order_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.RowInsertTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_insert_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.RowUpdateTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_update_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasColumnName("unit_price");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderdetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_products");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .HasColumnName("description");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.RowInsertTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_insert_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.RowUpdateTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_update_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasColumnName("unit_price");

                entity.Property(e => e.UnitsInStock).HasColumnName("units_in_stock");

                entity.Property(e => e.UnitsOnOnder).HasColumnName("units_on_onder");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_categories");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_suppliers");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("suppliers");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("supplier_id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("company_name");

                entity.Property(e => e.Counrty)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("counrty");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.RowInsertTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_insert_time")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.RowUpdateTime)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("row_update_time")
                    .HasDefaultValueSql("now()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
