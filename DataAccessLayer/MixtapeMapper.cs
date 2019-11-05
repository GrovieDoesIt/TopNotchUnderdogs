using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
   public class MixtapeMapper : Mapper
    {
        int OffsetToMixtapeID;
        int OffsetToMixtapePath;
        int OffsetToArtistName;
        int OffsetToTitle;
        int OffsetToNumberOfSongs;
        int OffsetToLength;
        public MixtapeMapper(SqlDataReader reader)
        {
            OffsetToMixtapeID = reader.GetOrdinal("MixtapeID");
            Assert(0 == OffsetToMixtapeID, $"MixtapeID is {OffsetToMixtapeID} instead of 0 as Expected");
            OffsetToMixtapePath = reader.GetOrdinal("MixtapePath");
            Assert(1 == OffsetToMixtapePath, $"MixtapePath is {OffsetToMixtapePath} instead of 1 as Expected");
            OffsetToArtistName = reader.GetOrdinal("ArtistName");
            Assert(2 == OffsetToArtistName, $"ArtistName is{OffsetToArtistName} instead of 2 as expected");
            OffsetToTitle = reader.GetOrdinal("Title");
            Assert(3 == OffsetToTitle, $"Title is {OffsetToTitle} instead of 3 as expected");
            OffsetToNumberOfSongs = reader.GetOrdinal("NumberOfSongs");
            Assert(4 == OffsetToNumberOfSongs, $"NumberOfSongs is{OffsetToNumberOfSongs} instead of 4 as expected");
            OffsetToLength = reader.GetOrdinal("Length");
            Assert(5 == OffsetToLength, $"Length is {OffsetToLength} instead of 5 as Expected");
        }
        public MixtapeDAL ToMixtape(SqlDataReader reader)
        {
            MixtapeDAL ExpectedReturnValue = new MixtapeDAL();
            ExpectedReturnValue.MixtapeID = reader.GetInt32(OffsetToMixtapeID);
            ExpectedReturnValue.MixtapePath = reader.GetString(OffsetToMixtapePath);
            ExpectedReturnValue.ArtistName = reader.GetString(OffsetToArtistName);
            ExpectedReturnValue.Title = reader.GetString(OffsetToTitle);
            ExpectedReturnValue.NumberOfSongs = reader.GetInt32(OffsetToNumberOfSongs);
            ExpectedReturnValue.Length = reader.GetInt32(OffsetToLength);
            return ExpectedReturnValue;
        }

    }
}
