using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogicLayer
{
    public class RoleBLL//showing us how to do an alternate way of mapping by using construction
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }

        public RoleBLL(DataAccessLayer.RoleDAL role)
        {
            RoleID = role.RoleID;
            RoleName = role.RoleName;
        }
        public RoleBLL()
        {
            //default constructor (ctor) is required for mvc
        }
    }
}
