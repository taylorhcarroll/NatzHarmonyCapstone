﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NatzHarmonyCapstone.Data;

namespace NatzHarmonyCapstone.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NatzHarmonyCapstone.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            Name = "United States"
                        },
                        new
                        {
                            CountryId = 2,
                            Name = "Mexico"
                        },
                        new
                        {
                            CountryId = 3,
                            Name = "Afghanistan"
                        },
                        new
                        {
                            CountryId = 4,
                            Name = "Albania"
                        },
                        new
                        {
                            CountryId = 5,
                            Name = "Algeria"
                        },
                        new
                        {
                            CountryId = 6,
                            Name = "Andorra"
                        },
                        new
                        {
                            CountryId = 7,
                            Name = "Angola"
                        },
                        new
                        {
                            CountryId = 8,
                            Name = "Argentina"
                        },
                        new
                        {
                            CountryId = 9,
                            Name = "Armenia"
                        },
                        new
                        {
                            CountryId = 10,
                            Name = "Armenia"
                        },
                        new
                        {
                            CountryId = 11,
                            Name = "Austrailia"
                        },
                        new
                        {
                            CountryId = 12,
                            Name = "Austria"
                        },
                        new
                        {
                            CountryId = 13,
                            Name = "Azerbaijan"
                        },
                        new
                        {
                            CountryId = 14,
                            Name = "Bahamas"
                        },
                        new
                        {
                            CountryId = 15,
                            Name = "Bahrain"
                        },
                        new
                        {
                            CountryId = 16,
                            Name = "Bangladesh"
                        });
                });

            modelBuilder.Entity("NatzHarmonyCapstone.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            Name = "Spanish"
                        },
                        new
                        {
                            LanguageId = 2,
                            Name = "Chinese"
                        },
                        new
                        {
                            LanguageId = 3,
                            Name = "Tagalog"
                        },
                        new
                        {
                            LanguageId = 4,
                            Name = "Vietnamese"
                        },
                        new
                        {
                            LanguageId = 5,
                            Name = "Arabic"
                        },
                        new
                        {
                            LanguageId = 6,
                            Name = "French"
                        },
                        new
                        {
                            LanguageId = 7,
                            Name = "Korean"
                        },
                        new
                        {
                            LanguageId = 8,
                            Name = "Russian"
                        },
                        new
                        {
                            LanguageId = 9,
                            Name = "German"
                        },
                        new
                        {
                            LanguageId = 10,
                            Name = "Haitian Creole"
                        },
                        new
                        {
                            LanguageId = 11,
                            Name = "Portuguese"
                        },
                        new
                        {
                            LanguageId = 12,
                            Name = "Italian"
                        },
                        new
                        {
                            LanguageId = 13,
                            Name = "Polish"
                        },
                        new
                        {
                            LanguageId = 14,
                            Name = "Hindi"
                        });
                });

            modelBuilder.Entity("NatzHarmonyCapstone.Models.Messages", b =>
                {
                    b.Property<int>("MessagesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("RecipientId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("MessagesId");

                    b.HasIndex("RecipientId");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessagesId = 1,
                            IsRead = false,
                            RecipientId = "e65db829-8ed8-433a-9e40-32bce7803339",
                            SenderId = "00000000-ffff-ffff-ffff-ffffffffffff",
                            TimeStamp = new DateTime(2020, 5, 19, 11, 25, 5, 29, DateTimeKind.Local).AddTicks(5858)
                        });
                });

            modelBuilder.Entity("NatzHarmonyCapstone.Models.UserLanguage", b =>
                {
                    b.Property<int>("UserLanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserLanguageId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("LanguageId");

                    b.ToTable("UserLanguage");

                    b.HasData(
                        new
                        {
                            UserLanguageId = 25,
                            LanguageId = 11,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffaf"
                        },
                        new
                        {
                            UserLanguageId = 26,
                            LanguageId = 1,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffaf"
                        },
                        new
                        {
                            UserLanguageId = 27,
                            LanguageId = 4,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffae"
                        },
                        new
                        {
                            UserLanguageId = 28,
                            LanguageId = 1,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffad"
                        },
                        new
                        {
                            UserLanguageId = 29,
                            LanguageId = 6,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffac"
                        },
                        new
                        {
                            UserLanguageId = 30,
                            LanguageId = 7,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffab"
                        },
                        new
                        {
                            UserLanguageId = 31,
                            LanguageId = 8,
                            UserId = "00000000-ffff-ffff-ffff-ffffffffffaa"
                        });
                });

            modelBuilder.Entity("NatzHarmonyCapstone.Models.UserMentor", b =>
                {
                    b.Property<int>("UserMentorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MentorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserMentorId");

                    b.HasIndex("MentorId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMentor");
                });

            modelBuilder.Entity("NatzHarmonyCapstone.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Availability")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<bool>("CountryPref")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GenderPref")
                        .HasColumnType("bit");

                    b.Property<bool>("LanguagePref")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Mentor")
                        .HasColumnType("bit");

                    b.Property<string>("Pronouns")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("CountryId");

                    b.HasDiscriminator().HasValue("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bfbb729b-5b15-4c53-b607-d5bad28dee8b",
                            Email = "admin@admin.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEEJ+6/w8NHULqsc/Gg1a8/37jgfOtm+3qPH4hBxIUAMtGGGHpS1tiFAQlcfa88jG3A==",
                            PhoneNumber = "6155555555",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com",
                            Admin = false,
                            CountryId = 1,
                            CountryPref = false,
                            DoB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Admina",
                            GenderPref = false,
                            LanguagePref = false,
                            LastName = "Straytor",
                            Mentor = false
                        },
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffaa",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "066741e0-e163-407e-952e-e6fa36db25ea",
                            Email = "tirrc@admin.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TIRRC@ADMIN.COM",
                            NormalizedUserName = "TIRRC@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEI2ZIBVHI9+OCBsYVUARf9ue/NeNnLHxYU2DlZgRDA8Z4ZXJzJ/PctdhCv8SdUwB4g==",
                            PhoneNumber = "6155555556",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794578",
                            TwoFactorEnabled = false,
                            UserName = "tirrc@admin.com",
                            Admin = true,
                            CountryId = 1,
                            CountryPref = false,
                            DoB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "TIRRC",
                            GenderPref = false,
                            LanguagePref = false,
                            LastName = "Admin",
                            Mentor = false
                        },
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffab",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7cba8164-a3c9-4994-a5c1-c5513e13e7b8",
                            Email = "adam@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADAM@EXAMPLE.COM",
                            NormalizedUserName = "ADAM@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEK+/E738IQFSYdXcDWtG2Vz+Spatr06vjC2EoLrHZPy5qTZ8OtXALmzJvlPeMIA5Fg==",
                            PhoneNumber = "6155555556",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794579",
                            TwoFactorEnabled = false,
                            UserName = "adam@example.com",
                            Admin = false,
                            Availability = "Mornings",
                            CountryId = 1,
                            CountryPref = false,
                            DoB = new DateTime(1992, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Adam",
                            Gender = "Male",
                            GenderPref = false,
                            LanguagePref = false,
                            LastName = "Kodansha",
                            Mentor = true,
                            Pronouns = "He / Him"
                        },
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffac",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c709ff51-d602-45b1-9c0e-6421a4e223b2",
                            Email = "namita@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "NAMITA@EXAMPLE.COM",
                            NormalizedUserName = "NAMITA@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEE6iY6APROM5pj1X+a+GTMR17rYdoP/y7SVRyiTf8krzs3m8SqUi+z2Jk8cXEujFPg==",
                            PhoneNumber = "6155555557",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794580",
                            TwoFactorEnabled = false,
                            UserName = "namita@example.com",
                            Admin = false,
                            Availability = "Midday",
                            CountryId = 2,
                            CountryPref = false,
                            DoB = new DateTime(1986, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Namita",
                            Gender = "Female",
                            GenderPref = false,
                            LanguagePref = false,
                            LastName = "Patel",
                            Mentor = true,
                            Pronouns = "She / Her"
                        },
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffad",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fd5356d0-a479-45ae-b388-402129807191",
                            Email = "miguel@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MIGUEL@EXAMPLE.COM",
                            NormalizedUserName = "MIGUEL@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEPbL08eULGF7m2sHiBWcfSCr0Nt3VGr0lJRsAqIHAzyeIiOmKQwsJGVMaaoaFj5KbQ==",
                            PhoneNumber = "6155555557",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794581",
                            TwoFactorEnabled = false,
                            UserName = "miguel@example.com",
                            Admin = false,
                            Availability = "Evenings",
                            CountryId = 2,
                            CountryPref = false,
                            DoB = new DateTime(1988, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Miguel",
                            Gender = "Male",
                            GenderPref = false,
                            LanguagePref = false,
                            LastName = "Garcia",
                            Mentor = true,
                            Pronouns = "He / Him"
                        },
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffae",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "69c6725b-4eb1-4b74-b02d-3179e49b0ecb",
                            Email = "an@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "AN@EXAMPLE.COM",
                            NormalizedUserName = "AN@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDIAqmkXWCVd0/BwrEpDGYKn0Zv4pt3tGPMFcHVK/9p6mtb0XDuxH1naWy4Z9A07Tw==",
                            PhoneNumber = "6155555557",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794582",
                            TwoFactorEnabled = false,
                            UserName = "an@example.com",
                            Admin = false,
                            Availability = "Mornings",
                            CountryId = 1,
                            CountryPref = false,
                            DoB = new DateTime(1992, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "An",
                            Gender = "Male",
                            GenderPref = false,
                            LanguagePref = false,
                            LastName = "Nguyen",
                            Mentor = true,
                            Pronouns = "He / Him"
                        },
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffaf",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c1a2efd2-6bff-40e8-9484-abcdc13f4ea7",
                            Email = "alexander@example.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ALEXANDER@EXAMPLE.COM",
                            NormalizedUserName = "ALEXANDER@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOtbGpbW87XZF7Y3dYC5+VEQvbBvthAhDGEJMGoVrU1FnBWDvNLAXyX3xG6oE+ejjQ==",
                            PhoneNumber = "6155555557",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794583",
                            TwoFactorEnabled = false,
                            UserName = "alexander@example.com",
                            Admin = false,
                            Availability = "Evenings",
                            CountryId = 2,
                            CountryPref = false,
                            DoB = new DateTime(1988, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Alexander",
                            Gender = "Male",
                            GenderPref = false,
                            LanguagePref = false,
                            LastName = "Silva",
                            Mentor = true,
                            Pronouns = "He / Him"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NatzHarmonyCapstone.Models.Messages", b =>
                {
                    b.HasOne("NatzHarmonyCapstone.Models.ApplicationUser", "Recipient")
                        .WithMany("ReceiviedMessages")
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NatzHarmonyCapstone.Models.ApplicationUser", "Sender")
                        .WithMany("SentMessages")
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NatzHarmonyCapstone.Models.UserLanguage", b =>
                {
                    b.HasOne("NatzHarmonyCapstone.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Languages")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("NatzHarmonyCapstone.Models.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NatzHarmonyCapstone.Models.UserMentor", b =>
                {
                    b.HasOne("NatzHarmonyCapstone.Models.ApplicationUser", "Mentor")
                        .WithMany("UserMentees")
                        .HasForeignKey("MentorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("NatzHarmonyCapstone.Models.ApplicationUser", "User")
                        .WithMany("UserMentors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("NatzHarmonyCapstone.Models.ApplicationUser", b =>
                {
                    b.HasOne("NatzHarmonyCapstone.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
