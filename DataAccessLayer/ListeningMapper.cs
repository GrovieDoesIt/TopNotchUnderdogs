using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class ListeningMapper : Mapper
    {
        int OffsetToListeningID;
        int OffsetToUserID;
        int OffsetToMixtapeID;

        public ListeningMapper(SqlDataReader reader)
        {
            OffsetToListeningID = reader.GetOrdinal("ListeningID");
            Assert(0 == OffsetToListeningID, $"ListeningID is {OffsetToListeningID} instead of 0 as expected");
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(1 == OffsetToUserID, $" UserID is {OffsetToUserID} instead of 1 as expected");
            OffsetToMixtapeID = reader.GetOrdinal("MixtapeID");
            Assert(2 == OffsetToMixtapeID, $"MixtapeID is{OffsetToMixtapeID} instead of 2 as expected");
        }

        public ListeningsDAL ToListening(SqlDataReader reader)
        {
            ListeningsDAL ExpectedReturnValue = new ListeningsDAL();
            ExpectedReturnValue.ListeningID = reader.GetInt32(OffsetToMixtapeID);
            ExpectedReturnValue.UserID = reader.GetInt32(OffsetToUserID);
            ExpectedReturnValue.MixtapeID = reader.GetInt32(OffsetToMixtapeID);
            return ExpectedReturnValue;
        }
    }
}
