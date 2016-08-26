namespace Entity
{
    using System.Collections.Generic;

    public  class UserGroup
    {

       
        public int ID { get; set; }      
        public string GroupCode { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public UserGroup()
        {
            Users = new List<User>();
        }

    }
}
