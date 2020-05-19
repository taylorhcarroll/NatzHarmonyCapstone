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
                },
                new Country()
                {
                    CountryId = 3,
                    Name = "Afghanistan"
                },
                 new Country()
                 {
                     CountryId = 4,
                     Name = "Albania"
                 },
                  new Country()
                  {
                      CountryId = 5,
                      Name = "Algeria"
                  },
                   new Country()
                   {
                       CountryId = 6,
                       Name = "Andorra"
                   },
                   new Country()
                   {
                       CountryId = 7,
                       Name = "Angola"
                   },
                   new Country()
                   {
                       CountryId = 8,
                       Name = "Argentina"
                   },
                    new Country()
                    {
                        CountryId = 9,
                        Name = "Armenia"
                    },
                    new Country()
                    {
                        CountryId = 10,
                        Name = "Armenia"
                    },
                    new Country()
                    {
                        CountryId = 11,
                        Name = "Austrailia"
                    },
                    new Country()
                    {
                        CountryId = 12,
                        Name = "Austria"
                    },
                    new Country()
                    {
                        CountryId = 13,
                        Name = "Azerbaijan"
                    },
                    new Country()
                    {
                        CountryId = 14,
                        Name = "Bahamas"
                    },
                    new Country()
                    {
                        CountryId = 15,
                        Name = "Bahrain"
                    },
                    new Country()
                    {
                        CountryId = 16,
                        Name = "Bangladesh"
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
            var passwordHashAdmin = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHashAdmin.HashPassword(userAdmin, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(userAdmin);

            ApplicationUser userExample = new ApplicationUser
            {
                FirstName = "Adam",
                LastName = "Kodansha",
                UserName = "adam@example.com",
                NormalizedUserName = "ADAM@EXAMPLE.COM",
                Email = "adam@example.com",
                NormalizedEmail = "ADAM@EXAMPLE.COM",
                PhoneNumber = "6155555556",
                CountryId = 1,
                Mentor = true,
                Gender = "Male",
                Availability = "Mornings",
                Pronouns = "He / Him",
                DoB = new DateTime(1992,04,02),
                EmailConfirmed = false,
                LockoutEnabled = false,
                Admin = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794579",
                Id = "00000000-ffff-ffff-ffff-ffffffffffab"
            };
            var passwordHash2 = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash2.HashPassword(userExample, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(userExample);

            ApplicationUser userExample2 = new ApplicationUser
            {
                FirstName = "Namita",
                LastName = "Patel",
                UserName = "namita@example.com",
                NormalizedUserName = "NAMITA@EXAMPLE.COM",
                Email = "namita@example.com",
                NormalizedEmail = "NAMITA@EXAMPLE.COM",
                PhoneNumber = "6155555557",
                CountryId = 2,
                Mentor = true,
                Availability = "Midday",
                Gender = "Female",
                Pronouns = "She / Her",
                DoB = new DateTime(1986, 05, 27),
                EmailConfirmed = false,
                LockoutEnabled = false,
                Admin = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794580",
                Id = "00000000-ffff-ffff-ffff-ffffffffffac"
            };
            var passwordHash3 = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash3.HashPassword(userExample2, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(userExample2);

            ApplicationUser userExample3 = new ApplicationUser
            {
                FirstName = "Miguel",
                LastName = "Garcia",
                UserName = "miguel@example.com",
                NormalizedUserName = "MIGUEL@EXAMPLE.COM",
                Email = "miguel@example.com",
                NormalizedEmail = "MIGUEL@EXAMPLE.COM",
                PhoneNumber = "6155555557",
                CountryId = 2,
                Availability = "Evenings",
                Mentor = true,
                Gender = "Male",
                Pronouns = "He / Him",
                DoB = new DateTime(1988, 02, 17),
                EmailConfirmed = false,
                LockoutEnabled = false,
                Admin = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794581",
                Id = "00000000-ffff-ffff-ffff-ffffffffffad"
            };
            var passwordHash4 = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash4.HashPassword(userExample3, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(userExample3);

            ApplicationUser userExample4 = new ApplicationUser
            {
                FirstName = "An",
                LastName = "Nguyen",
                UserName = "an@example.com",
                NormalizedUserName = "AN@EXAMPLE.COM",
                Email = "an@example.com",
                NormalizedEmail = "AN@EXAMPLE.COM",
                PhoneNumber = "6155555557",
                CountryId = 1,
                Mentor = true,
                Availability = "Mornings",
                Gender = "Male",
                Pronouns = "He / Him",
                DoB = new DateTime(1992, 02, 15),
                EmailConfirmed = false,
                LockoutEnabled = false,
                Admin = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794582",
                Id = "00000000-ffff-ffff-ffff-ffffffffffae"
            };
            var passwordHash5 = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash5.HashPassword(userExample4, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(userExample4);

            ApplicationUser userExample5 = new ApplicationUser
            {
                FirstName = "Alexander",
                LastName = "Silva",
                UserName = "alexander@example.com",
                NormalizedUserName = "ALEXANDER@EXAMPLE.COM",
                Email = "alexander@example.com",
                NormalizedEmail = "ALEXANDER@EXAMPLE.COM",
                PhoneNumber = "6155555557",
                CountryId = 2,
                Availability = "Evenings",
                Mentor = true,
                Gender = "Male",
                Pronouns = "He / Him",
                DoB = new DateTime(1988, 10, 30),
                EmailConfirmed = false,
                LockoutEnabled = false,
                Admin = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794583",
                Id = "00000000-ffff-ffff-ffff-ffffffffffaf"
            };
            var passwordHash6 = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash6.HashPassword(userExample5, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(userExample5);

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

            //this line makes the Countries
            modelBuilder.Entity<UserLanguage>().HasData(
                new UserLanguage()
                {
                    UserLanguageId = 25,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffaf",
                    LanguageId = 11,
                },
                new UserLanguage()
                {
                    UserLanguageId = 26,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffaf",
                    LanguageId = 1,
                },
                new UserLanguage()
                {
                    UserLanguageId = 27,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffae",
                    LanguageId = 4,
                },
                new UserLanguage()
                {
                    UserLanguageId = 28,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffad",
                    LanguageId = 1,
                },
                new UserLanguage()
                {
                    UserLanguageId = 29,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffac",
                    LanguageId = 6,
                },
                new UserLanguage()
                {
                    UserLanguageId = 30,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffab",
                    LanguageId = 7,
                },
                new UserLanguage()
                {
                    UserLanguageId = 31,
                    UserId = "00000000-ffff-ffff-ffff-ffffffffffaa",
                    LanguageId = 8,
                }
                );

            //this line makes the Sample Message
            modelBuilder.Entity<Messages>().HasData(
                new Messages()
                {
                    MessagesId = 1,
                    SenderId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    RecipientId = "e65db829-8ed8-433a-9e40-32bce7803339",
                    TimeStamp = DateTime.Now,
                    IsRead = false,
                });


        }

    }
}
