﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesLogic;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Car my_car = new Car("Ford", 50.7, 2000, "Natural petrol", "Gas", 200, 4);

            my_car.MovingVehicle();
            my_car.Faster(200);
           

            Airplane my_airplane = new Airplane("Boeing 737-400", 3000, 30000, "SuperJet", "high-octane petrol", 1500, 6, "white-blue");

            my_airplane.MovingVehicle();
            my_airplane.Faster(300);

            Console.WriteLine(my_airplane.ToString());

            Amphibian my_amphibian = new Amphibian("Amfibia Fireball", 50, 1500, 2000, "V6", 150, 4);
            my_amphibian.MovingVehicle();
            my_amphibian.Faster(195);
            my_amphibian.swimAmphibian();

            Console.WriteLine(my_amphibian.ToString());

            
            

            //creating list of Vehicles
            List<Vehicle> vehicles = new List<Vehicle>(3);

            //added vehicles to list
            vehicles.Add(my_car);
            vehicles.Add(my_airplane);
            vehicles.Add(my_amphibian);

            Console.WriteLine("Content of list before sorting:\n");

            for(int i= 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"Type: {vehicles[i].GetType().Name}\nName: {vehicles[i].Name}\nSpeed: {vehicles[i].Speed} km/h\n");
            }

            Console.WriteLine("-------------------------------\nContent of list after sorting:\n");

            vehicles.Sort();

            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"Type: {vehicles[i].GetType().Name}\nName: {vehicles[i].Name}\nSpeed: {vehicles[i].Speed} km/h\n");
            }

            Console.ReadKey();
        }
    }
}
