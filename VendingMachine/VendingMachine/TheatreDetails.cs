namespace VendingMachine
{
    using System;
    using System.Collections.Generic;
    public class TheaterDetails
    {
        private string theatre_name;
        private int theatre_capacity;


        public void SetName(string theaterName)
        {
            theatre_name = theaterName;
        }

        public void SetCapacity(int theaterCapacity)
        {
            theatre_capacity = theaterCapacity;
        }


        public string GetName()
        {
            return theatre_name;
        }

        public int GetCapacity()
        {
            return theatre_capacity;
        }


    }
}
