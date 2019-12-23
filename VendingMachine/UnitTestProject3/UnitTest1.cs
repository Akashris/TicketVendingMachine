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
        /* public void TestMethod2()
         {
             List<TheaterDetails> expected = new List<TheaterDetails>;
             expected.Add(2);
         }*/
    }
}
