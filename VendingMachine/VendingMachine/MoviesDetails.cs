namespace VendingMachine
{
    using System;

    public class MoviesDetails
    {
        private int _id;
        private string _name;

        public void SetId(int movieId)
        {
            _id = movieId;
        }

        public void SetName(string movieName)
        {
            _name = movieName;
        }

        public string GetName()
        {
            return _name;
        }
    }
    public class Ticket
    {
        public int Number { get; set; }

        public ShowDetails Show { get; set; }

        public string SeatType { get; set; }

        public double Price { get; set; }

    }
}