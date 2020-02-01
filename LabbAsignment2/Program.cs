using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabbAsignment2
{
  
    class Program
    {
        static void Main(string[] args)
        {


            using (AgencyModel dbConnection = new AgencyModel())
            {
                // Update Traveler
                var selectedUpTraveler = dbConnection.Travelers.Where(f => f.Name == "Delil").FirstOrDefault();
                // Here you choose which Traveler you want to change
                // In this case we change Delil to Bkörn 
                if (selectedUpTraveler != null)
                {
                    selectedUpTraveler.Name = "Björn";

                    dbConnection.SaveChanges();


                }

                // Update Destination
                var selectedUpDestination = dbConnection.Destination.Where(p => p.Country == "Turkey").FirstOrDefault();
                // Here you choose which counry and city you would like to change
                // In this case we change Turkey to Sweden and östersund as city
                if (selectedUpDestination != null)
                {
                    selectedUpDestination.Country = "Sweden"; // County changes
                    selectedUpDestination.City = "Östersund";// City C changes
                    dbConnection.SaveChanges();
                    // Note that sometimes there is same country name with different city in the destination list

                }

                bool listRunning = true;
                while (listRunning)
                {
                    char ch;

                    ShowMenu(); 

                    ch = Char.Parse(Console.ReadLine());

                    switch (ch)
                    {

                        case '1':
                            ShowAgencies(dbConnection);
                            Console.WriteLine("Press [ENTER] to go back to the menu");
                            Console.ReadLine();
                            Console.Clear();

                            break;
                        case '2':
                            ShowTravelers(dbConnection);
                            Console.WriteLine("Press [ENTER] to go back to the menu");
                            Console.ReadLine();
                            Console.Clear();

                            break;

                        case '3':
                            ListOfDestinationsAndCreationOfTraveler(dbConnection);
                            Console.WriteLine("Press [ENTER] to go back to the menu");
                            Console.ReadLine();
                            Console.Clear();


                            break;
                        case '4':
                            DestinationCreation(dbConnection);

                            Console.WriteLine("Press [ENTER] to go back to the menu");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case '5':
                            DeleteTraveler(dbConnection);
                            Console.WriteLine("Press [ENTER] to go back to the menu");
                            Console.ReadLine();
                            Console.Clear();

                            break;

                        case '6':
                            DeleteDestination(dbConnection);
                            Console.WriteLine("Press [ENTER] to go back to the menu");
                            Console.ReadLine();
                            Console.Clear();


                            break;
                    }
                }
            }
        }

        private static void DeleteDestination(AgencyModel dbConnection)
        {
            Console.WriteLine("____________________________________");
            Console.WriteLine("List of destinations:");
            Console.WriteLine("____________________________________");

            var destinations = dbConnection.Destination.ToList();
            for (int i = 0; i < destinations.Count; i++)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Destination Id: " + destinations[i].Id);
                Console.WriteLine("Country: " + destinations[i].Country);
                Console.WriteLine("City: " + destinations[i].City);
            }

            int dest = 0;
            Console.WriteLine("____________________________________");

            Console.WriteLine("Type which destination you want to delete by giving DestinationId:");
            dest = int.Parse(Console.ReadLine());
            var selectedDest = dbConnection.Destination.Find(dest);


            if (selectedDest != null)
            {
                dbConnection.Destination.Remove(selectedDest);
                dbConnection.SaveChanges();

            }
            Console.WriteLine("The selected destination has been deleted from the database!");
        }


        private static void DeleteTraveler(AgencyModel dbConnection)
        {
            Console.WriteLine("____________________________");

            Console.WriteLine("____________________________________");
            Console.WriteLine("List of travelers:");
            Console.WriteLine("____________________________________");
            var travelers = dbConnection.Travelers.ToList();
            for (int i = 0; i < travelers.Count; i++)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Traveler id: " + travelers[i].Id);
                Console.WriteLine("Traveler Name: " + travelers[i].Name);

            }

            int answer = 0;
            Console.WriteLine("____________________________________");

            Console.WriteLine("Type which traveler you want to delete by giving TravelerId:");
            answer = int.Parse(Console.ReadLine());
            var selectedPerson = dbConnection.Travelers.Find(answer);


            if (selectedPerson != null)
            {
                dbConnection.Travelers.Remove(selectedPerson);
                dbConnection.SaveChanges();

            }
            Console.WriteLine("The selected person has been deleted from the database!");
        }

        private static void ShowMenu()
        {
            Console.WriteLine("1. List of agencies");
       
           
            Console.WriteLine("2. List of travelers and their destinations");

           
            Console.WriteLine("3. See available destinations and create a new traveler");


            Console.WriteLine("4. Create a new destination");

            Console.WriteLine("5. Delete a Traveler");

            Console.WriteLine("6. Delete a Destination");






            Console.WriteLine("Please enter your choice from above: ");
        }

        private static void DestinationCreation(AgencyModel dbConnection)
        {
            Console.WriteLine("____________________________");
            Console.WriteLine("Create a new destination!");
            var addDestination = new Destination();

            Console.WriteLine("Register a city: ");
            addDestination.City = Console.ReadLine();

            Console.WriteLine("Register a Country: ");
            addDestination.Country = Console.ReadLine();
            dbConnection.Destination.Add(addDestination);
            dbConnection.SaveChanges();
            Console.WriteLine("The information has been saved on the database!");
        }

        private static void ListOfDestinationsAndCreationOfTraveler(AgencyModel dbConnection)
        {
            Console.WriteLine("____________________________________");
            Console.WriteLine("List of destinations:");
            Console.WriteLine("____________________________________");

            var destinations = dbConnection.Destination.ToList();
            for (int i = 0; i < destinations.Count; i++)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Destination Id: " + destinations[i].Id);
                Console.WriteLine("Country: " + destinations[i].Country);
                Console.WriteLine("City: " + destinations[i].City);
            }

            Console.WriteLine("");
            Console.WriteLine("Create a new Traveler!");

            var addTraveler = new Travelers();

            Console.WriteLine("Register a name: ");
            addTraveler.Name = Console.ReadLine();
            Console.WriteLine("Register an agency Id, available agency ID's 1,2 and 5: ");
            addTraveler.AgencyID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Choose the destination by id from the destination list above: ");
            addTraveler.DestinationID = Convert.ToInt32(Console.ReadLine());

            dbConnection.Travelers.Add(addTraveler);
            dbConnection.SaveChanges();
            Console.WriteLine("The information has been saved on the database!");

        }

        private static void ShowTravelers(AgencyModel dbConnection)
        { 
            Console.WriteLine("____________________________________");
            Console.WriteLine("List of travelers:");
            Console.WriteLine("____________________________________");
            var travelers = dbConnection.Travelers.ToList();
            for (int i = 0; i < travelers.Count; i++)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Traveler id: " + travelers[i].Id);
                Console.WriteLine("Name: " + travelers[i].Name);
                Console.WriteLine("Travels with AgencyId: " + travelers[i].AgencyID);
                Console.WriteLine("Destination Id: " + travelers[i].DestinationID);
            }
        }

        private static void ShowAgencies(AgencyModel dbConnection)
        {
            Console.Clear();
            Console.WriteLine("List of Agencies:");

            var agenecyies = dbConnection.Agency.ToList();
            for (int i = 0; i < agenecyies.Count; i++)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Agency Id: " + agenecyies[i].Id);
                Console.WriteLine("Agency Name: " + agenecyies[i].Name);
                Console.WriteLine("Email: " + agenecyies[i].eMail);

            }
        }
    }
}
