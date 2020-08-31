using System;
using System.IO;

namespace Ticketing
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = "Tickets.csv";
            string menuChoice;
            string line;
            do
            {
                Console.WriteLine("What would you like to do?\n1) Look at tickets\n2) Add ticket to file\n3) Exit");
                menuChoice = Console.ReadLine();
                if(menuChoice == "1")
                {
                    StreamReader st = new StreamReader(file);
                    int counter = 0;
                    do{
                        line = st.ReadLine();
                        counter++;
                    }while(st.EndOfStream == false);
                    Console.WriteLine("Counter = " + counter);
                    st.Close();
                    StreamReader sr = new StreamReader(file);
                    line = sr.ReadLine();
                    for(int i=1; i < counter; i++)
                    {
                        string[] ticketInfo = new string[7];
                        line = sr.ReadLine();
                        ticketInfo = line.Split(',');
                        string[] ticketWatcher = new string[3];
                        string ticketWatchers = ticketInfo[6];
                        ticketWatcher = ticketWatchers.Split('|');
                        Console.WriteLine("Ticket ID: {0}\nSummary: {1}\nStatus: {2}\nPriority: {3}\nSubmitter: {4}\nAssigned to: {5}\nWatchers: {6}, {7}, {8}", 
                        ticketInfo[0], ticketInfo[1], ticketInfo[2], ticketInfo[3], ticketInfo[4], ticketInfo[5], ticketWatcher[0], ticketWatcher[1], ticketWatcher[2]);
                    }
                    sr.Close();
                }
                if(menuChoice == "2")
                {
                    StreamReader sr = new StreamReader(file);
                    int counter = 0;
                    do{
                        line = sr.ReadLine();
                        counter++;
                    }while(sr.EndOfStream == false);
                    sr.Close();
                    string ticketID = counter.ToString();
                    StreamWriter sw = new StreamWriter(file, append:true);
                    Console.WriteLine("Enter a summary");
                    string summary = Console.ReadLine();
                    Console.WriteLine("Is the ticket Open or Closed");
                    string openOrClosed = Console.ReadLine();
                    Console.WriteLine("What is the priority");
                    string priority = Console.ReadLine();
                    Console.WriteLine("Who is the submitter?");
                    string submitter = Console.ReadLine();
                    Console.WriteLine("Who is assigned to this ticket?");
                    string assigned = Console.ReadLine();
                    Console.WriteLine("Who is watching this ticket? Enter 3 total, 1 at a time");
                    string[] watchers = new string[3];
                    watchers[0] = Console.ReadLine();
                    watchers[1] = Console.ReadLine();
                    watchers[2] = Console.ReadLine();
                    sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}|{7}|{8}", ticketID, summary, openOrClosed, priority, submitter, assigned, watchers[0], watchers[1], watchers[2]);
                    sw.Close();
                    Console.WriteLine("{0}, {1}, {2}", watchers[0], watchers[1], watchers[2]);
                }
                

            }while(menuChoice == "1" || menuChoice == "2");
        }
    }
}
