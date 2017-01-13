using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Discountify.Data;

namespace Discountify.Data.Migrations
{
    [DbContext(typeof(DiscountifyContext))]
    [Migration("20170113152913_AddNewEntitiesToTheSchema")]
    partial class AddNewEntitiesToTheSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Discountify.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<Guid?>("DistrictId");

                    b.Property<int>("Floor");

                    b.Property<Guid?>("GeolocationId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedAt");

                    b.Property<string>("LastModifiedBy");

                    b.Property<int>("PostalCode");

                    b.Property<string>("Street");

                    b.Property<string>("StreetNumber");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("GeolocationId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Discountify.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedAt");

                    b.Property<string>("LastModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Discountify.Models.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedAt");

                    b.Property<string>("LastModifiedBy");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ProvinceId");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Discountify.Models.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedAt");

                    b.Property<string>("LastModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Discountify.Models.Discount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CardId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedAt");

                    b.Property<string>("LastModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("Type");

                    b.Property<decimal>("Value");

                    b.Property<Guid?>("VenueId");

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.HasIndex("VenueId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("Discountify.Models.District", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CityId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedAt");

                    b.Property<string>("LastModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("District");
                });

            modelBuilder.Entity("Discountify.Models.Geolocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedAt");

                    b.Property<string>("LastModifiedBy");

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.HasKey("Id");

                    b.ToTable("Geolocation");
                });

            modelBuilder.Entity("Discountify.Models.IndustryClassification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedAt");

                    b.Property<string>("LastModifiedBy");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParrentId");

                    b.HasKey("Id");

                    b.HasIndex("ParrentId");

                    b.ToTable("IndustryClassification");
                });

            modelBuilder.Entity("Discountify.Models.Province", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CountryId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedAt");

                    b.Property<string>("LastModifiedBy");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("Discountify.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<Guid?>("AddressId");

                    b.Property<int>("Age");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsMale");

                    b.Property<DateTime>("LastModifiedAt");

                    b.Property<string>("LastModifiedBy");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecondName");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Discountify.Models.Venue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<Guid?>("IndustryClassificationId");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime>("LastModifiedAt");

                    b.Property<string>("LastModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<int>("Rating");

                    b.Property<string>("WebsiteUrl");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("IndustryClassificationId");

                    b.ToTable("Venue");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Discountify.Models.Address", b =>
                {
                    b.HasOne("Discountify.Models.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictId");

                    b.HasOne("Discountify.Models.Geolocation", "Geolocation")
                        .WithMany()
                        .HasForeignKey("GeolocationId");
                });

            modelBuilder.Entity("Discountify.Models.Card", b =>
                {
                    b.HasOne("Discountify.Models.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Discountify.Models.City", b =>
                {
                    b.HasOne("Discountify.Models.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");
                });

            modelBuilder.Entity("Discountify.Models.Discount", b =>
                {
                    b.HasOne("Discountify.Models.Card", "Card")
                        .WithMany("Discounts")
                        .HasForeignKey("CardId");

                    b.HasOne("Discountify.Models.Venue", "Venue")
                        .WithMany("Discounts")
                        .HasForeignKey("VenueId");
                });

            modelBuilder.Entity("Discountify.Models.District", b =>
                {
                    b.HasOne("Discountify.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");
                });

            modelBuilder.Entity("Discountify.Models.IndustryClassification", b =>
                {
                    b.HasOne("Discountify.Models.IndustryClassification", "Parrent")
                        .WithMany()
                        .HasForeignKey("ParrentId");
                });

            modelBuilder.Entity("Discountify.Models.Province", b =>
                {
                    b.HasOne("Discountify.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("Discountify.Models.User", b =>
                {
                    b.HasOne("Discountify.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Discountify.Models.Venue", b =>
                {
                    b.HasOne("Discountify.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Discountify.Models.IndustryClassification", "IndustryClassification")
                        .WithMany()
                        .HasForeignKey("IndustryClassificationId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Discountify.Models.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Discountify.Models.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Discountify.Models.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
