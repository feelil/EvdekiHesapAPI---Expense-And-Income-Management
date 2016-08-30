namespace Entity
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    public partial class EvdekiHesapContext : DbContext
    {
        public EvdekiHesapContext()
            : base("name=GelirGiderConnection")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        //public virtual DbSet<CreditCardInstallment> CreditCardInstallments { get; set; }
        //public virtual DbSet<CreditCardTransaction> CreditCardTransactions { get; set; }
        public virtual DbSet<ExpenseIncome> ExpenseIncomes { get; set; }
        public virtual DbSet<ExpenseIncomeType> ExpenseIncomeTypes { get; set; }
        //public virtual DbSet<StringMessage> StringMessages { get; set; }
        //public virtual DbSet<Transfer> Transfers { get; set; }
        //  public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExpenseIncomeMap());
            modelBuilder.Configurations.Add(new UserGroupMap());
            modelBuilder.Configurations.Add(new UserMap());

        }


    }


    public class ExpenseIncomeMap : EntityTypeConfiguration<ExpenseIncome>
    {
        public ExpenseIncomeMap()
        {

            ToTable("eh.ExpenseIncomes")
             .HasRequired(e => e.ExpenseIncomeType).WithMany().HasForeignKey(x => x.ExpIncTypeID); 


        }
    }
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {

            ToTable("eh.User")
            .HasRequired<UserGroup>(s => s.UserGroup)
             .WithMany(s => s.Users)
                .HasForeignKey(s => s.UserGroupID);

        }
    }
    public class UserGroupMap : EntityTypeConfiguration<UserGroup>
    {
        public UserGroupMap()
        {

            ToTable("eh.UserGroup")
            .HasMany<User>(s => s.Users);



        }
    }






}
