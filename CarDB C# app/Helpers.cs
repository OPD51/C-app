using CarDB.Data;
using CarDB.Model;
using System.Diagnostics;


namespace CarDB
{
    internal class Helpers
    {
        public static string? Ask(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static string AskNotNull(string question)
        {
            string? retVal = null;
            do
            {
                retVal = Ask(question);
            }
            while (retVal == null);

            return retVal;
        }
        internal static int AskInt(string question)
        {
            bool isInt = false;
            int result = 0;
            while (!isInt)
            {
                string? userInput = Ask(question);
                isInt = int.TryParse(userInput, out result);

                if (isInt)
                {
                    Debug.WriteLine("Parsen gelukt!");
                }
                else
                {
                    Debug.WriteLine("Parsen niet gelukt!");
                }
            }

            return result;
        }

        internal static void InsertTestData()
        {
            using (CarDbDataContext context = new CarDbDataContext())
            {
                // Only insert if there are no drivers in the db yet
                if (context.Drivers.Count() > 0)
                {
                    return;
                }

                Console.WriteLine("Inserting test data...");

                // Create three drivers
                Driver driver1 = new Driver("Jan");
                Driver driver2 = new Driver("Piet");
                Driver driver3 = new Driver("Mohammed");

                // Create five cars
                Car car1 = new Car("Ford", "Fiesta", "AB-01-CD", "Red");
                Car car2 = new Car("Ford", "Focus", "AB-02-CD", "Blue");
                Car car3 = new Car("Ford", "Mondeo", "AB-03-CD", "Green");
                Car car4 = new Car("Ford", "Mustang", "AB-04-CD", "Yellow");
                Car car5 = new Car("Ford", "GT", "AB-05-CD", "Black");

                // Link the cars to the drivers
                driver1.Cars.Add(car1);
                driver1.Cars.Add(car2);
                driver2.Cars.Add(car3);
                driver2.Cars.Add(car4);
                driver3.Cars.Add(car5);

                // Add drivers to context
                context.Drivers.Add(driver1);
                context.Drivers.Add(driver2);
                context.Drivers.Add(driver3);

                // Save changes
                context.SaveChanges();

                Console.WriteLine("Test data inserted!");
                Console.WriteLine("App has to be restarted.");

                Wait();

                Environment.Exit(0);
            }
        }

        internal static void Wait()
        {
            Console.WriteLine("Press <ENTER> to continue...");
            Console.ReadLine();
        }
    }
}
