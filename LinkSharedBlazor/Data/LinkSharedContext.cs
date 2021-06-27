using LinkSharedBlazor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkSharedBlazor.Data
{
    public class LinkSharedContext : DbContext
    {
        public LinkSharedContext(DbContextOptions<LinkSharedContext> options)
            : base(options)
        {
        }
        public DbSet<Social> Socials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Link> Links { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                                   .HasName("pk_user");
                entity.Property(p => p.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            });
            modelBuilder.Entity<Social>(entity =>
            {
                entity.HasKey(e => e.Id)
                                   .HasName("pk_social");
                entity.Property(p => p.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasKey(e => new { e.SocialId, e.UserId }).HasName("pk_link");
                entity.Property(p => p.CreatedAt)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.HasOne(e => e.SocialNavigation)
                  .WithMany(e => e.Links)
                  .HasForeignKey(e => e.SocialId);
                entity.HasOne(e => e.UserNavigation)
                  .WithMany(e => e.Links)
                  .HasForeignKey(e => e.UserId);
            });
        }
    }
}
