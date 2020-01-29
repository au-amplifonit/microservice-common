using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fox.Microservices.Common.Models.Entities
{
    public partial class CommonContext : DbContext
    {
        public CommonContext()
        {
        }

        public CommonContext(DbContextOptions<CommonContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AG_S_SERVICE> AG_S_SERVICE { get; set; }
        public virtual DbSet<AG_S_SERVICE_EXT_AUS> AG_S_SERVICE_EXT_AUS { get; set; }
        public virtual DbSet<AG_S_SERVICE_TYPE> AG_S_SERVICE_TYPE { get; set; }
        public virtual DbSet<CM_B_ADDRESS> CM_B_ADDRESS { get; set; }
        public virtual DbSet<CM_B_SHOP> CM_B_SHOP { get; set; }
        public virtual DbSet<CM_S_CITY_BOOK> CM_S_CITY_BOOK { get; set; }
        public virtual DbSet<CM_S_DAYCENTER> CM_S_DAYCENTER { get; set; }
        public virtual DbSet<CM_S_DAYCENTER_EXT_AUS> CM_S_DAYCENTER_EXT_AUS { get; set; }
        public virtual DbSet<CM_S_EMPLOYEE> CM_S_EMPLOYEE { get; set; }
        public virtual DbSet<CM_S_REFERENCE_SOURCE_EXT_AUS> CM_S_REFERENCE_SOURCE_EXT_AUS { get; set; }
        public virtual DbSet<CM_S_STATE_EXT_AUS> CM_S_STATE_EXT_AUS { get; set; }
        public virtual DbSet<CU_S_CATEGORY> CU_S_CATEGORY { get; set; }
        public virtual DbSet<CU_S_CUSTOMER_TYPE_EXT_AUS> CU_S_CUSTOMER_TYPE_EXT_AUS { get; set; }
        public virtual DbSet<CU_S_SALUTATION> CU_S_SALUTATION { get; set; }
        public virtual DbSet<CU_S_STATUS> CU_S_STATUS { get; set; }
        public virtual DbSet<CU_S_TYPE> CU_S_TYPE { get; set; }
        public virtual DbSet<SY_EMPLOYEE_TYPE> SY_EMPLOYEE_TYPE { get; set; }
        public virtual DbSet<SY_GENDER> SY_GENDER { get; set; }
        public virtual DbSet<SY_GENERAL_STATUS> SY_GENERAL_STATUS { get; set; }
        public virtual DbSet<SY_GENERAL_TYPE_EXT_AUS> SY_GENERAL_TYPE_EXT_AUS { get; set; }
        public virtual DbSet<SY_LANGUAGE> SY_LANGUAGE { get; set; }
        public virtual DbSet<SY_SHOP_TYPE> SY_SHOP_TYPE { get; set; }
        public virtual DbSet<US_B_USER> US_B_USER { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CAU02DB01FOXSIT.D09.ROOT.SYS;Database=FoxAustralia_SIT2;Trusted_Connection=False;User ID=foxuser;Password=Df0x35ZZ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AG_S_SERVICE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SERVICE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_AG_S_SERVICE_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SERVICE_TYPE_CODE })
                    .HasName("IDX_AG_S_SERVICE_AG_S_SERVICE_TYPE");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SERVICE_CODE).HasMaxLength(8);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLG_NEWJOURNEY).HasMaxLength(1);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SERVICE_DESCR).HasMaxLength(255);

                entity.Property(e => e.SERVICE_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.SHOP_CODE)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.AG_S_SERVICE_TYPE)
                    .WithMany(p => p.AG_S_SERVICE)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.SERVICE_TYPE_CODE })
                    .HasConstraintName("FK_AG_S_SERVICE_AG_S_SERVICE_TYPE");
            });

            modelBuilder.Entity<AG_S_SERVICE_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SERVICE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_AG_S_SERVICE_EXT_AUS_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SERVICE_CODE).HasMaxLength(8);

                entity.Property(e => e.BOOKING_BY).HasMaxLength(50);

                entity.Property(e => e.CHARGEABLE).HasMaxLength(1);

                entity.Property(e => e.COMPLETED_BY).HasMaxLength(50);

                entity.Property(e => e.DEFAULT_DURATION).HasMaxLength(10);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.MAXIMUM_DURATION).HasMaxLength(20);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SERVICE_PARENT_CODE).HasMaxLength(8);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(100);
            });

            modelBuilder.Entity<AG_S_SERVICE_TYPE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SERVICE_TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_AG_S_SERVICE_TYPE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SERVICE_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLG_ALLOW_APPOINTMENT).HasMaxLength(1);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SERVICE_TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_B_ADDRESS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.OBJ_CODE, e.OBJ_TYPE, e.ADDRESS_COUNTER })
                    .HasName("PK_CM_B_ADDRESSES");

                entity.HasIndex(e => e.OBJ_CODE)
                    .HasName("missing_index_26037");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_B_ADDRESSES_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.OBJ_CODE, e.OBJ_TYPE })
                    .HasName("missing_index_25485");

                entity.HasIndex(e => new { e.EMAIL, e.OBJ_CODE, e.OBJ_TYPE })
                    .HasName("missing_index_25479");

                entity.HasIndex(e => new { e.OBJ_CODE, e.EMAIL, e.OBJ_TYPE })
                    .HasName("missing_index_25481");

                entity.HasIndex(e => new { e.OBJ_TYPE, e.CITY_NAME, e.OBJ_CODE })
                    .HasName("missing_index_24903");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.OBJ_CODE).HasMaxLength(8);

                entity.Property(e => e.OBJ_TYPE).HasMaxLength(3);

                entity.Property(e => e.ADDRESS_LINE1).HasMaxLength(100);

                entity.Property(e => e.ADDRESS_LINE2).HasMaxLength(50);

                entity.Property(e => e.ADDRESS_LINE3).HasMaxLength(50);

                entity.Property(e => e.ADDRESS_LINE4).HasMaxLength(50);

                entity.Property(e => e.AREA_CODE).HasMaxLength(3);

                entity.Property(e => e.CITY_NAME).HasMaxLength(50);

                entity.Property(e => e.COUNTRY_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.EMAIL).HasMaxLength(50);

                entity.Property(e => e.FLGNORMALIZED).HasMaxLength(1);

                entity.Property(e => e.INVOICEDEFAULT).HasMaxLength(1);

                entity.Property(e => e.LETTER_DEFAULT).HasMaxLength(1);

                entity.Property(e => e.LOCALITY).HasMaxLength(50);

                entity.Property(e => e.MOBILE).HasMaxLength(30);

                entity.Property(e => e.PHONE1).HasMaxLength(30);

                entity.Property(e => e.PHONE2).HasMaxLength(30);

                entity.Property(e => e.PHONE3).HasMaxLength(30);

                entity.Property(e => e.PO_BOX).HasMaxLength(30);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.ZIP_CODE).HasMaxLength(15);

                entity.HasOne(d => d.CM_S_CITY_BOOK)
                    .WithMany(p => p.CM_B_ADDRESS)
                    .HasForeignKey(d => new { d.COUNTRY_CODE, d.AREA_CODE, d.ZIP_CODE, d.CITY_COUNTER })
                    .HasConstraintName("FK_Cm_B_ADDRESS_CM_S_CITY_BOOK");
            });

            modelBuilder.Entity<CM_B_SHOP>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE })
                    .HasName("PK_CM_SHOP");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_B_SHOP_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.ORGANIZATION_CODE })
                    .HasName("IDX_CM_B_SHOP_CM_S_ORGANIZATION");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_TYPE_CODE })
                    .HasName("IDX_CM_B_SHOP_SY_SHOP_TYPE");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLG_ACTIVE).HasMaxLength(1);

                entity.Property(e => e.LEGAL_DESCR).HasMaxLength(255);

                entity.Property(e => e.OBJ_CODE).HasMaxLength(8);

                entity.Property(e => e.ORGANIZATION_CODE).HasMaxLength(3);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SHOP_DESCR).HasMaxLength(255);

                entity.Property(e => e.SHOP_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.SY_SHOP_TYPE)
                    .WithMany(p => p.CM_B_SHOP)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.SHOP_TYPE_CODE })
                    .HasConstraintName("FK_CM_B_SHOP_SY_SHOP_TYPE");
            });

            modelBuilder.Entity<CM_S_CITY_BOOK>(entity =>
            {
                entity.HasKey(e => new { e.COUNTRY_CODE, e.AREA_CODE, e.ZIP_CODE, e.CITY_COUNTER })
                    .HasName("PK_CM_CITY_BOOK");

                entity.HasIndex(e => e.CITY_NAME);

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_S_CITY_BOOK_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => e.ZIP_CODE);

                entity.HasIndex(e => new { e.COUNTRY_CODE, e.AREA_CODE })
                    .HasName("IDX_CM_S_CITY_BOOK_CM_S_AREA_BOOK");

                entity.Property(e => e.COUNTRY_CODE).HasMaxLength(3);

                entity.Property(e => e.AREA_CODE).HasMaxLength(3);

                entity.Property(e => e.ZIP_CODE).HasMaxLength(15);

                entity.Property(e => e.CITY_NAME).HasMaxLength(25);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.ZIP_CODE_UNIQUE_ID).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_DAYCENTER>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DAYCENTER_CODE, e.SHOP_CODE });

                entity.HasIndex(e => e.DAYCENTER_DESCR)
                    .HasName("missing_index_11058");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_S_DAYCENTER_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.DAYCENTER_DESCR, e.DAYCENTER_CODE })
                    .HasName("missing_index_16109");

                entity.HasIndex(e => new { e.DAYCENTER_CODE, e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE })
                    .HasName("missing_index_2425");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DAYCENTER_CODE, e.SHOP_CODE, e.DT_INSERT, e.USERUPDATE, e.DT_UPDATE })
                    .HasName("missing_index_183");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.DAYCENTER_CODE).HasMaxLength(8);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.ACCOUNTING_ID).HasMaxLength(8);

                entity.Property(e => e.DAYCENTER_DESCR).HasMaxLength(255);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.MARKETING_ID).HasMaxLength(8);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_DAYCENTER_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.DAYCENTER_CODE, e.SHOP_CODE });

                entity.HasIndex(e => new { e.LOCATION_TYPE, e.DAYCENTER_CODE })
                    .HasName("missing_index_16107");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.DAYCENTER_CODE).HasMaxLength(8);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.LOCATION_TYPE).HasMaxLength(3);

                entity.Property(e => e.OHS_SITE_ID).HasMaxLength(20);

                entity.Property(e => e.USERINSERT)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.USERUPDATE)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CM_S_EMPLOYEE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE, e.EMPLOYEE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_EMPLOYEE_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => e.SHOP_CODE)
                    .HasName("missing_index_25008");

                entity.HasIndex(e => new { e.EMPLOYEE_CODE, e.EMPLOYEE_TYPE_CODE })
                    .HasName("missing_index_39947");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.EMPLOYEE_DESCR })
                    .HasName("missing_index_18085");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.EMPLOYEE_TYPE_CODE })
                    .HasName("IDX_CM_S_EMPLOYEE_SY_EMPLOYEE_TYPE");

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_CODE, e.EMPLOYEE_TYPE_CODE })
                    .HasName("missing_index_25194");

                entity.HasIndex(e => new { e.EMPLOYEE_CODE, e.DT_START, e.DT_END, e.EMPLOYEE_TYPE_CODE })
                    .HasName("missing_index_18113");

                entity.HasIndex(e => new { e.SHOP_CODE, e.FIRSTNAME, e.LASTNAME, e.EMPLOYEE_CODE })
                    .HasName("IDX_CM_S_EMPLOYEE_001");

                entity.HasIndex(e => new { e.EMPLOYEE_CODE, e.COMPANY_CODE, e.DIVISION_CODE, e.EMPLOYEE_TYPE_CODE, e.DT_START, e.DT_END })
                    .HasName("IDX_GET_EMPLOYEE_WH");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SHOP_CODE).HasMaxLength(3);

                entity.Property(e => e.EMPLOYEE_CODE).HasMaxLength(8);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_DESCR).HasMaxLength(255);

                entity.Property(e => e.EMPLOYEE_ID).HasMaxLength(10);

                entity.Property(e => e.EMPLOYEE_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.FIRSTNAME).HasMaxLength(50);

                entity.Property(e => e.LASTNAME).HasMaxLength(50);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.HasOne(d => d.SY_EMPLOYEE_TYPE)
                    .WithMany(p => p.CM_S_EMPLOYEE)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.EMPLOYEE_TYPE_CODE })
                    .HasConstraintName("FK_CM_S_EMPLOYEE_SY_EMPLOYEE_TYPE");
            });

            modelBuilder.Entity<CM_S_REFERENCE_SOURCE_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CODE, e.TYPE_CATEGORY_CODE });

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CODE).HasMaxLength(9);

                entity.Property(e => e.TYPE_CATEGORY_CODE).HasMaxLength(3);

                entity.Property(e => e.CUSTOMER_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DESCRIPTION).HasMaxLength(50);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.REF_CODE).HasMaxLength(9);

                entity.Property(e => e.REF_TYPE_CATEGORY_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(25);

                entity.Property(e => e.USERUPDATE).HasMaxLength(25);

                entity.HasOne(d => d.CU_S_TYPE)
                    .WithMany(p => p.CM_S_REFERENCE_SOURCE_EXT_AUS)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.CUSTOMER_TYPE_CODE })
                    .HasConstraintName("FK_CM_S_REFERENCE_SOURCE_EXT_AUS_CU_S_TYPE");

                entity.HasOne(d => d.CM_S_REFERENCE_SOURCE_EXT_AUSNavigation)
                    .WithMany(p => p.InverseCM_S_REFERENCE_SOURCE_EXT_AUSNavigation)
                    .HasForeignKey(d => new { d.COMPANY_CODE, d.DIVISION_CODE, d.REF_CODE, d.REF_TYPE_CATEGORY_CODE })
                    .HasConstraintName("FK_CM_S_REFERENCE_SOURCE_EXT_AUS_CM_S_REFERENCE_SOURCE_EXT_AUS_REF");
            });

            modelBuilder.Entity<CM_S_STATE_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.STATE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CM_S_STATE_EXT_AUS_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.STATE_CODE })
                    .HasName("IX_CM_S_STATE_EXT_AUS")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.STATE_CODE).HasMaxLength(3);

                entity.Property(e => e.DEFAULT_AREA_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATE_NAME).HasMaxLength(50);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_CATEGORY>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.CATEGORY_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_CATEGORY_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.CATEGORY_CODE).HasMaxLength(3);

                entity.Property(e => e.CATEGORY_DESCR).HasMaxLength(255);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.MARKET_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_CUSTOMER_TYPE_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_CUSTOMER_TYPE_EXT_AUS_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_SALUTATION>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SALUTATION_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_SALUTATION_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SALUTATION_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SALUTATION_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_STATUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.STATUS_CODE })
                    .HasName("PK_CUS_CONTACT_HOURS");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_STATUS_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.STATUS_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATUS_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<CU_S_TYPE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_CU_S_TYPE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<SY_EMPLOYEE_TYPE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.EMPLOYEE_TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_EMPLOYEE_TYPE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.EMPLOYEE_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.EMPLOYEE_TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<SY_GENDER>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.GENDER_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_GENDER_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.GENDER_CODE).HasMaxLength(1);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.GENDER_DESCR).HasMaxLength(255);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<SY_GENERAL_STATUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.STATUS_CODE, e.ENTITY_TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_GENERAL_STATUS_ROWGUID")
                    .IsUnique();

                entity.HasIndex(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.ENTITY_TYPE_CODE })
                    .HasName("IDX_SY_GENERAL_STATUS_SY_ENTITY_TYPE");

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.STATUS_CODE).HasMaxLength(3);

                entity.Property(e => e.ENTITY_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATUS_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<SY_GENERAL_TYPE_EXT_AUS>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.TYPE_CODE, e.TYPE_CATEGORY_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_GENERAL_TYPE_EXT_AUS_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.TYPE_CATEGORY_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<SY_LANGUAGE>(entity =>
            {
                entity.HasKey(e => e.LANGUAGE_CODE);

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_LANGUAGE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.LANGUAGE_CODE)
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.FLG_APPLICATION).HasMaxLength(1);

                entity.Property(e => e.LANGUAGE_DESCR).HasMaxLength(255);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<SY_SHOP_TYPE>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.SHOP_TYPE_CODE });

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_SY_SHOP_TYPE_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.SHOP_TYPE_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.SHOP_TYPE_DESCR).HasMaxLength(255);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);
            });

            modelBuilder.Entity<US_B_USER>(entity =>
            {
                entity.HasKey(e => new { e.COMPANY_CODE, e.DIVISION_CODE, e.USER_NAME })
                    .HasName("PK_SY_USER");

                entity.HasIndex(e => e.ROWGUID)
                    .HasName("UQ_US_B_USER_ROWGUID")
                    .IsUnique();

                entity.Property(e => e.COMPANY_CODE).HasMaxLength(3);

                entity.Property(e => e.DIVISION_CODE).HasMaxLength(3);

                entity.Property(e => e.USER_NAME).HasMaxLength(50);

                entity.Property(e => e.DEPARTMENT_CODE).HasMaxLength(3);

                entity.Property(e => e.DT_END).HasColumnType("date");

                entity.Property(e => e.DT_INSERT).HasColumnType("datetime");

                entity.Property(e => e.DT_START).HasColumnType("date");

                entity.Property(e => e.DT_UPDATE).HasColumnType("datetime");

                entity.Property(e => e.EMAIL).HasMaxLength(50);

                entity.Property(e => e.EMPLOYEE_CODE)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.GROUP_CODE).HasMaxLength(3);

                entity.Property(e => e.LANGUAGE_CODE).HasMaxLength(5);

                entity.Property(e => e.MOBILE).HasMaxLength(30);

                entity.Property(e => e.ORGANIZATION_CODE).HasMaxLength(3);

                entity.Property(e => e.PRACTITIONER_NUMBER).HasMaxLength(20);

                entity.Property(e => e.ROWGUID).HasDefaultValueSql("(newid())");

                entity.Property(e => e.STATUS_CODE).HasMaxLength(3);

                entity.Property(e => e.USERINSERT).HasMaxLength(50);

                entity.Property(e => e.USERUPDATE).HasMaxLength(50);

                entity.Property(e => e.USER_DESCR).HasMaxLength(255);

                entity.HasOne(d => d.LANGUAGE_CODENavigation)
                    .WithMany(p => p.US_B_USER)
                    .HasForeignKey(d => d.LANGUAGE_CODE)
                    .HasConstraintName("FK_US_B_USER_SY_LANGUAGE");
            });

            modelBuilder.HasSequence("NextFoxid").StartsAt(0);

            modelBuilder.HasSequence("GETNEXTBATCHNUMBER").StartsAt(200);

            modelBuilder.HasSequence("NextFoxCommonVoucherId");

            modelBuilder.HasSequence("NextFoxCouponid").StartsAt(0);

            modelBuilder.HasSequence("NextFoxid").StartsAt(4000);

            modelBuilder.HasSequence("NextFoxVoucherId");
        }
    }
}
