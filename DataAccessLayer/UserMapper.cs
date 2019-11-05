using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class UserMapper : Mapper
    {
        int OffsetToUserID;
        int OffsetToRoleID;
        int OffsetToEmail;
        int OffsetToHash;
        int OffsetToSalt;
        int OffsetToRoleName;

        public UserMapper(SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == OffsetToUserID, $"UserID is {OffsetToUserID} instead of 0 as expected");
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(4 == OffsetToRoleID, $"RoleID is {OffsetToRoleID} instead of 4 as expected");
            OffsetToEmail = reader.GetOrdinal("Email");
            Assert(1 == OffsetToEmail, $"Email is {OffsetToEmail} instead of 1 as expected");
            OffsetToHash = reader.GetOrdinal("Hash");
            Assert(2 == OffsetToHash, $"Hash is {OffsetToHash} instead of 2 as expected");
            OffsetToSalt = reader.GetOrdinal("Salt");
            Assert(3 == OffsetToSalt, $"Salt is {OffsetToSalt} instead of 3 as expected");
            OffsetToRoleName = reader.GetOrdinal("RoleName");
            Assert(5 == OffsetToRoleName, $"RoleName is {OffsetToRoleName} instead of 5 as expected");
        }
        public UserDAL ToUser(SqlDataReader reader)
        {
            UserDAL ExpectedReturnValue = new UserDAL();
            ExpectedReturnValue.UserID = reader.GetInt32(OffsetToUserID);
            ExpectedReturnValue.RoleID = reader.GetInt32(OffsetToRoleID);
            ExpectedReturnValue.Email = reader.GetString(OffsetToEmail);
            ExpectedReturnValue.Hash = reader.GetString(OffsetToHash);
            ExpectedReturnValue.Salt = reader.GetString(OffsetToSalt);
            ExpectedReturnValue.RoleName = reader.GetString(OffsetToRoleName);
            return ExpectedReturnValue;
        }
    }
}
