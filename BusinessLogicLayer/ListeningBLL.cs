using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
   public class ListeningBLL
    {
        public int ListeningID { get; set; }
        public int MixtapeID { get; set; }
        public int UserID { get; set; }
        public ListeningBLL(DataAccessLayer.ListeningsDAL Listening)
        {
            ListeningID = Listening.ListeningID;
            MixtapeID = Listening.MixtapeID;
            UserID = Listening.UserID;
        }
        public ListeningBLL()
        {

        }
    }
}
