using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Tests
{
    [TestClass()]
    public class MixtapeCalculatorTests
    {
        [TestMethod()]
        public void MixtapeComputerTest_MixtapesAreNull_ShouldThrowException()
        {   //Arrange
            MixtapeCalculator MC = new MixtapeCalculator();
            List<MixtapeBLL> input = null;
           
            //Act
            Assert.ThrowsException<ArgumentNullException>(() => MC.MixtapeComputer(input));
            //Asssert



            
        }
        [TestMethod()]
        public void MixtapeComputerTest_MixtapesAreEmpty_ShouldBeZero()
        {   //Arrange
            MixtapeCalculator MC = new MixtapeCalculator();
            List<MixtapeBLL> input = new List<MixtapeBLL>();
            List<MixtapeStatistics> ExpectedOutput = new List<MixtapeStatistics>();

            //Act
            var Actualoutput = MC.MixtapeComputer(input);
            //Asssert
            Assert.AreEqual(ExpectedOutput.Count, Actualoutput.Count);



        }
        [TestMethod()]
        public void MixtapeComputerTest_StandardMixtapesAvg_ShouldBeFifteen()
        {   //Arrange
            MixtapeCalculator MC = new MixtapeCalculator();
            List<MixtapeBLL> input = new List<MixtapeBLL>();
            MixtapeBLL one = new MixtapeBLL();
            one.Length = 10;
            one.ArtistName = "HollywoodGrove";
            one.MixtapeID = 1;
            one.NumberOfSongs = 1;
            input.Add(one);
            MixtapeBLL two = new MixtapeBLL();
            two.Length = 20;
            two.ArtistName = "HollywoodGrove";
            two.MixtapeID = 2;
            two.NumberOfSongs = 2;
            input.Add(two);
            int ExpectedOutput = 15;

            //Act
            var Actualoutput = MC.MixtapeComputer(input);
            //Asssert
            Assert.AreEqual(ExpectedOutput, Actualoutput[0].MixtapeAvgLengthByArtist);



        }
        [TestMethod()]
        public void MixtapeComputerTest_LengthPerSongAvg_ShouldBe5()
        {   //Arrange
            MixtapeCalculator MC = new MixtapeCalculator();
            List<MixtapeBLL> input = new List<MixtapeBLL>();
            MixtapeBLL one = new MixtapeBLL();
            one.Length = 10;
            one.MixtapeID = 1;
            one.NumberOfSongs = 2;
            input.Add(one);
            MixtapeBLL two = new MixtapeBLL();
            two.Length = 20;
            two.MixtapeID = 2;
            two.NumberOfSongs = 4;
            input.Add(two);
            int ExpectedOutput = 5;

            //Act
            var Actualoutput = MC.MixtapeComputer(input);
            //Asssert
            Assert.AreEqual(ExpectedOutput, Actualoutput[0].AvgLengthPerSongBymixtape);



        }
        [TestMethod()]
        public void MixtapeComputerTest_TotalLengthByArtist_ShouldBe20()
        {   //Arrange
            MixtapeCalculator MC = new MixtapeCalculator();
            List<MixtapeBLL> input = new List<MixtapeBLL>();
            MixtapeBLL one = new MixtapeBLL();
            one.ArtistName = "VictorOrtiz";
            one.Length = 10;
            one.MixtapeID = 1;
            one.NumberOfSongs = 2;
            input.Add(one);
            MixtapeBLL two = new MixtapeBLL();
            two.ArtistName = "VictorOrtiz";
            two.Length = 10;
            two.MixtapeID = 2;
            two.NumberOfSongs = 3;
            input.Add(two);
            int ExpectedOutput = 20;

            //Act
            var Actualoutput = MC.MixtapeComputer(input);
            //Asssert
            Assert.AreEqual(ExpectedOutput, Actualoutput[0].TotalLengthByArtist);



        }
        [TestMethod()]
        public void MixtapeComputerTest_TotalSongsByArtist_ShouldBe7()
        {   //Arrange
            MixtapeCalculator MC = new MixtapeCalculator();
            List<MixtapeBLL> input = new List<MixtapeBLL>();
            MixtapeBLL one = new MixtapeBLL();
            one.ArtistName = "HollywoodGrove";
            one.Length = 10;
            one.MixtapeID = 1;
            one.NumberOfSongs = 4;
            input.Add(one);
            MixtapeBLL two = new MixtapeBLL();
            two.ArtistName = "HollywoodGrove";
            two.Length = 10;
            two.MixtapeID = 2;
            two.NumberOfSongs = 3;
            input.Add(two);
            int ExpectedOutput = 7;

            //Act
            var Actualoutput = MC.MixtapeComputer(input);
            //Asssert
            Assert.AreEqual(ExpectedOutput, Actualoutput[0].TotalSongsByArtist);



        }
    }
    
}