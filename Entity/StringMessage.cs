namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StringMessage
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string StringKey { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string StringValue { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(8)]
        public string LanguageKey { get; set; }
    }
}
