using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
       {

            List<ShowDetails> expected = new List<ShowDetails>();

            TheaterDetails satyam = new TheaterDetails();
            satyam.SetName("Satyam Cinemas");
            satyam.SetCapacity(50);

            TheaterDetails luxe = new TheaterDetails();
            luxe.SetName("Luxe Mini");
            luxe.SetCapacity(25);

            MoviesDetails avengers = new MoviesDetails();
            avengers.SetId(1);
            avengers.SetName("AVENGERS: ENDGAME");

            ShowDetails show1 = new ShowDetails();
            show1.SetTheater(satyam);
            show1.SetMovie(avengers);
            show1.SetShowTime("10:00 AM");
            ShowDetails show2 = new ShowDetails();
            show2.SetTheater(satyam);
            show2.SetMovie(avengers);
            show2.SetShowTime("14:00 PM");
            ShowDetails show4 = new ShowDetails();
            show4.SetTheater(luxe);
            show4.SetMovie(avengers);
            show4.SetShowTime("10:00 AM");

            expected.Add(show1);
            expected.Add(show2);
            expected.Add(show4);
            List<ShowDetails> actual = new List<ShowDetails>();
            Vendor vendorObject = new Vendor();
            actual = vendorObject.GetTheatersDetails("AVENGERS: ENDGAME");
            //Assert.AreEqual(expected[0], actual[0]);
            CollectionAssert.AreEqual(expected, actual);
        }
         public void TestMethod2()
         {
            bool actual;
            MoviesDetails avengers = new MoviesDetails();
            Vendor vendorObject = new Vendor();
            actual = vendorObject.AddToList(avengers);
            Assert.AreEqual(true, actual);
         }
        public void TestMethod3()
        {
            bool actual;
            TheaterDetails luxe = new TheaterDetails();
            Vendor vendorObject = new Vendor();
            actual = vendorObject.AddToList(luxe);
            Assert.AreEqual(true, actual);
        }
        public void TestMethod4()
        {
            bool actual;
            ShowDetails show6 = new ShowDetails();
            Vendor vendorObject = new Vendor();
            actual = vendorObject.AddToList(show6);
            Assert.AreEqual(true, actual);
        }
        public void TestMethod5()
        {
            List<MoviesDetails> actual = new List<MoviesDetails>();
            List<MoviesDetails> expected = new List<MoviesDetails>()
            {
                new MoviesDetails{ movie_id=1 , movie_name="AVENGERS: ENDGAME" } ,
                new MoviesDetails{ movie_id=2 , movie_name= "STAR WARS: THE RISE OF SKYWALKER" } ,
                new MoviesDetails{ movie_id=3  , movie_name="SPIDERMAN: FAR FROM HOME" },
                new MoviesDetails{ movie_id=0  , movie_name=null }
            };
            Vendor vendorObject = new Vendor();
            MoviesDetails avengers = new MoviesDetails();  
            actual = vendorObject.MoviesDetails();
            vendorObject.AddToList(avengers);
            CollectionAssert.AreEqual(expected, actual);
        }
        public void TestMethod6()
        {
            bool actual;
            Ticket ticket = new Ticket();
            Vendor vendorObject = new Vendor();
            actual = vendorObject.AddToList(ticket);
            Assert.AreEqual(true, actual);
        }
        public void TestMethod7()
        {
            string actual,expected="10:00 AM";
            ShowDetails show1 = new ShowDetails();
            show1.SetShowTime("10:00 AM");
            actual = show1.GetShowTime();
            Assert.AreEqual(expected, actual);
        }

        public void TestMethod8()
        {
            MoviesDetails avengers = new MoviesDetails();
            string expected = "AVENGERS: ENDGAME";
            avengers.SetName("AVENGERS: ENDGAME");
            string actual = avengers.GetName();
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod9()
        {
            MoviesDetails avengers = new MoviesDetails();
            int expected = 1;
            avengers.SetId(1);
            int actual = avengers.GetId();
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod10()
        {
            
            string expected = "Satyam Cinemas";
            TheaterDetails satyam = new TheaterDetails();
            satyam.SetName("Satyam Cinemas");
            
            string actual = satyam.GetName();
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod11()
        {

            int expected = 50;
            TheaterDetails satyam = new TheaterDetails();
            satyam.SetCapacity(50);
            int actual = satyam.GetCapacity();
            Assert.AreEqual(expected, actual);
        }
    }
}
