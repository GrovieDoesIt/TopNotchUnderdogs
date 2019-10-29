using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
   public class UserBLL
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public UserBLL(DataAccessLayer.UserDAL user)//allows us to get the record from the dal
        {
            UserID = user.UserID;
            Email = user.Email;
            Hash = user.Hash;
            Salt = user.Salt;
            RoleID = user.RoleID;
            RoleName = user.RoleName;
        }
        public UserBLL()//used by mvc to create a record for the user bll
        {

        }

    }
}
