namespace VendingMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class Vendor
    {
        public List<TheaterDetails> theaterList = new List<TheaterDetails>();

        public List<MoviesDetails> movieList = new List<MoviesDetails>();

        public List<ShowDetails> showList = new List<ShowDetails>();

        public List<Ticket> ticketList = new List<Ticket>();

        public Vendor()
        {
            TheaterDetails satyam = new TheaterDetails();
            satyam.SetName("Satyam Cinemas");
            satyam.SetCapacity(50);
            AddToList(satyam);
            TheaterDetails luxe = new TheaterDetails();
            luxe.SetName("Luxe Mini");
            luxe.SetCapacity(25);
            AddToList(luxe);
            MoviesDetails avengers = new MoviesDetails();
            MoviesDetails starWars = new MoviesDetails();
            MoviesDetails spiderman = new MoviesDetails();
            avengers.SetId(1);
            avengers.SetName("AVENGERS: ENDGAME");
            AddToList(avengers);
            starWars.SetId(2);
            starWars.SetName("STAR WARS: THE RISE OF SKYWALKER");
            AddToList(starWars);
            spiderman.SetId(3);
            spiderman.SetName("SPIDERMAN: FAR FROM HOME");
            AddToList(spiderman);
            ShowDetails show1 = new ShowDetails();
            show1.SetTheater(satyam);
            show1.SetMovie(avengers);
            show1.SetShowTime("10:00 AM");
            AddToList(show1);
            ShowDetails show2 = new ShowDetails();
            show2.SetTheater(satyam);
            show2.SetMovie(avengers);
            show2.SetShowTime("14:00 PM");
            AddToList(show2);
            ShowDetails show3 = new ShowDetails();
            show3.SetTheater(satyam);
            show3.SetMovie(spiderman);
            show3.SetShowTime("18:00 PM");
            AddToList(show3);
            ShowDetails show4 = new ShowDetails();
            show4.SetTheater(luxe);
            show4.SetMovie(avengers);
            show4.SetShowTime("10:00 AM");
            AddToList(show4);
            ShowDetails show5 = new ShowDetails();
            show5.SetTheater(luxe);
            show5.SetMovie(spiderman);
            show5.SetShowTime("15:00 PM");
            AddToList(show5);
            ShowDetails show6 = new ShowDetails();
            show6.SetTheater(luxe);
            show6.SetMovie(starWars);
            show6.SetShowTime("18:30 PM");
            AddToList(show6);

        }
        public bool AddToList(TheaterDetails theater)
        {
            theaterList.Add(theater);
            return true;
        }

        public bool AddToList(MoviesDetails movie)
        {
            movieList.Add(movie);
            return true;
        }

        public bool AddToList(ShowDetails show)
        {
            showList.Add(show);
            return true;
        }

        public bool AddToList(Ticket ticket)
        {
            ticketList.Add(ticket);
            return true;
        }

        public List<MoviesDetails> MoviesDetails()
        {
            return movieList;
        }

        public List<ShowDetails> GetTheatersDetails(string movieName)
        {
            var getTheaters = showList.Where(theaterList => theaterList.GetMovie().GetName().ToString() == movieName);

            return getTheaters.ToList<ShowDetails>();
        }

        public List<Ticket> GetReportDetails(ShowDetails show)
        {
            var getTickets = ticketList.Where(ticket => ticket.Show == show);

            return getTickets.ToList<Ticket>();
        }

        private void DailyReportPrint(string theaterName, string showTime, double totalAmount, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine("{0},{1},{2} ", theaterName, showTime, totalAmount);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void DailyReportGenerate(string theaterName, string showTime, double totalAmount)
        {
            try
            {
                Directory.CreateDirectory(@"E:\Akash\ticketVendingMachine\reportGenerate");
                string csvFileName = @"Daily_Report_Generated-" + DateTime.Now.ToString("yyyy dd MMMM  HH-mm") + ".csv";
                string csvFilePath = @"E:\Akash\ticketVendingMachine\reportGenerate" + "\\" + csvFileName;
                using (StreamWriter streamWriter = File.AppendText(csvFilePath))
                {
                    DailyReportPrint(theaterName, showTime, totalAmount, streamWriter);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }

}