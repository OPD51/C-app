using CarDB.Data;
using CarDB.Model;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarDB
{
    internal class App
    {
        CarDbDataContext dataContext;
        CarDbDataContext data = new CarDbDataContext();
        string userInput;

        public App()
        {
            dataContext = new CarDbDataContext();
            userInput = "";

            // Bco lazy loading is enabled, we need to explicitly load the related data
            dataContext.Drivers.ToList();
            dataContext.Cars.ToList();
        }
        internal void Run()
        {
            // TODO: Continuously show the menu, until userInput.ToLower() != "x"
            while (userInput.ToLower() != "x")
            {
                DisplayMenu();
            }
        }

        private void DisplayMenu()
        {
            // Show the menu, ask for input
            Console.WriteLine("1. List all drivers");
            Console.WriteLine("2. List all cars");
            Console.WriteLine("3. Add a driver");
            Console.WriteLine("4. Add a car");
            Console.WriteLine("5. Link a car to a driver");

            Console.WriteLine();
            Console.WriteLine("x. Exit");

            // TODO: Get the input

            userInput = Helpers.AskNotNull("maak uw keuze");
            
            // TODO: Process the input (call HandleUserInput)
            HandleUserInput();

        }

        private void HandleUserInput()
        {
           

            switch (userInput.ToLower())
            {
                case "1":
                    ListAllDrivers();
                    break;
                case "2":
                    ListAllCars(); 
                    break;
                case "3":
                    AddDriver(); 
                    break;
                case "4":
                    AddCar();
                    break;
                case "5":
                    LinkCarToDriver();
                    break;
                case "x":
                    break;
                default:
                    Console.WriteLine("Ongeldige keuze");
                    break;
            }
            Helpers.Wait();
        }


        private void AddCar()
        {
            // TODO: Ask for the details of the new car (use Helpers.Ask / Helpers.AskForInt / Helpers.AskNotNull)
            string Model = Helpers.AskNotNull("voer het model in");
            string Brand = Helpers.AskNotNull("voer het merk in");
            string LicensePlate = Helpers.AskNotNull("voer kenteken nummer in");
            string Color = Helpers.AskNotNull("voer kleur in");
            // TODO: Create a new car
            Car car = new Car(Brand, Model, LicensePlate, Color);

            // TODO: Ask if the user wants to link the car to an (existing) driver (use Helpers)
            string question = Helpers.Ask("wilt u het koppelen aan een bestaande bestuurder");

            // TODO: If yes, use SelectDriver to get the driver
            if( question == "y" )
            // TODO: Then use LinkCarToDriver to link the car to the driver (use LinkCarToDriver)
            {
                LinkCarToDriver();
            }
            // TODO: Add the car to the context
            data.Cars.Add(car);
            data.SaveChanges();

            Console.WriteLine("Something was added.");
            // TODO: Save the changes

        }

        private void AddDriver()
        {

            // TODO: Ask for the details of the new driver (use Helpers.Ask / Helpers.AskForInt / Helpers.AskNotNull)
            string Name = Helpers.AskNotNull("Voer naam in");
            // TODO: Create a new driver
            Driver driver = new Driver(Name);
            // TODO: Ask if the user wants to link the driver to an (existing) car (use Helpers)
            string question = Helpers.Ask("wil je de driver linken aan bestaande auto Y/N");
            // TODO: If yes, use SelectCar to get the car
            if(question == "Y")
            {
            // TODO: Then use LinkDriverToCar to link the driver to the car (use LinkCarToDriver)
                LinkCarToDriver();
            }


            // TODO: Add the driver to the context
            data.Drivers.Add(driver);
            data.SaveChanges();
            // TODO: Save the changes

        }

        private void ListAllCars()
        {
            // TODO: Finish the method ListAllCars
            Console.WriteLine("================ All cars ================");

            // TODO: Get all object using
            // List<Object> objects = dataContext.Objects.ToList();
            List<Car> cars = dataContext.Cars.ToList();

            // TODO: Rewrite Object, o and objects to the correct type and name
            foreach (Car car in cars)
            {
                Console.WriteLine(car.Model);
                Console.WriteLine(car.Brand);
                Console.WriteLine(car.LicensePlate);
                Console.WriteLine(car.Id);
                Console.WriteLine(car.Color);
            }
            Console.WriteLine("=============================================");
        }

        private void ListAllDrivers()
        {
            // TODO: Finish the method ListAllDrivers
            // TODO: Finish the method ListAllCars
            Console.WriteLine("================ All Drivers ================");

            // TODO: Get all object using
            // List<Object> objects = dataContext.Objects.ToList();
            List<Driver> drivers = dataContext.Drivers.ToList();

            // TODO: Rewrite Object, o and objects to the correct type and name
            foreach (Driver driver in drivers)
            {
                Console.WriteLine(driver.Name);
                Console.WriteLine(driver.Id);
            }
            Console.WriteLine("=============================================");
        }

        private Driver SelectDriver()
        {
            // TODO: Finish the method SelectDriver
            // Note: This method must return a Driver object, it may not return null
            ListAllDrivers();
            int selectedDriverId;
            Driver? selecteddriver = null;

            do
            {
                selectedDriverId = Helpers.AskInt("Enter ID of driver");
                // TODO: Find theselected object:
                // selectedObject = dataContext.Objects.Find(selectedObjectId);
                selecteddriver = dataContext.Drivers.Find(selectedDriverId);


            }
            while (selecteddriver == null);

            return selecteddriver;
        }

        private Car SelectCar()
        {
            // TODO: Show all cars. Check SelectDriver for inspiration
            // Note: This method must return a Car object, it may not return null
            ListAllCars();
            int selectedCarId;
            Car? selectedcar = null;

            do
            {
                selectedCarId = Helpers.AskInt("Enter ID of car");
                // TODO: Find theselected object:
                // selectedObject = dataContext.Objects.Find(selectedObjectId);
                selectedcar = dataContext.Cars.Find(selectedCarId);


            }
            while (selectedcar == null);

            return selectedcar;
        }

        private void LinkCarToDriver(Car car, Driver driver)
        {
            driver.Cars.Add(car);
            dataContext.SaveChanges();
        }

        private void LinkCarToDriver(Driver driver)
        {
            Driver driverId = driver;
            Car car = SelectCar();

            LinkCarToDriver(car, driver);
            
        }

        private void LinkCarToDriver()
        {
            Car car = SelectCar();
            Driver driver = SelectDriver();

            LinkCarToDriver(car, driver);

        }

    }
}