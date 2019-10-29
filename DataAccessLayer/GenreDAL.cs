using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class GenreDAL
    {
        public int GenreID { get; set; }
        public string GenreName { get; set; }
        public override string ToString()
        {
            return $"{GenreID,3} {GenreName}";
        }
    }
}
