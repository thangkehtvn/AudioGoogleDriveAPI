namespace GoogleDrive.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MusicModel : DbContext
    {
        public MusicModel()
            : base("name=MusicModel")
        {
        }

        public virtual DbSet<BaiHat> BaiHats { get; set; }
        public virtual DbSet<SoHuu> SoHuus { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiHat>()
                .Property(e => e.IdDrive)
                .IsUnicode(false);

            modelBuilder.Entity<SoHuu>()
                .Property(e => e.TenUser)
                .IsUnicode(false);

            modelBuilder.Entity<SoHuu>()
                .Property(e => e.Idbaihat)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
