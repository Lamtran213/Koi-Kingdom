using System;
using System.Collections.Generic;
using KoiKingdom_BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace KoiKingdom_DAOs
{
    public partial class KOI_PRNContext : DbContext
    {
        public KOI_PRNContext()
        {

        }
        public KOI_PRNContext(string connectionString)
        {
            this.Database.SetConnectionString(connectionString);
        }

        public KOI_PRNContext(DbContextOptions<KOI_PRNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Customtourrequest> Customtourrequests { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Farm> Farms { get; set; } = null!;
        public virtual DbSet<Favoritetour> Favoritetours { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<KoiFarm> KoiFarms { get; set; } = null!;
        public virtual DbSet<Koi> Kois { get; set; } = null!;
        public virtual DbSet<Koiorder> Koiorders { get; set; } = null!;
        public virtual DbSet<Koiorderdetail> Koiorderdetails { get; set; } = null!;
        public virtual DbSet<Koitype> Koitypes { get; set; } = null!;
        public virtual DbSet<Tour> Tours { get; set; } = null!;
        public virtual DbSet<TourFarm> TourFarms { get; set; } = null!;
        public virtual DbSet<TourFeedback> TourFeedbacks { get; set; } = null!;
        public virtual DbSet<TourKoitype> TourKoitypes { get; set; } = null!;
        public virtual DbSet<Tourbookingdetail> Tourbookingdetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:DefaultConnectionStringDB"];

            return strConn;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("BOOKING");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Email).HasMaxLength(254);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ShippingAddress).HasMaxLength(255);

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.Property(e => e.TourType).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BOOKING__Custome__6E01572D");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BOOKING__TourID__6EF57B66");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AccountType).HasMaxLength(128);

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(254);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(150);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Customtourrequest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CUSTOMTOURREQUEST");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DepartureLocation).HasMaxLength(100);

                entity.Property(e => e.DetailRejected).HasMaxLength(255);

                entity.Property(e => e.Duration).HasMaxLength(50);

                entity.Property(e => e.FarmName).HasMaxLength(100);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KoiTypeName).HasMaxLength(255);

                entity.Property(e => e.ManagerApprovalStatus).HasMaxLength(20);

                entity.Property(e => e.QuotationPrice).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.RequestId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RequestID");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CUSTOMTOURREQUEST_CUSTOMER");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(150);

                entity.Property(e => e.Role).HasMaxLength(20);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Farm>(entity =>
            {
                entity.ToTable("FARM");

                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.FarmName).HasMaxLength(100);

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Favoritetour>(entity =>
            {
                entity.ToTable("FAVORITETOUR");

                entity.Property(e => e.FavoriteTourId).HasColumnName("FavoriteTourID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Favoritetours)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FAVORITET__Custo__70DDC3D8");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.Favoritetours)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FAVORITET__TourI__71D1E811");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("FEEDBACK");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FEEDBACK__Custom__73BA3083");
            });

            modelBuilder.Entity<KoiFarm>(entity =>
            {
                entity.ToTable("KOI_FARM");

                entity.Property(e => e.KoiFarmId).HasColumnName("KoiFarmID");

                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.Property(e => e.KoiId).HasColumnName("KoiID");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.KoiFarms)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KOI_FARM__FarmID__74AE54BC");

                entity.HasOne(d => d.Koi)
                    .WithMany(p => p.KoiFarms)
                    .HasForeignKey(d => d.KoiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KOI_FARM__KoiID__75A278F5");
            });

            modelBuilder.Entity<Koi>(entity =>
            {
                entity.HasKey(e => e.KoiId)
                    .HasName("PK__KOI__E03435B828ABE075");

                entity.ToTable("KOI");

                entity.Property(e => e.KoiId).HasColumnName("KoiID");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KoiName).HasMaxLength(100);

                entity.Property(e => e.KoiTypeId).HasColumnName("KoiTypeID");

                entity.Property(e => e.Length).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.Weight).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.KoiType)
                    .WithMany(p => p.KoiPrns)
                    .HasForeignKey(d => d.KoiTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KOI" +
                    "" +
                    "" +
                    "__KoiType__73BA3083");
            });

            modelBuilder.Entity<Koiorder>(entity =>
            {
                entity.ToTable("KOIORDER");

                entity.Property(e => e.KoiOrderId).HasColumnName("KoiOrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Koiorders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KOIORDER__Custom__76969D2E");
            });

            modelBuilder.Entity<Koiorderdetail>(entity =>
            {
                entity.ToTable("KOIORDERDETAIL");

                entity.Property(e => e.KoiOrderDetailId).HasColumnName("KoiOrderDetailID");

                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.Property(e => e.KoiId).HasColumnName("KoiID");

                entity.Property(e => e.KoiOrderId).HasColumnName("KoiOrderID");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(15, 2)");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.Koiorderdetails)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KOIORDERD__FarmI__778AC167");

                entity.HasOne(d => d.Koi)
                    .WithMany(p => p.Koiorderdetails)
                    .HasForeignKey(d => d.KoiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KOIORDERD__KoiID__787EE5A0");

                entity.HasOne(d => d.KoiOrder)
                    .WithMany(p => p.Koiorderdetails)
                    .HasForeignKey(d => d.KoiOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KOIORDERD__KoiOr__797309D9");
            });

            modelBuilder.Entity<Koitype>(entity =>
            {
                entity.ToTable("KOITYPE");

                entity.Property(e => e.KoiTypeId).HasColumnName("KoiTypeID");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.KoiTypeStatus)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeName).HasMaxLength(255);
            });

            modelBuilder.Entity<Tour>(entity =>
            {
                entity.ToTable("TOUR");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.Property(e => e.DepartureLocation).HasMaxLength(100);

                entity.Property(e => e.Duration).HasMaxLength(50);

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TourName).HasMaxLength(255);

                entity.Property(e => e.TourPrice).HasColumnType("decimal(15, 2)");
            });

            modelBuilder.Entity<TourFarm>(entity =>
            {
                entity.ToTable("TOUR_FARM");

                entity.Property(e => e.TourFarmId).HasColumnName("TourFarmID");

                entity.Property(e => e.FarmId).HasColumnName("FarmID");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.HasOne(d => d.Farm)
                    .WithMany(p => p.TourFarms)
                    .HasForeignKey(d => d.FarmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TOUR_FARM__FarmI__7A672E12");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourFarms)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TOUR_FARM__TourI__7B5B524B");
            });

            modelBuilder.Entity<TourFeedback>(entity =>
            {
                entity.ToTable("TOUR_FEEDBACK");

                entity.Property(e => e.TourFeedbackId).HasColumnName("TourFeedbackID");

                entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.HasOne(d => d.Feedback)
                    .WithMany(p => p.TourFeedbacks)
                    .HasForeignKey(d => d.FeedbackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TOUR_FEED__Feedb__7D439ABD");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourFeedbacks)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TOUR_FEED__TourI__7D439ABD");
            });

            modelBuilder.Entity<TourKoitype>(entity =>
            {
                entity.ToTable("TOUR_KOITYPE");

                entity.Property(e => e.TourKoiTypeId).HasColumnName("TourKoiTypeID");

                entity.Property(e => e.KoiTypeId).HasColumnName("KoiTypeID");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.HasOne(d => d.KoiType)
                    .WithMany(p => p.TourKoitypes)
                    .HasForeignKey(d => d.KoiTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TOUR_KOIT__KoiTy__7E37BEF6");

                entity.HasOne(d => d.Tour)
                    .WithMany(p => p.TourKoitypes)
                    .HasForeignKey(d => d.TourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TOUR_KOIT__TourI__7F2BE32F");
            });

            modelBuilder.Entity<Tourbookingdetail>(entity =>
            {
                entity.HasKey(e => e.TourBookingDetail1)
                    .HasName("PK__TOURBOOK__5EE415E6532F76FA");

                entity.ToTable("TOURBOOKINGDETAIL");

                entity.Property(e => e.TourBookingDetail1).HasColumnName("TourBookingDetail");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Status).HasMaxLength(20);

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.TourId).HasColumnName("TourID");

                entity.Property(e => e.TourType).HasMaxLength(50);

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(15, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
