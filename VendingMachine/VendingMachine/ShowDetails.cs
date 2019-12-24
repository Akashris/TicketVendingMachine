namespace VendingMachine
{
    public class ShowDetails
    {
        private string show_Time;
        private TheaterDetails theater_details;
        private MoviesDetails movie_details;


        public void SetShowTime(string showTime)
        {
            show_Time = showTime;
        }

        public void SetTheater(TheaterDetails theater)
        {
            theater_details = theater;
        }

        public void SetMovie(MoviesDetails movie)
        {
            movie_details = movie;
        }

        public string GetShowTime()
        {
            return show_Time;
        }

        public TheaterDetails GetTheater()
        {
            return theater_details;
        }

        public MoviesDetails GetMovie()
       {
            return movie_details;
        }
    }
}
