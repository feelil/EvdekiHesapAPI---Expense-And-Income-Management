namespace Entity
{
    using System;

    public  class User
    {

       
        public int ID { get; set; }       
        public string UserName { get; set; }       
        public string PassWord { get; set; }
        public DateTime? AddedDate { get; set; }       
        public string GCMRegID { get; set; }       
        public string LanguageKey { get; set; }
        public string Token { get; set; }

        public int? UserGroupID { get; set; }       
        public virtual UserGroup UserGroup { get; set; }
      
    }
}
