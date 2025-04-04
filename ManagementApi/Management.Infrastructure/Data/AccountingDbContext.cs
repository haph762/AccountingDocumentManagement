using Management.Domain;
using Microsoft.EntityFrameworkCore;

namespace Management.Infrastructure.Data
{
    public class AccountingDbContext : DbContext
    {
        public DbSet<AccountingDocument> AccountingDocuments { get; set; }
        public DbSet<AccountingDocumentDetail> AccountingDocumentDetails { get; set; }

        public AccountingDbContext(DbContextOptions<AccountingDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountingDocument>()
                .HasIndex(d => d.DocumentNumber)
                .IsUnique();

            modelBuilder.Entity<AccountingDocumentDetail>()
                .HasOne(d => d.Document)
                .WithMany(d => d.Details)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
