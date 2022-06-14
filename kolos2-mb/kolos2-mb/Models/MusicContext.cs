using Microsoft.EntityFrameworkCore;
using kolos2_mb.Models;

namespace kolos2_mb.Models
{
    public class MusicContext : DbContext
    {
        public DbSet<Album> Album { get; set; }
        public DbSet<Musician> Musician { get; set; }
        public DbSet<MusicLabel> MusicLabel { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<Musician_Track> Musician_Track { get; set; }
        public MusicContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician>(e =>
            {
                e.ToTable("Musician");
                e.HasKey(e => e.IdMusician);

                e.Property(e => e.FirstName).HasMaxLength(30).IsRequired();
                e.Property(e => e.LastName).HasMaxLength(50).IsRequired();
                e.Property(e => e.NickName).HasMaxLength(20);

                e.HasData(
                    new Musician
                    {
                        IdMusician = 1,
                        FirstName = "Tytus",
                        LastName = "Szyluk",
                        NickName = "Belmondo"
                    }
                );

                e.ToTable("Musician");
            });

            modelBuilder.Entity<MusicLabel>(e =>
            {
                e.ToTable("MusicLabel");
                e.HasKey(e => e.IdMusicLabel);

                e.Property(e => e.Name).HasMaxLength(50).IsRequired();

                e.HasData(
                    new MusicLabel
                    {
                        IdMusicLabel = 1,
                        Name = "Poppyn"
                    }
                );

                e.ToTable("MusicLabel");
            });

            modelBuilder.Entity<Album>(e =>
            {
                e.ToTable("Album");
                e.HasKey(e => e.IdAlbum);

                e.Property(e => e.AlbumName).IsRequired();
                e.Property(e => e.PublishDate).IsRequired();

                e.HasOne(e => e.MusicLabel).WithMany(e => e.Albums).HasForeignKey(e => e.IdMusicLabel).OnDelete(DeleteBehavior.ClientSetNull).IsRequired();

                //e.HasOne(e => e.Klient).WithMany(e => e.Zamowienia).HasForeignKey(e => e.IdKlient).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(
                    new Album
                    {
                        IdAlbum = 1,
                        AlbumName = "Mobbyn",
                        PublishDate = new System.DateTime(2022, 4, 12),
                        IdMusicLabel = 1
                    }
                );

                e.ToTable("Album");
            });

            modelBuilder.Entity<Track>(e =>
            {
                e.ToTable("Track");
                e.HasKey(e => e.IdTrack);

                e.Property(e => e.TrackName).HasMaxLength(20).IsRequired();
                e.Property(e => e.Duration).IsRequired();

                e.HasOne(e => e.Album).WithMany(e => e.Tracks).HasForeignKey(e => e.IdAlbum).OnDelete(DeleteBehavior.ClientSetNull);

                e.HasData(
                    new Track
                    {
                        IdTrack = 1,
                        TrackName = "gasnica",
                        Duration = 0.1111F,
                        IdAlbum = 1
                    }
                );

                e.ToTable("Track");
            });

            modelBuilder.Entity<Musician_Track>(e =>
            {
                e.ToTable("Musician_Track");
                e.HasKey(e => new { e.IdTrack, e.IdMusician });

                e.HasOne(e => e.Track).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdTrack).OnDelete(DeleteBehavior.ClientCascade).IsRequired();
                e.HasOne(e => e.Musician).WithMany(e => e.Musician_Tracks).HasForeignKey(e => e.IdMusician).OnDelete(DeleteBehavior.ClientCascade).IsRequired();

                e.HasData(
                    new Musician_Track
                    {
                        IdTrack = 1,
                        IdMusician = 1
                    }
                );

                e.ToTable("Musician_Track");
            });
        }
    }
}
