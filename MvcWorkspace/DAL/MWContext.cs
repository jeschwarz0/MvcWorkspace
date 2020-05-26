using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MvcWorkspace.Models;

namespace MvcWorkspace.DAL
{
    public partial class MWContext : DbContext
    {
        public MWContext()
        {
        }

        public MWContext(DbContextOptions<MWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<YoutubeChannel> YoutubeChannel { get; set; }
        public virtual DbSet<YoutubeVideo> YoutubeVideo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MvcWorkspace;Database=master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YoutubeChannel>(entity =>
            {
                entity.HasKey(e => e.ChannelId);

                entity.Property(e => e.ChannelId).HasColumnName("ChannelID");

                entity.Property(e => e.Category)
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Gaming')");

                entity.Property(e => e.ChannelIdentifier)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<YoutubeVideo>(entity =>
            {
                entity.HasKey(e => e.VideoId);

                entity.Property(e => e.VideoId).HasColumnName("VideoID");

                entity.Property(e => e.ChannelId).HasColumnName("ChannelID");

                entity.Property(e => e.Identifier)
                    .HasMaxLength(11)
                    .IsUnicode(false);
                entity.Property(e => e.Title)
                   .HasMaxLength(100)
                   .IsUnicode(false);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.YoutubeVideo)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__YoutubeVi__Chann__025D5595");
            });
        }
    }
}
