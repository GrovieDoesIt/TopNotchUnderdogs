using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class GenreMapper : Mapper
    {
        int OffsetToGenreID;
        int OffsetToGenreName;
        public GenreMapper(SqlDataReader reader)
        {
            OffsetToGenreID = reader.GetOrdinal("GenreID");
            Assert(0 == OffsetToGenreID, $"GenreID is {OffsetToGenreID} instead of 0 as expected");
            OffsetToGenreName = reader.GetOrdinal("GenreName");
            Assert(1 == OffsetToGenreName, $"GenreName is {OffsetToGenreName} instead of 1 as expected");
        }
        public GenreDAL ToGenre(SqlDataReader reader)
        {
            GenreDAL ExpectedReturnValue = new GenreDAL();
            ExpectedReturnValue.GenreID = reader.GetInt32(OffsetToGenreID);
            ExpectedReturnValue.GenreName = reader.GetString(OffsetToGenreName);

            return ExpectedReturnValue;
        }

    }
}
