using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ALOPER.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static System.Formats.Asn1.AsnWriter;

namespace ALOPER.Repository.DBContext
{
    public class AloperDbContext : DbContext
    {
        public AloperDbContext()
        {

        }

        public AloperDbContext(DbContextOptions<AloperDbContext> options) : base(options)
        {

        }

        #region DB SET
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                                  .SetBasePath(Directory.GetCurrentDirectory())
                                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                IConfigurationRoot configuration = builder.Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDbStore"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contract
            modelBuilder.Entity<Contract>(contract =>
            {
                contract.Property(prop => prop.IdRoom).IsRequired(true);
                contract.Property(prop => prop.Id).IsUnicode(false).HasMaxLength(10).IsRequired(true);
                contract.Property(prop => prop.rentalTerm).IsRequired(true);
                contract.Property(prop => prop.DepositDate).HasColumnType("datetime2").IsRequired(true);
                contract.Property(prop => prop.DepositAmount).IsRequired(true);
                contract.Property(prop => prop.RentalPrice).IsRequired(true);
                contract.Property(prop => prop.RentalStartDate).HasColumnType("datetime2").IsRequired(true);
                contract.Property(prop => prop.NumberOfPeople).IsRequired(true);
                contract.Property(prop => prop.NumberOfVehicle).IsRequired(true);
                contract.Property(prop => prop.FullName).IsUnicode(true).HasMaxLength(20).IsRequired(true);
                contract.Property(prop => prop.PhoneNumber).IsUnicode(false).HasMaxLength(10).IsRequired(true);
                contract.Property(prop => prop.BirthOfDay).HasColumnType("datetime2").IsRequired(true);
                contract.Property(prop => prop.Identification).IsUnicode(false).HasMaxLength(20).IsRequired(true);
                contract.Property(prop => prop.DateRange).HasColumnType("datetime2").IsRequired(true);
                contract.Property(prop => prop.IssuedBy).IsUnicode(true).HasMaxLength(20).IsRequired(true);
                contract.Property(prop => prop.PermanentAddress).IsUnicode(true).HasMaxLength(50).IsRequired(true);
                contract.Property(prop => prop.Signature).IsUnicode(true).HasMaxLength(20).IsRequired(true);
                contract.Property(prop => prop.ContractEndDate).HasColumnType("datetime2").IsRequired(true);
                contract.Property(prop => prop.Note).IsUnicode(true).HasMaxLength(100).IsRequired(true);
            });
            #endregion

            #region Service
            modelBuilder.Entity<Service>(service =>
            {
                service.Property(prop => prop.IdService).IsRequired(true);
                service.Property(prop => prop.PriceService).IsRequired(true);
                service.Property(prop => prop.Dvt).IsUnicode(false).HasMaxLength(100).IsRequired(true);
                service.Property(prop => prop.OldNumber).IsRequired(true);
                service.Property(prop => prop.Name).IsUnicode(true).HasMaxLength(20).IsRequired(true);
            });

            modelBuilder.Entity<Service>()
                        .HasOne(service => service.Contract)
                        .WithMany(contract => contract.Services);
            #endregion

            #region Funiture
            modelBuilder.Entity<Furniture>(furniture =>
            {
                furniture.Property(prop => prop.IdFurniture).IsRequired(true);
                furniture.Property(prop => prop.Price).IsRequired(true);
                furniture.Property(prop => prop.Note).IsUnicode(true).HasMaxLength(100).IsRequired(true);
                furniture.Property(prop => prop.Name).IsUnicode(true).HasMaxLength(20).IsRequired(true);
                furniture.Property(prop => prop.Status).IsUnicode(true).HasMaxLength(15).IsRequired(true);
                furniture.Property(prop => prop.IsActive).IsRequired(true);
            });

            modelBuilder.Entity<Furniture>()
                        .HasOne(furniture => furniture.Contract)
                        .WithMany(contract => contract.Furnitures);
            #endregion
        }
    }
}
