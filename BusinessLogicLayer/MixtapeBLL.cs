using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
   public class MixtapeBLL
    { 
        public int MixtapeID { get; set; }
        public string MixtapePath { get; set; }
        public string ArtistName { get; set; }
        public string Title { get; set; }
        public int NumberOfSongs { get; set; }
        public int Length { get; set; }
        public MixtapeBLL(DataAccessLayer.MixtapeDAL Mixtape)
        {
            MixtapeID = Mixtape.MixtapeID;
            MixtapePath = Mixtape.MixtapePath;
            ArtistName = Mixtape.ArtistName;
            Title = Mixtape.Title;
            NumberOfSongs = Mixtape.NumberOfSongs;
            Length = Mixtape.Length;
        }
        public MixtapeBLL()
        {

        }
    }
    
}
