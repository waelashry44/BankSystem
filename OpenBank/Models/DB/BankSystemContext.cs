using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OpenBank.Models.DB
{
    public partial class BankSystemContext : DbContext
    {
        public BankSystemContext()
        {
        }

        public BankSystemContext(DbContextOptions<BankSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BankAccount> BankAccounts { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<TransactionHistory> TransactionHistories { get; set; } = null!;
        public virtual DbSet<TransactionType> TransactionTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=BankSystem;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.ToTable("BankAccount");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.BankAccounts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__BankAccou__Custo__267ABA7A");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TransactionHistory>(entity =>
            {
                entity.ToTable("TransactionHistory");

                entity.Property(e => e.TransactionDate).HasColumnType("datetime");

                entity.HasOne(d => d.BankAccount)
                    .WithMany(p => p.TransactionHistoryBankAccounts)
                    .HasForeignKey(d => d.BankAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__BankA__2C3393D0");

                entity.HasOne(d => d.SenderBankAccount)
                    .WithMany(p => p.TransactionHistorySenderBankAccounts)
                    .HasForeignKey(d => d.SenderBankAccountId)
                    .HasConstraintName("FK__Transacti__Sende__2D27B809");

                entity.HasOne(d => d.TransactionType)
                    .WithMany(p => p.TransactionHistories)
                    .HasForeignKey(d => d.TransactionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Transacti__Trans__2B3F6F97");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.ToTable("TransactionType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
