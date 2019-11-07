using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer// THis shows we're in the namespace of the DAL
{
   public class UserMapper : Mapper // a child class of our Mapper Parent class as we call into the mapper to use it during this class
    {
        int OffsetToUserID;
        int OffsetToRoleID;
        int OffsetToEmail;
        int OffsetToHash; //Here we're declaring the fields we'll need from the SQl Users table
        int OffsetToSalt;
        int OffsetToRoleName;

        public UserMapper(SqlDataReader reader)
        {//This is the constructor and the items in here are less efficient but are only executed one time
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == OffsetToUserID, $"UserID is {OffsetToUserID} instead of 0 as expected");//This method is using string comparisons and is less efficient than using the integer offsets
            OffsetToRoleID = reader.GetOrdinal("RoleID");
            Assert(4 == OffsetToRoleID, $"RoleID is {OffsetToRoleID} instead of 4 as expected");
            OffsetToEmail = reader.GetOrdinal("Email");
            Assert(1 == OffsetToEmail, $"Email is {OffsetToEmail} instead of 1 as expected");
            OffsetToHash = reader.GetOrdinal("Hash");
            Assert(2 == OffsetToHash, $"Hash is {OffsetToHash} instead of 2 as expected");// Here we're placing the different columns from our user table in the correct order in which they're labeled in the sql layer and they have to be in the right order at this point but later on It doesn't matter what order they're in as long as they're in the correct order here
            OffsetToSalt = reader.GetOrdinal("Salt");
            Assert(3 == OffsetToSalt, $"Salt is {OffsetToSalt} instead of 3 as expected");
            OffsetToRoleName = reader.GetOrdinal("RoleName");
            Assert(5 == OffsetToRoleName, $"RoleName is {OffsetToRoleName} instead of 5 as expected");
        }
        public UserDAL ToUser(SqlDataReader reader)
        {//this method is not the constructor but is more effecient because it uses integers and can be called multiple times
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
