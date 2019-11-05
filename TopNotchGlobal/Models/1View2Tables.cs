using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopNotchGlobal.Models
{
    public class OneView2Tables
    {
        public int MixtapeID { get; set; }
        public string MixtapePath { get; set; }
        public string ArtistName { get; set; }
        public string Title { get; set; }
        public int NumberOfSongs { get; set; }
        public int Length { get; set; }


        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }

        public decimal RatingScore { get; set; }

    }

}