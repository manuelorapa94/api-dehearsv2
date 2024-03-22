using ehearsApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ehearsApi.Data
{
    public class dhearsApiContext : DbContext
    {
        public dhearsApiContext(DbContextOptions<dhearsApiContext> options) : base(options) 
        { 
        }

        // Reason Type Model
        public DbSet<ReasonType> ReasonTypes { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReasonType>()
                .Property(rt => rt.reasonTypeId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .ValueGeneratedOnAdd();
        }

        // QR Information Model
        public DbSet<QRInformation> QRInformations { get; set; }
        public async Task<List<QRInformation>> CallSPQRInformation(string qrCode)
        {
            var parameters = new object[] { new SqlParameter("@qrCode", qrCode) };

            return await QRInformations
                .FromSqlRaw("EXEC sp_QRInformation @qrCode", parameters)
                .ToListAsync();
        }
    }
}
