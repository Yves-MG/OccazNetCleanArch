using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OccazNet.Core;
using OccazNet.Core.Entities;
namespace OccazNet.Infrastructure.Data
{
    public class OccasNetDbContext : IdentityDbContext<User,Role,Guid>
    {
        public OccasNetDbContext(DbContextOptions<OccasNetDbContext> options) : base(options) { }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Ad>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Ads)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Ad>()
                .HasOne(a => a.Location)
                .WithMany(l => l.Ads)
                .HasForeignKey(a => a.LocationId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Ad>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
               .HasOne(t => t.Buyer)
               .WithMany()
               .HasForeignKey(t => t.BuyerId)
               .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Ad)
                .WithMany()
                .HasForeignKey(t => t.AdId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Ad)
                .WithMany()
                .HasForeignKey(f => f.AdId)
                .OnDelete(DeleteBehavior.Cascade);

           modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerId)
               .OnDelete(DeleteBehavior.Restrict);

           modelBuilder.Entity<Review>()
                .HasOne(ru => ru.ReviewedUser)
                .WithMany()
                .HasForeignKey(ru => ru.ReviewedUserId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
        
    }
}
