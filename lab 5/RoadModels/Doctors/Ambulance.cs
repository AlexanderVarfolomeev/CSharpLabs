using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public class Ambulance : Car
    {
        public Ambulance(Action<string> Notification, float defaultX, float defaultY, List<Person> persons, object locker)
            : base(Notification, defaultX, defaultY, persons, locker)
        {
            for (int i = 0; i < Disease.AllDisease.Length; i++)
                if (Disease.AllDisease[i].Contains("сердц"))
                    HealCar.Add(i);
        }
    }
}
