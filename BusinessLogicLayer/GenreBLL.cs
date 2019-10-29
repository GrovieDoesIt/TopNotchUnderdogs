using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class GenreBLL
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public GenreBLL(DataAccessLayer.GenreDAL Genre)
        {
            GenreID = Genre.GenreID;
            GenreName = Genre.GenreName;
        }
        public GenreBLL()
        {

        }
    }
}
