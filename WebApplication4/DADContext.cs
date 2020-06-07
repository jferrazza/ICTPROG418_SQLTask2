using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication4
{
    public partial class DADContext : DbContext
    {
        public DADContext()
        {
        }

        public DADContext(DbContextOptions<DADContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accountpayment6925> Accountpayment6925 { get; set; }
        public virtual DbSet<AlliNformation> AlliNformation { get; set; }
        public virtual DbSet<Attendence> Attendence { get; set; }
        public virtual DbSet<Authorisedperson6925> Authorisedperson6925 { get; set; }
        public virtual DbSet<Bookings> Bookings { get; set; }
        public virtual DbSet<Clientaccount6925> Clientaccount6925 { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Colourtype6925> Colourtype6925 { get; set; }
        public virtual DbSet<CourseeVents> CourseeVents { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Generalledger6925> Generalledger6925 { get; set; }
        public virtual DbSet<Inventory6925> Inventory6925 { get; set; }
        public virtual DbSet<Location6925> Location6925 { get; set; }
        public virtual DbSet<Order6925> Order6925 { get; set; }
        public virtual DbSet<Orderline6925> Orderline6925 { get; set; }
        public virtual DbSet<Product6925> Product6925 { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Purchaseorder6925> Purchaseorder6925 { get; set; }
        public virtual DbSet<Rating6925> Rating6925 { get; set; }
        public virtual DbSet<Seminar> Seminar { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Staffallocation> Staffallocation { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Tour> Tour { get; set; }
        public virtual DbSet<ToureVents> ToureVents { get; set; }
        public virtual DbSet<Tours> Tours { get; set; }
        public virtual DbSet<Worker> Worker { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(Startup.constring);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accountpayment6925>(entity =>
            {
                entity.HasKey(e => new { e.Accountid, e.Datetimereceived })
                    .HasName("PK_ACCOUNTPAYMENT");

                entity.ToTable("ACCOUNTPAYMENT6925");

                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Datetimereceived)
                    .HasColumnName("DATETIMERECEIVED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("money");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Accountpayment6925)
                    .HasForeignKey(d => d.Accountid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ACCOUNTPAYMENT_ACCOUNT");
            });

            modelBuilder.Entity<AlliNformation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("AlliNFORMATION");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Datebooked)
                    .HasColumnName("datebooked")
                    .HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Eventday).HasColumnName("eventday");

                entity.Property(e => e.Eventmonth)
                    .IsRequired()
                    .HasColumnName("eventmonth")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Eventyear).HasColumnName("eventyear");

                entity.Property(e => e.Fee).HasColumnName("fee");

                entity.Property(e => e.Payment).HasColumnName("payment");

                entity.Property(e => e.Tourname)
                    .IsRequired()
                    .HasColumnName("tourname")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Attendence>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ATTENDENCE");

                entity.Property(e => e.Score).HasColumnName("SCORE");

                entity.Property(e => e.Semid).HasColumnName("SEMID");

                entity.Property(e => e.Stuid).HasColumnName("STUID");

                entity.HasOne(d => d.Sem)
                    .WithMany()
                    .HasForeignKey(d => d.Semid)
                    .HasConstraintName("FK__ATTENDENC__SEMID__7755B73D");

                entity.HasOne(d => d.Stu)
                    .WithMany()
                    .HasForeignKey(d => d.Stuid)
                    .HasConstraintName("FK__ATTENDENC__STUID__76619304");
            });

            modelBuilder.Entity<Authorisedperson6925>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK_AUTHORISEDPERSON");

                entity.ToTable("AUTHORISEDPERSON6925");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("PASSWORD")
                    .HasMaxLength(100);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("SURNAME")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Authorisedperson6925)
                    .HasForeignKey(d => d.Accountid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AUTHORISEDPERSON_CLIENTACCOUNT");
            });

            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.TourName, e.EventMonth, e.EventDay, e.EventYear, e.DateBooked })
                    .HasName("PK__BOOKINGS__935D1D5DB7958865");

                entity.ToTable("BOOKINGS");

                entity.Property(e => e.TourName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EventMonth)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.DateBooked).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BOOKINGS__Client__4FD1D5C8");

                entity.HasOne(d => d.ToureVents)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => new { d.TourName, d.EventMonth, d.EventDay, d.EventYear })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BOOKINGS__4EDDB18F");
            });

            modelBuilder.Entity<Clientaccount6925>(entity =>
            {
                entity.HasKey(e => e.Accountid)
                    .HasName("PK_CLIENTACCOUNT");

                entity.ToTable("CLIENTACCOUNT6925");

                entity.HasIndex(e => e.Acctname)
                    .HasName("UQ_CLENTACCOUNT_NAME")
                    .IsUnique();

                entity.Property(e => e.Accountid).HasColumnName("ACCOUNTID");

                entity.Property(e => e.Acctname)
                    .IsRequired()
                    .HasColumnName("ACCTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Balance)
                    .HasColumnName("BALANCE")
                    .HasColumnType("money");

                entity.Property(e => e.Creditlimit)
                    .HasColumnName("CREDITLIMIT")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PK__CLIENTS__E67E1A242DD0FB69");

                entity.ToTable("CLIENTS");

                entity.Property(e => e.ClientId).ValueGeneratedNever();

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.GivenName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Colourtype6925>(entity =>
            {
                entity.HasKey(e => e.Colourcode)
                    .HasName("PK__COLOURTY__9D6DEEBDE78065D8");

                entity.ToTable("COLOURTYPE6925");

                entity.Property(e => e.Colourcode)
                    .HasColumnName("COLOURCODE")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Colourname)
                    .HasColumnName("COLOURNAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CourseeVents>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.EventMonth, e.EventDay, e.EventYear })
                    .HasName("PK__COURSEeV__25725DDCC4F8812B");

                entity.ToTable("COURSEeVENTS");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.EventMonth)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseeVents)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COURSEeVE__Cours__66EA454A");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK__COURSES__C92D71870C675FAB");

                entity.ToTable("COURSES");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__CUSTOMER__A4AE64B880A7B031");

                entity.ToTable("CUSTOMERS");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GivenName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Generalledger6925>(entity =>
            {
                entity.HasKey(e => e.Itemid)
                    .HasName("PK_GENERALLEDGER");

                entity.ToTable("GENERALLEDGER6925");

                entity.HasIndex(e => e.Description)
                    .HasName("UQ_GENERALEDGER_DESCRIPTION")
                    .IsUnique();

                entity.Property(e => e.Itemid)
                    .HasColumnName("ITEMID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Amount)
                    .HasColumnName("AMOUNT")
                    .HasColumnType("money");

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Inventory6925>(entity =>
            {
                entity.HasKey(e => new { e.Productid, e.Locationid })
                    .HasName("PK_INVENTORY");

                entity.ToTable("INVENTORY6925");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Locationid)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.Numinstock).HasColumnName("NUMINSTOCK");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Inventory6925)
                    .HasForeignKey(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INVENTORY_LOCATION");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventory6925)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_INVENTORY_PRODUCT");
            });

            modelBuilder.Entity<Location6925>(entity =>
            {
                entity.HasKey(e => e.Locationid)
                    .HasName("PK_LOCATION");

                entity.ToTable("LOCATION6925");

                entity.Property(e => e.Locationid)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("ADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.Locname)
                    .IsRequired()
                    .HasColumnName("LOCNAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Manager)
                    .HasColumnName("MANAGER")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Order6925>(entity =>
            {
                entity.HasKey(e => e.Orderid)
                    .HasName("PK_ORDER");

                entity.ToTable("ORDER6925");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Datetimecreated)
                    .HasColumnName("DATETIMECREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Datetimedispatched)
                    .HasColumnName("DATETIMEDISPATCHED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Shippingaddress)
                    .IsRequired()
                    .HasColumnName("SHIPPINGADDRESS")
                    .HasMaxLength(200);

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("money");

                entity.Property(e => e.Userid).HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Order6925)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDER_AUTHORISEDPERSON");
            });

            modelBuilder.Entity<Orderline6925>(entity =>
            {
                entity.HasKey(e => new { e.Orderid, e.Productid })
                    .HasName("PK_ORDERLINE");

                entity.ToTable("ORDERLINE6925");

                entity.Property(e => e.Orderid).HasColumnName("ORDERID");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Discount)
                    .HasColumnName("DISCOUNT")
                    .HasColumnType("decimal(18, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("SUBTOTAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderline6925)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERLINE_ORDER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderline6925)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ORDERLINE_PRODUCT");
            });

            modelBuilder.Entity<Product6925>(entity =>
            {
                entity.HasKey(e => e.Productid)
                    .HasName("PK_PRODUCT");

                entity.ToTable("PRODUCT6925");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Buyprice)
                    .HasColumnName("BUYPRICE")
                    .HasColumnType("money");

                entity.Property(e => e.Prodname)
                    .IsRequired()
                    .HasColumnName("PRODNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Sellprice)
                    .HasColumnName("SELLPRICE")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(e => e.ProjCode)
                    .HasName("PK__PROJECT__0F9F4F7656F418EB");

                entity.ToTable("PROJECT");

                entity.Property(e => e.ProjCode).ValueGeneratedNever();

                entity.Property(e => e.ProjectTitle).HasMaxLength(100);
            });

            modelBuilder.Entity<Purchaseorder6925>(entity =>
            {
                entity.HasKey(e => new { e.Productid, e.Locationid, e.Datetimecreated })
                    .HasName("PK_PURCHASEORDER");

                entity.ToTable("PURCHASEORDER6925");

                entity.Property(e => e.Productid).HasColumnName("PRODUCTID");

                entity.Property(e => e.Locationid)
                    .HasColumnName("LOCATIONID")
                    .HasMaxLength(8);

                entity.Property(e => e.Datetimecreated)
                    .HasColumnName("DATETIMECREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasColumnName("QUANTITY");

                entity.Property(e => e.Total)
                    .HasColumnName("TOTAL")
                    .HasColumnType("money");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Purchaseorder6925)
                    .HasForeignKey(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PURCHASEORDER_LOCATION");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Purchaseorder6925)
                    .HasForeignKey(d => d.Productid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PURCHASEORDER_PRODUCT");
            });

            modelBuilder.Entity<Rating6925>(entity =>
            {
                entity.HasKey(e => e.Ratingcode)
                    .HasName("PK__RATING69__FB04230C226D66B3");

                entity.ToTable("RATING6925");

                entity.Property(e => e.Ratingcode)
                    .HasColumnName("RATINGCODE")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Longdesc)
                    .HasColumnName("LONGDESC")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Shortdesc)
                    .HasColumnName("SHORTDESC")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Seminar>(entity =>
            {
                entity.HasKey(e => e.Semid)
                    .HasName("PK__SEMINAR__B494B448E47EC980");

                entity.ToTable("SEMINAR");

                entity.Property(e => e.Semid)
                    .HasColumnName("SEMID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Sdate)
                    .HasColumnName("SDATE")
                    .HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasColumnName("TITLE")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.Stfid)
                    .HasName("PK__STAFF__E09AF1E16752ABEB");

                entity.ToTable("STAFF");

                entity.Property(e => e.Stfid)
                    .HasColumnName("STFID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fullname)
                    .HasColumnName("FULLNAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staffallocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("STAFFALLOCATION");

                entity.Property(e => e.Semid).HasColumnName("SEMID");

                entity.Property(e => e.Stfid).HasColumnName("STFID");

                entity.HasOne(d => d.Sem)
                    .WithMany()
                    .HasForeignKey(d => d.Semid)
                    .HasConstraintName("FK__STAFFALLO__SEMID__73852659");

                entity.HasOne(d => d.Stf)
                    .WithMany()
                    .HasForeignKey(d => d.Stfid)
                    .HasConstraintName("FK__STAFFALLO__STFID__74794A92");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Stuid)
                    .HasName("PK__STUDENT__EB54633F8AED4FDB");

                entity.ToTable("STUDENT");

                entity.Property(e => e.Stuid)
                    .HasColumnName("STUID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Fullname)
                    .HasColumnName("FULLNAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("GENDER")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.HasKey(e => e.TourName)
                    .HasName("PK__TOUR__760BA96586FB730E");

                entity.ToTable("TOUR");

                entity.Property(e => e.TourName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ToureVents>(entity =>
            {
                entity.HasKey(e => new { e.TourName, e.EventMonth, e.EventDay, e.EventYear })
                    .HasName("PK__TOUReVEN__9A54853E33F70BA9");

                entity.ToTable("TOUReVENTS");

                entity.Property(e => e.TourName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EventMonth)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.TourNameNavigation)
                    .WithMany(p => p.ToureVents)
                    .HasForeignKey(d => d.TourName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TOUReVENT__TourN__4C0144E4");
            });

            modelBuilder.Entity<Tours>(entity =>
            {
                entity.HasKey(e => e.TourName)
                    .HasName("PK__TOURS__760BA9659A9739AC");

                entity.ToTable("TOURS");

                entity.Property(e => e.TourName)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.Wid)
                    .HasName("PK__WORKER__DB366111EEA4539A");

                entity.ToTable("WORKER");

                entity.Property(e => e.Wid).ValueGeneratedNever();

                entity.Property(e => e.Gender).HasMaxLength(1);

                entity.Property(e => e.Wname)
                    .HasColumnName("WName")
                    .HasMaxLength(100);

                entity.HasOne(d => d.ProjectNavigation)
                    .WithMany(p => p.Worker)
                    .HasForeignKey(d => d.Project)
                    .HasConstraintName("FK__WORKER__Project__3587F3E0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
