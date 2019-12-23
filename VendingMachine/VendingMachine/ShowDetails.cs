namespace VendingMachine
{
    public class ShowDetails
    {
        private string _showTime;
        private TheaterDetails _theater;
        private MoviesDetails _movie;


        public void SetShowTime(string showTime)
        {
            _showTime = showTime;
        }

        public void SetTheater(TheaterDetails theater)
        {
            _theater = theater;
        }

        public void SetMovie(MoviesDetails movie)
        {
            _movie = movie;
        }

        public string GetShowTime()
        {
            return _showTime;
        }

        public TheaterDetails GetTheater()
        {
            return _theater;
        }

        public MoviesDetails GetMovie()
       {
            return _movie;
        }
    }
}
