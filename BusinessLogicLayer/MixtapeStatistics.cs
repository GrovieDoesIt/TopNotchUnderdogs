using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class MixtapeStatistics

    {   public string ArtistName { get; set; }
        public int TotalSongsByArtist {get;set;}
        public int TotalLengthByArtist { get; set; }
        public double MixtapeAvgLengthByArtist { get; set; }
        public double AvgLengthPerSongBymixtape { get; set; }

        
        public double GetAvgSongLength(int NumberOfSongs, int Length)
        {
            double ExpectedReturnValue = 0;
            ExpectedReturnValue = (Length / NumberOfSongs);
            return ExpectedReturnValue;
        }
        public int GetAvgLength(List<int> Length)
        {
            double ExpectedReturnValue = Length.Average();
            int ReturnValue = (int)ExpectedReturnValue;
            return ReturnValue;
        }



    }
    public class MixtapeCalculator
    {
      public List<MixtapeStatistics> MixtapeComputer(List<MixtapeBLL> M)
        {//inputting the mixtapeBlls in the list with the name of M within mixtapeComputer which returns a list of Mixtape statistics//
            List<MixtapeStatistics> ExpectedReturnValue = new List<MixtapeStatistics>();
            //We're configuring the list to return us a new list of Mixtape statistics currently empty
           var Grouped =  M.GroupBy(X => X.ArtistName);
            //we are now grouping the list of Mixtape blls with the name of M using the key selector of Artist Name
            foreach (var G in Grouped)
                //Looping over all of the groups from the previous step
                //each group contains all the mxitapes of a given artist
            {
                MixtapeStatistics MS = new MixtapeStatistics();
                //looping over each one to create a mixtape statistics loaded with the correct data 
                MS.ArtistName = G.Key;
                //load it with the artist name found in the grouping key see line 41 we set the key
                MS.AvgLengthPerSongBymixtape = G.Average(x => x.Length/x.NumberOfSongs);
                //load it with the average length per songs which is length divided by the number of songs
                MS.MixtapeAvgLengthByArtist = G.Average(x => x.Length);
                //load it with the average length per mixtape instead of the number of songs
                MS.TotalLengthByArtist = G.Sum(x => x.Length);
                //load the total length and sum it up
                MS.TotalSongsByArtist = G.Sum(x => x.NumberOfSongs);
                //load the total number of songs and sum it up
                ExpectedReturnValue.Add(MS);
                //put the statistics into the expected return value and get ready to do the next loop
            }
            return ExpectedReturnValue;
        }
    }
}
