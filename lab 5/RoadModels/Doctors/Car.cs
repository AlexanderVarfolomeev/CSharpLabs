using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public abstract class Car : PersonModel, ICar
    {
        private readonly List<Person> persons;
        private readonly object locker;

        Person _sickMan;

        public Car(Action<string> Notification, float defaultX, float defaultY, List<Person> persons, object locker)
            : base(Notification, defaultX, defaultY)
        {
            HealCar = new List<int>();

            this.persons = persons;
            this.locker = locker;
        }

        public List<int> HealCar { get; }

        void Heal()
        {
            if (IsCome())
            {
                Notification($"Машина аварийной службы {LastName} {FirstName} спасает человека " +
                        $"{_sickMan.LastName} {_sickMan.FirstName}");

                Task.Delay(5 * 1000).Wait();

                _sickMan.IsIll = false;
                _sickMan.IsLocked = false;

                Notification($"Человек {_sickMan.LastName} {_sickMan.FirstName} вылечен");

                DoSomething = null;
                IsLocked = false;

                ToX = defaultX;
                ToY = defaultY;
            }
        }

        protected override void CheckEvents()
        {
            if (IsLocked)
                return;

            lock(locker)
            {
                _sickMan = persons
                    .FirstOrDefault(sportsman => sportsman.IsIll &&
                    HealCar.Contains(sportsman.DiseaseIndex)
                    && !sportsman.WaitHeal);

                if (_sickMan != null)
                {
                    _sickMan.WaitHeal = true;
                    ToX = _sickMan.X;
                    ToY = _sickMan.Y;

                    IsLocked = true;
                    DoSomething = Heal;

                    Notification($"Машина аварийной службы {LastName} {FirstName} поехала лечить человека " +
                        $"{_sickMan.LastName} {_sickMan.FirstName}");
                }
            }
        }
    }
}
