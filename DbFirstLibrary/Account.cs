namespace DbFirstLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eh.Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            MatchingAccountUsers = new HashSet<MatchingAccountUser>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserGroupID { get; set; }

        public decimal? Balance { get; set; }

        public decimal? CurrentBalance { get; set; }

        public int? DayOfCutOffDate { get; set; }

        public int? DayOfPaymentDueDate { get; set; }

        public bool? IsActive { get; set; }

        public int? AccountTypeID { get; set; }

        public virtual AccountType AccountType { get; set; }

        public virtual UserGroup UserGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchingAccountUser> MatchingAccountUsers { get; set; }
    }
}
