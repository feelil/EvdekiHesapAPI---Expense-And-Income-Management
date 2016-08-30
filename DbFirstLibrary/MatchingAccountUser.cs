namespace DbFirstLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("eh.MatchingAccountUser")]
    public partial class MatchingAccountUser
    {
        public int ID { get; set; }

        public int AccountID { get; set; }

        public int UserID { get; set; }

        public virtual Account Account { get; set; }

        public virtual User User { get; set; }
    }
}
