namespace VendingMachine
{
    using System;

    public class MoviesDetails
    {
        public int movie_id;
        public string movie_name;

        public void SetId(int movieId)
        {
            movie_id = movieId;
        }

        public void SetName(string movieName)
        {
            movie_name = movieName;
        }

        public string GetName()
        {
            return movie_name;
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