using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NatzHarmonyCapstone.Models;
using NatzHarmonyCapstone.Models.ViewModels;

namespace NatzHarmonyCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Language> Language { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public DbSet<UserLanguage> UserLanguage { get; set; }
        public DbSet<UserMentor> UserMentor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserMentor>()
                  .HasOne(m => m.Mentor)
                  .WithMany(t => t.UserMentees)
                  .HasForeignKey(m => m.MentorId)
                  .HasPrincipalKey(u => u.Id)
                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserMentor>()
                 .HasOne(m => m.User)
                 .WithMany(t => t.UserMentors)
                 .HasForeignKey(m => m.UserId)
                 .HasPrincipalKey(u => u.Id)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Messages>()
                  .HasOne(m => m.Sender)
                  .WithMany(t => t.SentMessages)
                  .HasForeignKey(m => m.SenderId)
                  .HasPrincipalKey(u => u.Id)
                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Messages>()
                    .HasOne(m => m.Recipient)
                    .WithMany(t => t.ReceiviedMessages)
                    .HasForeignKey(m => m.RecipientId)
                    .HasPrincipalKey(u => u.Id)
                    .OnDelete(DeleteBehavior.Restrict);


            //this line makes the Countries
            modelBuilder.Entity<Country>().HasData(
                new Country()
                {
                    CountryId = 1,
                    Name = "United States"
                },
                new Country()
                {
                    CountryId = 2,
                    Name = "Mexico"
                }
                );

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admina",
                LastName = "Straytor",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumber = "6155555555",
                CountryId = 1,
                EmailConfirmed = false,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            ApplicationUser userAdmin = new ApplicationUser
            {
                FirstName = "TIRRC",
                LastName = "Admin",
                UserName = "tirrc@admin.com",
                NormalizedUserName = "TIRRC@ADMIN.COM",
                Email = "tirrc@admin.com",
                NormalizedEmail = "TIRRC@ADMIN.COM",
                PhoneNumber = "6155555556",
                CountryId = 1,
                EmailConfirmed = false,
                LockoutEnabled = false,
                Admin = true,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794578",
                Id = "00000000-ffff-ffff-ffff-ffffffffffaa"
            };
            var passwordHash2 = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash2.HashPassword(userAdmin, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(userAdmin);

            //this line makes the Countries
            modelBuilder.Entity<Language>().HasData(
                new Language()
                {
                    LanguageId = 1,
                    Name = "Spanish"
                },
                new Language()
                {
                    LanguageId = 2,
                    Name = "Chinese"
                },
                new Language()
                {
                    LanguageId = 3,
                    Name = "Tagalog"
                },
                new Language()
                {
                    LanguageId = 4,
                    Name = "Vietnamese"
                },
                new Language()
                {
                    LanguageId = 5,
                    Name = "Arabic"
                },
                new Language()
                {
                    LanguageId = 6,
                    Name = "French"
                },
                new Language()
                {
                    LanguageId = 7,
                    Name = "Korean"
                },
                new Language()
                {
                    LanguageId = 8,
                    Name = "Russian"
                },
                new Language()
                {
                    LanguageId = 9,
                    Name = "German"
                },
                new Language()
                {
                    LanguageId = 10,
                    Name = "Haitian Creole"
                },
                new Language()
                {
                    LanguageId = 11,
                    Name = "Portuguese"
                },
                new Language()
                {
                    LanguageId = 12,
                    Name = "Italian"
                },
                new Language()
                {
                    LanguageId = 13,
                    Name = "Polish"
                },
                new Language()
                {
                    LanguageId = 14,
                    Name = "Hindi"
                }
                );


        }

    }
}
