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
        public void MixtapeComputerTest_MixtapesAreNull_ShouldThrowException()//using our mixtape calculator we are going to check to see if the mixtapes are null will it throw an actual Exception
        {   //Arrange
            MixtapeCalculator MC = new MixtapeCalculator();
            List<MixtapeBLL> input = null;//we will make the List of mixtapes null 
           
            //Act
            Assert.ThrowsException<ArgumentNullException>(() => MC.MixtapeComputer(input));//this should throw that exception we're testing
            //Asssert



            
        }
        [TestMethod()]
        public void MixtapeComputerTest_MixtapesAreEmpty_ShouldBeZero()//we're going to check to see what is the total value of the mixtapes when they are empty our expected  behavior is that they are going to be zero
        {   //Arrange
            MixtapeCalculator MC = new MixtapeCalculator();
            List<MixtapeBLL> input = new List<MixtapeBLL>();
            List<MixtapeStatistics> ExpectedOutput = new List<MixtapeStatistics>();

            //Act
            var Actualoutput = MC.MixtapeComputer(input);
            //Asssert
            Assert.AreEqual(ExpectedOutput.Count, Actualoutput.Count);//counting the expected and actual outputs to check and be sure they are equal



        }
        [TestMethod()]
        public void MixtapeComputerTest_StandardMixtapesAvg_ShouldBeFifteen()// The state of the test is us averaging the mixtapes avg length and we expect the behavior to be that the avg is fifteen
        {   //Arrange
            MixtapeCalculator MC = new MixtapeCalculator();
            List<MixtapeBLL> input = new List<MixtapeBLL>();//we will begin to input the necessary fields of information we need into two different mixtapes and we will then average them out to see if our expected behavior is accurate or not
            MixtapeBLL one = new MixtapeBLL();
            one.Length = 10;
            one.ArtistName = "HollywoodGrove";
            one.MixtapeID = 1;
            one.NumberOfSongs = 1;
            input.Add(one);//we are putting in the fields of information and their values for us to be able to run the test
            MixtapeBLL two = new MixtapeBLL();
            two.Length = 20;
            two.ArtistName = "HollywoodGrove";
            two.MixtapeID = 2;
            two.NumberOfSongs = 2;
            input.Add(two);
            int ExpectedOutput = 15;//This is our Expected behavior from the test so the expected result

            //Act
            var Actualoutput = MC.MixtapeComputer(input);//This is the actual value that we are receiving from the test
            //Asssert
            Assert.AreEqual(ExpectedOutput, Actualoutput[0].MixtapeAvgLengthByArtist);



        }
        [TestMethod()]
        public void MixtapeComputerTest_LengthPerSongAvg_ShouldBe5()// The average length per song by mixtape in this test should be 5
        {   //Arrange
            MixtapeCalculator MC = new MixtapeCalculator();
            List<MixtapeBLL> input = new List<MixtapeBLL>();
            MixtapeBLL one = new MixtapeBLL();//we will again take all the required information we need per mixtape 
            one.Length = 10;
            one.MixtapeID = 1;
            one.NumberOfSongs = 2;
            input.Add(one);//we are now inputing all of this information we defined in the lines above into the mixtape bll with the name of one
            MixtapeBLL two = new MixtapeBLL();
            two.Length = 20;
            two.MixtapeID = 2;
            two.NumberOfSongs = 4;
            input.Add(two);//we are taking all of the above information and inserting it into the new mixtape bll of 2
            int ExpectedOutput = 5;//we are declaring the Expected output we declared in the ExpectedBehavior part in our unit testing naming convention so the output should be 5

            //Act
            var Actualoutput = MC.MixtapeComputer(input);
            //Asssert
            Assert.AreEqual(ExpectedOutput, Actualoutput[0].AvgLengthPerSongBymixtape);//Is testing wether the values are equal and throw an exception in our test if it is not



        }
        [TestMethod()]
        public void MixtapeComputerTest_TotalLengthByArtist_ShouldBe20()//similar to the above tests we are using the MethodName_StateUnderTest_ExpectedBehavior naming convention so we're saying the total length of songs by the artist should be 20 when these 2 mixtape bll's are compared
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
        public void MixtapeComputerTest_TotalSongsByArtist_ShouldBe7()//Here we should be getting the total Number of Songs by the artist using similar methods as a few of the above methods
        {   //Arrange
            MixtapeCalculator MC = new MixtapeCalculator();
            List<MixtapeBLL> input = new List<MixtapeBLL>();
            MixtapeBLL one = new MixtapeBLL();
            one.ArtistName = "HollywoodGrove";
            one.Length = 10;
            one.NumberOfSongs = 4;
            input.Add(one);
            MixtapeBLL two = new MixtapeBLL();
            two.ArtistName = "HollywoodGrove";
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