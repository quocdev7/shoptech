namespace shopdodadung.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BanHangDBContext : DbContext
    {
        public BanHangDBContext()
            : base("name=ChuoiKN")
        {
        }

         public virtual DbSet<Mcategogy> Categogys { get; set; }
        public virtual DbSet<Mcontact> Contacts { get; set; }
        public virtual DbSet<Mmenu> Menus { get; set; }
        public virtual DbSet<Morderdetail> Orderdetails { get; set; }
        public virtual DbSet<Morder> Orders { get; set; }
        public virtual DbSet<Mpost> Posts { get; set; }
        public virtual DbSet<Mproduct> Products { get; set; }
        public virtual DbSet<Mslider> Sliders { get; set; }
        public virtual DbSet<Mtopic> Topics { get; set; }
        public virtual DbSet<Muser> Users { get; set; }
        public virtual DbSet<Mlink> Links { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Mcategogy>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Mcontact>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Mcontact>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Mcontact>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<Mmenu>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Mmenu>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Mpost>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Mpost>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Mpost>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Mproduct>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Mproduct>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Mslider>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<Mslider>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<Mslider>()
                .Property(e => e.Img)
                .IsUnicode(false);

            modelBuilder.Entity<Mtopic>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Muser>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Muser>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Muser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Muser>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Muser>()
                .Property(e => e.Img)
                .IsUnicode(false);
        }
    }
}
