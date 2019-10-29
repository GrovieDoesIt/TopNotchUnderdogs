using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class RatingBLL
    {
        public int UserID { get; set; }
        public int RatingID { get; set; }
        public decimal RatingScore { get; set; }
        public RatingBLL(DataAccessLayer.RatingDAL rating)
        {
            UserID = rating.UserID;
            RatingID = rating.RatingID;
            RatingScore = rating.RatingScore;
        }
        public RatingBLL()
        {

        }
    }
}
