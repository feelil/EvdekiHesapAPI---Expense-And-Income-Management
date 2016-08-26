namespace CodeFirstFromDbLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eh.User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            MatchingAccountUser = new HashSet<MatchingAccountUser>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string PassWord { get; set; }

        public DateTime? AddedDate { get; set; }

        [StringLength(250)]
        public string GCMRegID { get; set; }

        [StringLength(50)]
        public string LanguageKey { get; set; }

        public int? UserGroupID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MatchingAccountUser> MatchingAccountUser { get; set; }
    }
}
