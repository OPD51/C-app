using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Model
{
    internal class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }

        public Driver(string Name)
        {
            this.Name = Name;

            Cars = new List<Car>();
        }

        public override string ToString()
        {
            // return the details of this driver, including a list of cars
            string retVal = $"{Name} has {Cars.Count} cars:\n";
            foreach (Car car in Cars)
            {
                retVal += $"\t{car}\n";
            }
            return retVal;
        }
    }
}
