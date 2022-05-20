using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarModel
{
    public class Car
    {
        public string Brand { get; set; }

        public double Fuel { get; set; }

        public double MaxFuel { get; set; }

        public Wheel[] Wheels { get; set; }
        public Engine Eng { get; set; }

        public Car()
        {
            Wheels = new Wheel[4];
            Eng = new Engine();
            Brand = "Empty";
            MaxFuel = 0;
            Fuel = 0;
        }

        public Car(string brand, double fuel, double diameter, double power)
        {
            Brand = brand;
            Fuel = fuel;
            MaxFuel = fuel;
            Wheels = new Wheel[4];
            for (int i = 0; i < 4; i++)
            {
                Wheels[i] = new Wheel(diameter);
            }
            Eng = new Engine(power);
        }

        /// <summary>
        /// Метод езды.
        /// Возвращает длину преодоленного пути.
        /// Если вернул 0, значит есть неполадки в машине.
        /// Ухудшает состояние двигателя и колес.
        /// </summary>
        public double Drive()
        {
            Random rnd = new Random();

            for (int i = 0; i < 4; i++)
            {
                if (Wheels[i].Condition <= 0)
                    return 0;
            }

            if (Eng.Condition <= 0 || Fuel <= 0)
                return 0;

            Eng.Condition -= rnd.Next(5, 25);
            if (Eng.Condition < 0)
                Eng.Condition = 0;


            for (int i = 0; i < 4; i++)
            {
                Wheels[i].Condition -= rnd.Next(5, 25);
                if (Wheels[i].Condition < 0)
                    Wheels[i].Condition = 0;
            }

            Fuel -= rnd.Next(1, 5) * Eng.Power * 0.01;

            return Eng.Power * Wheels[0].Diameter * Eng.Condition * 0.0001;
        }

        public void Refuel() => Fuel = MaxFuel;

        public void ChangeWheel(int wheel) => Wheels[wheel].Condition = 100;
        public void RepairEngine() => Eng.Condition = 100;

        public override string ToString()
        {
            return Brand;
        }
    }

    public class Wheel
    {
        public int Condition { get; set; }
        public double Diameter { get; set; }

        public Wheel()
        {
            Condition = 0;
            Diameter = 0;
        }

        public Wheel(double diameter)
        {
            Condition = 100;
            Diameter = diameter;
        }
    }

    public class Engine
    {
        public int Condition { get; set; }
        public double Power { get; set; }

        public Engine()
        {
            Condition = 0;
            Power = 0;
        }

        public Engine(double power)
        {
            Condition = 100;
            Power = power;
        }
    }
}
