using System;

class Program
{
    static void Main(string[] args)
    {
        Address lectureAddress = new Address("123 Main St", "Anytown", "Anystate", "12345");
        Lecture lecture = new Lecture("Tech Talk", "A lecture on the latest in tech", "06/15/2024", "10:00 AM", lectureAddress, "Dr. Tech", 100);

        Address receptionAddress = new Address("456 Elm St", "Othertown", "Otherstate", "67890");
        Reception reception = new Reception("Networking Event", "An event to network with peers", "06/20/2024", "6:00 PM", receptionAddress, "rsvp@example.com");

        Address outdoorAddress = new Address("789 Oak St", "Sometown", "Somestate", "11223");
        OutdoorGathering outdoor = new OutdoorGathering("Summer Picnic", "An outdoor picnic for families", "07/01/2024", "12:00 PM", outdoorAddress, "Sunny and warm");

        Event[] events = { lecture, reception, outdoor };

        foreach (Event e in events)
        {
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine();
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine();
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine();
        }
    }
}