using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fund_system.Models
{
    public partial class Fund_SystemDbContext : DbContext
    {
        public Fund_SystemDbContext()
        {
        }

        public Fund_SystemDbContext(DbContextOptions<Fund_SystemDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressBook> AddressBook { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<FundOrders> FundOrders { get; set; }
        public virtual DbSet<Funds> Funds { get; set; }
        public virtual DbSet<Holdings> Holdings { get; set; }
        public virtual DbSet<InsStatus> InsStatus { get; set; }
        public virtual DbSet<Insurance> Insurance { get; set; }
        public virtual DbSet<InvProfile> InvProfile { get; set; }
        public virtual DbSet<Prices> Prices { get; set; }
        public virtual DbSet<ProductRules> ProductRules { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskOnGoing> TaskOnGoing { get; set; }
        public virtual DbSet<TaskOrders> TaskOrders { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Fund_SystemDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressBook>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("PK__AddressB__03BDEBBA00A55CEE");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CountryCode)
                    .HasColumnName("Country_Code")
                    .HasMaxLength(10);

                entity.Property(e => e.PostalCode)
                    .HasColumnName("Postal_Code")
                    .HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(100);
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PK__Clients__75A5D8F85A2D55F7");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.AddressId).HasColumnName("Address_Id");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("Birth_Date")
                    .HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .HasColumnName("First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.MDate)
                    .HasColumnName("M-Date")
                    .HasColumnType("date");

                entity.Property(e => e.MiddleName)
                    .HasColumnName("Middle_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.SsnNo)
                    .HasColumnName("Ssn_No")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__Clients__Address__25869641");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.CompanyCode)
                    .HasColumnName("Company_Code")
                    .HasMaxLength(50);

                entity.Property(e => e.CompanyName)
                    .HasColumnName("Company_Name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<FundOrders>(entity =>
            {
                entity.HasKey(e => e.FundOrderId)
                    .HasName("PK__Fund_Ord__67999CCAC094D66C");

                entity.ToTable("Fund_Orders");

                entity.Property(e => e.FundOrderId).HasColumnName("Fund_Order_Id");

                entity.Property(e => e.DateOrder)
                    .HasColumnName("Date_Order")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.FundId).HasColumnName("Fund_Id");

                entity.Property(e => e.FundOrderNo).HasColumnName("Fund_Order_No");

                entity.Property(e => e.FundOrderStatus)
                    .HasColumnName("Fund_Order_Status")
                    .HasMaxLength(50);

                entity.Property(e => e.FundPrice).HasColumnName("Fund_Price");

                entity.Property(e => e.OrderAmount).HasColumnName("Order_Amount");

                entity.Property(e => e.OrderNoUnits)
                    .HasColumnName("Order_No_Units")
                    .HasMaxLength(50);

                entity.Property(e => e.TypeOrder)
                    .HasColumnName("Type_Order")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Funds>(entity =>
            {
                entity.HasKey(e => e.FundId)
                    .HasName("PK__Funds__A025A65579C2C4DE");

                entity.Property(e => e.FundId).HasColumnName("Fund_Id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.FundNo)
                    .HasColumnName("Fund_No")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Funds)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Funds__Company_I__2C3393D0");
            });

            modelBuilder.Entity<Holdings>(entity =>
            {
                entity.HasKey(e => e.HoldingId)
                    .HasName("PK__Holdings__0BC9BA23365DCD6B");

                entity.Property(e => e.HoldingId).HasColumnName("Holding_Id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.DateHolding)
                    .HasColumnName("Date_Holding")
                    .HasColumnType("date");

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("date");

                entity.Property(e => e.FundId).HasColumnName("Fund_Id");

                entity.Property(e => e.FundPrice).HasColumnName("Fund_Price");

                entity.Property(e => e.NoOfUnits)
                    .HasColumnName("No_Of_Units")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Holdings)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Holdings__Compan__3B75D760");

                entity.HasOne(d => d.Fund)
                    .WithMany(p => p.Holdings)
                    .HasForeignKey(d => d.FundId)
                    .HasConstraintName("FK__Holdings__Fund_I__3C69FB99");
            });

            modelBuilder.Entity<InsStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__INS-Stat__5190094C731FBEFE");

                entity.ToTable("INS-Status");

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.Property(e => e.StatusName)
                    .HasColumnName("Status_Name")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Insurance>(entity =>
            {
                entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("date");

                entity.Property(e => e.HoldingId).HasColumnName("Holding_Id");

                entity.Property(e => e.InsuranceNo)
                    .HasColumnName("Insurance_No")
                    .HasMaxLength(50);

                entity.Property(e => e.Nominee)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("date");

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.Property(e => e.ZDate)
                    .HasColumnName("Z-date")
                    .HasColumnType("date");

                entity.Property(e => e.ZEndDate)
                    .HasColumnName("Z-endDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Insurance)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK__Insurance__Clien__4CA06362");

                entity.HasOne(d => d.Holding)
                    .WithMany(p => p.Insurance)
                    .HasForeignKey(d => d.HoldingId)
                    .HasConstraintName("FK__Insurance__Holdi__4D94879B");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Insurance)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK__Insurance__Statu__4E88ABD4");
            });

            modelBuilder.Entity<InvProfile>(entity =>
            {
                entity.ToTable("Inv-Profile");

                entity.Property(e => e.InvProfileId).HasColumnName("Inv-Profile_Id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("date");

                entity.Property(e => e.FundId).HasColumnName("Fund_Id");

                entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");

                entity.Property(e => e.InsuranceNo)
                    .HasColumnName("Insurance_No")
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnName("Start_Date")
                    .HasColumnType("date");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.InvProfile)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Inv-Profi__Compa__5165187F");

                entity.HasOne(d => d.Fund)
                    .WithMany(p => p.InvProfile)
                    .HasForeignKey(d => d.FundId)
                    .HasConstraintName("FK__Inv-Profi__Fund___534D60F1");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.InvProfile)
                    .HasForeignKey(d => d.InsuranceId)
                    .HasConstraintName("FK__Inv-Profi__Insur__52593CB8");
            });

            modelBuilder.Entity<Prices>(entity =>
            {
                entity.HasKey(e => e.PriceId)
                    .HasName("PK__Prices__A4821BD2E3A8C040");

                entity.Property(e => e.PriceId).HasColumnName("Price_Id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.DatePrice).HasColumnName("Date_price");

                entity.Property(e => e.FindPrice).HasColumnName("Find_price");

                entity.Property(e => e.FundId).HasColumnName("Fund_Id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Prices__Company___571DF1D5");

                entity.HasOne(d => d.Fund)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.FundId)
                    .HasConstraintName("FK__Prices__Fund_Id__5629CD9C");
            });

            modelBuilder.Entity<ProductRules>(entity =>
            {
                entity.ToTable("Product_Rules");

                entity.Property(e => e.ProductRulesId)
                    .HasColumnName("Product_Rules_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ClaimPeriod)
                    .HasColumnName("Claim_Period")
                    .HasMaxLength(200);

                entity.Property(e => e.EndDate)
                    .HasColumnName("End_Date")
                    .HasColumnType("date");

                entity.Property(e => e.MoveAbility)
                    .HasColumnName("Move_Ability")
                    .HasMaxLength(200);

                entity.Property(e => e.Nominee)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.ZAge).HasColumnName("Z-age");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Products__9834FBBABA3A0288");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ProductFee).HasColumnName("Product_Fee");

                entity.Property(e => e.ProductName)
                    .HasColumnName("Product_Name")
                    .HasMaxLength(100);

                entity.Property(e => e.TaxFee).HasColumnName("Tax_Fee");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.TaskId).HasColumnName("Task_Id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.TaskAmount).HasColumnName("Task_Amount");

                entity.Property(e => e.TaskDate)
                    .HasColumnName("Task_Date")
                    .HasColumnType("date");

                entity.Property(e => e.TaskEndDate)
                    .HasColumnName("Task_End_Date")
                    .HasColumnType("date");

                entity.Property(e => e.TaskFee).HasColumnName("Task_Fee");

                entity.Property(e => e.TaskNo)
                    .HasColumnName("Task_No")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskOrderId).HasColumnName("Task_Order_Id");

                entity.Property(e => e.TaskOrderNum)
                    .HasColumnName("Task_Order_num")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskStartId)
                    .HasColumnName("Task_Start_Id")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskStatus)
                    .HasColumnName("Task_Status")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Task__Company_Id__5DCAEF64");
            });

            modelBuilder.Entity<TaskOnGoing>(entity =>
            {
                entity.ToTable("Task-On-Going");

                entity.Property(e => e.TaskOnGoingId).HasColumnName("Task-On-Going_Id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.FundId).HasColumnName("Fund_Id");

                entity.Property(e => e.FundPrice).HasColumnName("Fund_Price");

                entity.Property(e => e.InsuranceId).HasColumnName("Insurance_Id");

                entity.Property(e => e.InsuranceNo)
                    .HasColumnName("Insurance_No")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskAmount).HasColumnName("Task_Amount");

                entity.Property(e => e.TaskEndDate)
                    .HasColumnName("Task_End_Date")
                    .HasColumnType("date");

                entity.Property(e => e.TaskNo)
                    .HasColumnName("Task_No")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskNoOfUnits)
                    .HasColumnName("TaskNo_of_Units")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskOrderId).HasColumnName("Task_Order_Id");

                entity.Property(e => e.TaskStartDate)
                    .HasColumnName("Task_Start_Date")
                    .HasColumnType("date");

                entity.Property(e => e.TypeOfTask)
                    .HasColumnName("Type_of_Task")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TaskOnGoing)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Task-On-G__Compa__7D439ABD");

                entity.HasOne(d => d.Insurance)
                    .WithMany(p => p.TaskOnGoing)
                    .HasForeignKey(d => d.InsuranceId)
                    .HasConstraintName("FK__Task-On-G__Insur__7E37BEF6");

                entity.HasOne(d => d.TaskOrder)
                    .WithMany(p => p.TaskOnGoing)
                    .HasForeignKey(d => d.TaskOrderId)
                    .HasConstraintName("FK__Task-On-G__Task___7C4F7684");
            });

            modelBuilder.Entity<TaskOrders>(entity =>
            {
                entity.HasKey(e => e.TaskOrderId)
                    .HasName("PK__Task_Ord__6D4C50D5A9E0F4EB");

                entity.ToTable("Task_Orders");

                entity.Property(e => e.TaskOrderId).HasColumnName("Task_Order_Id");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.TaskOrderNo)
                    .HasColumnName("Task_Order_No")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK__Tasks__716F4AED2D7110A5");

                entity.Property(e => e.TaskId).HasColumnName("Task_Id");

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.TaskAmount).HasColumnName("Task_Amount");

                entity.Property(e => e.TaskDate)
                    .HasColumnName("Task_Date")
                    .HasColumnType("date");

                entity.Property(e => e.TaskEndDate)
                    .HasColumnName("Task_End_Date")
                    .HasColumnType("date");

                entity.Property(e => e.TaskFee).HasColumnName("Task_Fee");

                entity.Property(e => e.TaskNo)
                    .HasColumnName("Task_No")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskOrderId).HasColumnName("Task_Order_Id");

                entity.Property(e => e.TaskOrderNum)
                    .HasColumnName("Task_Order_num")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskStartId)
                    .HasColumnName("Task_Start_Id")
                    .HasMaxLength(50);

                entity.Property(e => e.TaskStatus)
                    .HasColumnName("Task_Status")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Tasks__Company_I__01142BA1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
