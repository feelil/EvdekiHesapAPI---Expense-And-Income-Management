namespace Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ExpenseIncomeType
    {
        public int ID { get; set; }
        public string TName { get; set; }
        public int? IsExpOrInc { get; set; }
        public int? ParentExpTypeID { get; set; }
        public decimal? ExpIncTypeDefaultAmount { get; set; }
        public string UserGroupUniqueValue { get; set; }
        public int? UserGroupID { get; set; }
     //   public virtual ExpenseIncome ExpenseIncome { get; set; }
    }
}
