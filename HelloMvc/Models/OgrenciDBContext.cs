using Microsoft.EntityFrameworkCore;

namespace HelloMvc.Models
{
    public class OgrenciDBContext : DbContext
    {
     
        public OgrenciDBContext(DbContextOptions<OgrenciDBContext> options)
            : base(options)
        {
        }

        public DbSet<Ogrenci> Ogrenci { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ogrenci>().ToTable("tblOgrenciler");

            modelBuilder.Entity<Ogrenci>()
                .Property(o => o.Ad)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Ogrenci>()
                .Property(o => o.Soyad)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}
