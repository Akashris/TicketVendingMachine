namespace VendingMachine
{
    using System;
    using System.Collections.Generic;

    public class MainVendingMachine
    {
        enum HomeScreen { AddTicket = 1, ShowMovie, }


        Vendor vendorObject = new Vendor();

        public void GetMoviesList()
        {
            Console.WriteLine("\n\t\t\t\t\tMovies:-\n");
            foreach (var movie in vendorObject.MoviesDetails())
            {
                Console.WriteLine("\t\t\t\t\t* {0} ", movie.GetName());
            }

        }


        public void AddTicket()
        {
            Console.WriteLine("\n\t\t\t\t\t----Movies Currently Running----\n");
            int movieCount = 1;

            foreach (var movie in vendorObject.MoviesDetails())
            {
                Console.WriteLine("\t\t\t\t\t{0}.) {1} ", movieCount, movie.GetName());
                movieCount++;
            }

            Console.Write("\n\t\t\t\t\tChoose a Movie:- ");

            int movieIndex = Convert.ToInt16(Console.ReadLine());

            List<ShowDetails> theaterSet = vendorObject.GetTheatersDetails(vendorObject.movieList[movieIndex - 1].GetName());

            int theaterCount = 1;

            foreach (var theater in theaterSet)
            {
                Console.WriteLine("\t\t\t\t\t{2}.){0} [ {1} ]", theater.GetTheater().GetName(), theater.GetShowTime(), theaterCount);
                theaterCount++;
            }

            Console.Write("\n\t\t\t\t\tEnter Your Choice:- ");
            int theaterIndex = Convert.ToInt16(Console.ReadLine());

            int availableTickets = theaterSet[theaterIndex - 1].GetTheater().GetCapacity() - vendorObject.GetReportDetails(theaterSet[theaterIndex - 1]).Count;
            if (availableTickets != 0)
            {
                Console.WriteLine("\n\t\t\t\t\t***Only {0} tickets are available****\n", availableTickets);

                Ticket ticketObject = new Ticket();

                ticketObject.Number = vendorObject.ticketList.Count + 1;
                ticketObject.Show = theaterSet[theaterIndex - 1];


                Console.Write("\n\t\t\t\t\tChoose a Ticket Class \n\t\t\t\t\t1.)First 350 INR (or) \n\t\t\t\t\t2.)Second 250 INR (or) \n\t\t\t\t\t3.)Third 150 INR\n\t\t\t\t\t");

                int SeatClass = Convert.ToInt32(Console.ReadLine());


                if (SeatClass == 1)
                {
                    ticketObject.Price = 350;
                }
                else if (SeatClass == 2)
                {
                    ticketObject.Price = 250;
                }
                else if (SeatClass == 3)
                {
                    ticketObject.Price = 150;
                }


                vendorObject.AddToList(ticketObject);

                Console.WriteLine("\n\t\t\t\t\t_________________________________________");
                Console.WriteLine("\t\t\t\t\t|TicketNumber | {0}", ticketObject.Number);
                Console.WriteLine("\t\t\t\t\t|Theater Name | {0}", ticketObject.Show.GetTheater().GetName());
                Console.WriteLine("\t\t\t\t\t|Movie        | {0}", ticketObject.Show.GetMovie().GetName());
                Console.WriteLine("\t\t\t\t\t|Show Time    | {0}", ticketObject.Show.GetShowTime());
                Console.WriteLine("\t\t\t\t\t|Seat Type    | {0}", SeatClass);
                Console.WriteLine("\t\t\t\t\t|Amount       | {0}", ticketObject.Price);
                Console.WriteLine("\t\t\t\t\t_________________________________________\n");
                Console.WriteLine("\n\t\t\t\t\t***THANKS FOR BOOKING***\n");

            }
            else
            {
                Console.WriteLine("\n\t\t\t\t\t\t****Seat are not available****\n");
            }

        }

        public void GetReport()
        {
            foreach (var show in vendorObject.showList)
            {
                string theater = show.GetTheater().GetName();
                string showTime = show.GetShowTime();
                double totalTicketAmount = 0.0;
                foreach (var item in vendorObject.GetReportDetails(show))
                {
                    totalTicketAmount += item.Price;
                }

                vendorObject.DailyReportGenerate(theater, showTime, totalTicketAmount);
            }

            Console.Write("\t\t\t\t\t");
            Console.WriteLine(@"Report Generated on - :E:\Akash\ticketVendingMachine\reportGenerate");
        }


        static void Main(string[] args)
        {
            MainVendingMachine ticketVendingMachineObject = new MainVendingMachine();
            //Main Menu displaying using switch case
            while (true)
            {
                try
                {   
                    Console.WriteLine("\n");
                    Console.WriteLine("\t\t\t\t\t****Welcome to TicketOLD.com :)  ****\n");
                    Console.WriteLine("\t\t\t\t\tPlease Choose The Required Option\n");
                    Console.WriteLine("\n\t\t\t\t\t\t{0}.)  Add ticket", (int)HomeScreen.AddTicket);
                    Console.WriteLine("\t\t\t\t\t\t{0}.)  Show Movie", (int)HomeScreen.ShowMovie);
                    Console.Write("\n\t\t\t\t\t\tEnter Your Choice : ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        //Adding a Ticket
                        case (int)HomeScreen.AddTicket:
                            try
                            {
                                try
                                {
                                    ticketVendingMachineObject.AddTicket();
                                }
                                catch (FormatException)
                                {
                                    ticketVendingMachineObject.AddTicket();
                                }

                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                ticketVendingMachineObject.AddTicket();
                            }
                            break;

                        //Displaying List of Movies 
                        case (int)HomeScreen.ShowMovie:
                            ticketVendingMachineObject.GetMoviesList();
                            goto booking;//jumoing to booking block

                        default:
                            Console.WriteLine("\n\t\t\t\t\t\tWrong Entry\n");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n\t\t\t\t\t\tWrong Entry\n");
                }
                //Report generation
                Console.WriteLine("\n\t\t\t\t\tWould You Like To View The Report Yes or No ?:- ");
                var yesOrNo = Convert.ToString(Console.ReadLine());
                if (yesOrNo == "yes" || yesOrNo == "Yes" || yesOrNo == "YES" || yesOrNo == "yEs" || yesOrNo == "yeS" || yesOrNo == "YeS")
                {
                    try
                    {
                        try
                        {
                            ticketVendingMachineObject.GetReport();
                        }
                        catch (FormatException)
                        {
                            ticketVendingMachineObject.GetReport();
                        }

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        ticketVendingMachineObject.GetReport();
                    }

                }
                //booking another ticket
                booking:
                {
                    Console.WriteLine("\n\t\t\t\t\tDo You Wish To Book Another Ticket Yes or No ? :- ");
                    yesOrNo = Convert.ToString(Console.ReadLine());
                    if (yesOrNo == "yes" || yesOrNo == "Yes" || yesOrNo == "YES" || yesOrNo == "yEs" || yesOrNo == "yeS" || yesOrNo == "YeS")
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}