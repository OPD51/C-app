using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Model
{
    internal class Car
    {
        public int Id { get; set; }
        public List<Brand> Brands { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public string Color { get; set; }

        public Car(string Brand, string Model, string LicensePlate, string Color)
        {
            this.Brands = new List<Brand>();

            this.Model = Model;
            this.LicensePlate = LicensePlate;
            this.Color = Color;
        }

        public override string ToString()
        {
            // Return a string representation of the car.
            return $"{Brands} {Model} ({LicensePlate}) in {Color}";
        }
    }
}
