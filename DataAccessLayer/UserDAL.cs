using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class UserDAL
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public override string ToString()//converts this thing to a string
        {
            return $"{RoleID,2}{UserID,6}{Email}{Hash}{Salt} {RoleName}";
        }
    }
}
