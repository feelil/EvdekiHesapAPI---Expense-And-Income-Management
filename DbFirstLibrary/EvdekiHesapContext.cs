namespace DbFirstLibrary
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EvdekiHesapContext : DbContext
    {
        public EvdekiHesapContext()
            : base("name=EvdekiHesapConnection")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<MatchingAccountUser> MatchingAccountUsers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Balance)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Account>()
                .Property(e => e.CurrentBalance)
                .HasPrecision(12, 2);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.MatchingAccountUsers)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.MatchingAccountUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserGroup>()
                .HasMany(e => e.Accounts)
                .WithRequired(e => e.UserGroup)
                .WillCascadeOnDelete(false);
        }
    }
}
