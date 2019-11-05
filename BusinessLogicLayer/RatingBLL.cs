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
        public int MixtapeID { get; set; }
        public int UserID { get; set; }
        public decimal RatingScore { get; set; }
        public RatingBLL(DataAccessLayer.RatingDAL rating)
        {
            MixtapeID = rating.MixtapeID;
            UserID = rating.UserID;
            RatingScore = rating.RatingScore;
        }
        public RatingBLL()
        {

        }
    }
}
