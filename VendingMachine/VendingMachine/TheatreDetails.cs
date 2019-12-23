namespace VendingMachine
{
    using System;
    using System.Collections.Generic;
    public class TheaterDetails
    {
        private string _name;
        private int _capacity;


        public void SetName(string theaterName)
        {
            _name = theaterName;
        }

        public void SetCapacity(int theaterCapacity)
        {
            _capacity = theaterCapacity;
        }


        public string GetName()
        {
            return _name;
        }

        public int GetCapacity()
        {
            return _capacity;
        }


    }
}
