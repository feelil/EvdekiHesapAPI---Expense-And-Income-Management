namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transfer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? SourceAccountID { get; set; }

        public int? TargetAccountID { get; set; }

        public decimal? Amount { get; set; }

        public int? TransactionID { get; set; }
    }
}
