namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExpenseIncome
    {
        public int ID { get; set; }
        public int? ExpIncTypeID { get; set; }
        public int AccountID { get; set; }
        public decimal? Amount { get; set; }
        public int? UserID { get; set; }
        public int? GroupID { get; set; }
        public DateTime? AddedDate { get; set; }
        public string Explanation { get; set; }
        public int? ParentItemID { get; set; }
        public decimal? Balance { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ActivationDate { get; set; }
        public virtual ExpenseIncomeType ExpenseIncomeType { get; set; }
    }
}
