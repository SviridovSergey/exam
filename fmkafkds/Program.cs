using fmkafkds;
using System;
using System.IO;
namespace exam
{
    internal class Program
    {
        static void main(string[] args)
        {
            Car cars = Car.LoadCars("cars.json");
            var cargo = Cargo.LoadCargo("cargo.json");

            Console.WriteLine("Введите желаемый цвет машины (или оставьте пустым для любого): ");
            string color = Console.ReadLine();

            Console.WriteLine("Введите желаемый тип расхода (или оставьте пустым для любого): ");
            string fuelType = Console.ReadLine();

            Console.WriteLine("Введите расстояние для перевозки (в км): ");
            double distance = double.Parse(Console.ReadLine());

            var filteredCars = FilterCars(cars, string.IsNullOrWhiteSpace(color) ? null : color, string.IsNullOrWhiteSpace(fuelType) ? null : fuelType);

            bool canTransportFlag = CanOrNo(filteredCars, cargo, distance);

            if (canTransportFlag)
            {
                Console.WriteLine($"Возможно перевезти весь груз.");
            }
            else
            {
                Console.WriteLine("Ни одна машина не может перевезти весь груз на заданное расстояние.");
            }
        }
    }
}