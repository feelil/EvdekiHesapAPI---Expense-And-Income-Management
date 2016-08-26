namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
      
        public int ID { get; set; }

      
        public string Name { get; set; }

        public int GroupID { get; set; }

        public decimal Balance { get; set; }

        public bool IsCreditCard { get; set; }

        public int UserID { get; set; }

        public decimal CurrentBalance { get; set; }

        public int DayOfCutOffDate { get; set; }

        public int DayOfPaymentDueDate { get; set; }

        public bool IsActive { get; set; }
    }
}
