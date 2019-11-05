using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class RatingMapper : Mapper
    {
        int OffsetToMixtapeID;
        int OffsetToUserID;
        int OffsetToRatingScore;

        public RatingMapper(SqlDataReader reader)
        {
            OffsetToMixtapeID = reader.GetOrdinal("MixtapeID");
            Assert(0 == OffsetToMixtapeID, $"MixtapeID is {OffsetToMixtapeID} instead of 0 as expected");
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(1 == OffsetToUserID, $"UserID is {OffsetToUserID} instead of 1 as expected");
            OffsetToRatingScore = reader.GetOrdinal("RatingScore");
            Assert(2 == OffsetToRatingScore, $"RatingScore is {OffsetToRatingScore} instead of 2 as expected");

        }

        public RatingDAL ToRate(SqlDataReader reader)
        {
            RatingDAL ExpectedReturnValue = new RatingDAL();
            ExpectedReturnValue.MixtapeID = reader.GetInt32(OffsetToMixtapeID);
            ExpectedReturnValue.UserID = reader.GetInt32(OffsetToUserID);
            ExpectedReturnValue.RatingScore = reader.GetDecimal(OffsetToRatingScore);

            return ExpectedReturnValue;
        }
    }
}
