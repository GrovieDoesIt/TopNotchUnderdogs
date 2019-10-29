using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class MixtapeDAL
    {
        public int MixtapeID { get; set; }
        public string ArtistName { get; set; }
        public string Title { get; set; }
        public int NumberOfSongs { get; set; }
        public int Length { get; set; }
        public override string ToString()
        {
            return $"{MixtapeID, 3} {ArtistName} {Title} {NumberOfSongs} {Length}" ;
        }
    }
}
