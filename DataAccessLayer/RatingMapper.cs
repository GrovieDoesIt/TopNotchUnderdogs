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
        int OffsetToUserID;
        int OffsetToRatingID;
        int OffsetToRatingScore;

        public RatingMapper(SqlDataReader reader)
        {
            OffsetToUserID = reader.GetOrdinal("UserID");
            Assert(0 == OffsetToUserID, $"UserID is {OffsetToUserID} instead of 0 as expected");
            OffsetToRatingID = reader.GetOrdinal("RatingID");
            Assert(1 == OffsetToRatingID, $"RatingID is {OffsetToRatingID} instead of 1 as expected");
            OffsetToRatingScore = reader.GetOrdinal("RatingScore");
            Assert(2 == OffsetToRatingScore, $"RatingScore is {OffsetToRatingScore} instead of 2 as expected");

        }

        public RatingDAL ToRate(SqlDataReader reader)
        {
            RatingDAL ExpectedReturnValue = new RatingDAL();
            ExpectedReturnValue.UserID = reader.GetInt32(OffsetToUserID);
            ExpectedReturnValue.RatingID = reader.GetInt32(OffsetToRatingID);
            ExpectedReturnValue.RatingScore = reader.GetDecimal(OffsetToRatingScore);

            return ExpectedReturnValue;
        }
    }
}
