using fmkafkds;
using System;
using System.Collections.Generic;
using System.Linq;

namespace fmkafkds
{
    public  class Car
    {
        public string Color { get; set; }
        public double FuelAmount { get; set; }
        public double LoadCapacity { get; set; }
        public List<Tuple<int, double>> FuelTable { get; set; }
        public string FuelType { get; set; }

        public double abc(double speed, double weight, double distance)
        {
            double baseConsumption = 0;
            foreach (var entry in FuelTable)
            {
                if (speed <= entry.Item1)
                {
                    baseConsumption = entry.Item2;
                    break;
                }
            }

            double a = 0.0;
            if (FuelType == "легковой")
            {
                a = weight * 0.05;
            }
            else if (FuelType == "грузовой")
            {
                a = weight * 0.1;
            }

            double totalA = baseConsumption + a;
            return totalA * distance;
        }
        public static List<Car> FilterCars(List<Car> cars, string color = null, string fuelType = null)
        {
            return cars.Where(car =>
                (color == null || car.Color == color) &&
                (fuelType == null || car.FuelType == fuelType)).ToList();
        }
        public static List<Car> LoadCars(string filePath)
        {
            var j = File.ReadAllText(filePath);
            var cars = Convert.ChangeType(j, typeof(Car));
            return cars;
        }
        public class Cargo
        {

            public string Name { get; set; }//груз1,200 
            public double Weight { get; set; }//груз2,300
            public static List<Cargo> LoadCargo(string filePath)
            {
                var j = File.ReadAllText(filePath);
                var cago = Convert.ChangeType(j, typeof(Cargo));
                return cago;
            }
            public static bool CanOrNo(List<Car> cars, List<Cargo> cargo, double distance)
            {
                double totalCargoWeight = cargo.Sum(item => item.Weight);
                foreach (var car in cars)
                {
                    if (car.LoadCapacity >= totalCargoWeight)
                    {
                        var fuelNeeded = car.abc(80, totalCargoWeight, distance); 
                        if (fuelNeeded <= car.FuelAmount)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
