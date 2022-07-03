using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab5.Models
{
    public class Competition : Model
    {
        private readonly List<Person> persons;
        private readonly object personsLocker;

        List<Person> participatingPersons;

        string Name { get; }

        int maxParticipatingSportmansNumber;

        public Competition(Action<string> Notification, List<Person> persons, object personsLocker,
            float x, float y, string name, int maxParticipatingSportmansNumber = 5)
            : base(Notification)
        {
            this.persons = persons;
            this.personsLocker = personsLocker;
            X = x;
            Y = y;

            participatingPersons = new List<Person>();

            Name = name;

            this.maxParticipatingSportmansNumber = maxParticipatingSportmansNumber;
        }

        bool StartCompetition()
        {
            participatingPersons.Clear();

            lock (personsLocker)
            {
                int participatingSportsmansNumber = 0;

                for (int i = 0; i < persons.Count && participatingSportsmansNumber < maxParticipatingSportmansNumber; i++)
                {
                    if (!persons[i].IsLocked)
                    {
                        persons[i].ToX = X;
                        persons[i].ToY = Y;

                        persons[i].IsLocked = true;
                        participatingPersons.Add(persons[i]);

                        participatingSportsmansNumber++;
                    }
                }
            }

            return participatingPersons.Count != 0;
        }

        void WaitAllPersons()
        {
            bool allSportmansCame = false; ;

            while (!allSportmansCame)
            {
                Task.Delay(100).Wait();

                lock (personsLocker)
                {
                    allSportmansCame = participatingPersons.FirstOrDefault(item =>
                    !item.IsCome()) == null;
                }
            }
        }

        void DoCompetition()
        {
            Notification($"В движении {Name} примут участие {participatingPersons.Count} человек");
            WaitAllPersons();

            Notification($"Движение {Name} начинается");
            Notification($"Движение {Name} идёт");

            // видимость соревнования(типо сколько-то длится)
            Task.Delay(10 * 1000).Wait();
        }

        void PrintPersons(int place, Person person)
        {
            Notification($"{place} вышел на дорогу {person.LastName} {person.FirstName}");
        }

        int getNextPerson(Random random, int participatingNumber, List<int> personss)
        {
            int result;

            do
            {
                result = random.Next(0, participatingNumber);
            }
            while (personss.Contains(result));

            return result;
        }

        List<int> DeterminePersons()
        {
            List<int> list = new List<int>();

            if (participatingPersons.Count == 0)
                return list;

            Notification($"Человек {Name} выходит на дорогу:");
            Random random = new Random();

            int firstPerson = getNextPerson(random, participatingPersons.Count, list);
            list.Add(firstPerson);

            PrintPersons(1, participatingPersons[firstPerson]);


            if (participatingPersons.Count == 1)
                return list;

            int secondPerson = getNextPerson(random, participatingPersons.Count, list);
            list.Add(secondPerson);

            PrintPersons(2, participatingPersons[secondPerson]);

            if (participatingPersons.Count == 2)
                return list;
            // 3
            int thirdPerson = getNextPerson(random, participatingPersons.Count, list);
            list.Add(thirdPerson);

            PrintPersons(3, participatingPersons[thirdPerson]);

            return list;
        }

        void WaitHeal(List<Person> sickPersons)
        {
            bool allHeal = true;

            do
            {
                Task.Delay(100).Wait();

                allHeal = sickPersons.Count(sportsman => sportsman.IsIll) == 0;

            } while (!allHeal);
        }

        void PrintPersonss(List<Person> sickSPersons)
        {
            string message = "";

            foreach (var item in sickSPersons)
            {
                message += $"{item.LastName} {item.FirstName}: {Disease.AllDisease[item.DiseaseIndex]}\r\n";
            }

            Notification(message);
        }

        List<Person> DetermineSickPersons(List<int> winners)
        {
            List<Person> sickPersons = new List<Person>();

            Random random = new Random();

            for (int i = 0; i < participatingPersons.Count; i++)
                if (!winners.Contains(i))
                {
                    participatingPersons[i].RandomSick(random);

                    if (participatingPersons[i].IsIll)
                        sickPersons.Add(participatingPersons[i]);
                    else
                        participatingPersons[i].IsLocked = false;
                }

            return sickPersons;
        }

        public void EndRoad()
        {
            Notification($"Движение {Name} закончилось");

            List<int> items = DeterminePersons();

            Notification($"В движении учавствовали {Name}");

            Task.Delay(5000).Wait();

            Notification($"Движение {Name} закончен");


            foreach (var item in items)
            {
                participatingPersons[item].IsLocked = false;
            }


            Random random = new Random();

            List<Person> list = DetermineSickPersons(items);

            if (list.Count != 0)
            {
                Notification($"Во время движения {Name} люди получили травмы\n");

                PrintPersonss(list);
                Notification($"Пока все люди не выздоровят, движение {Name} не начнётся");
                WaitHeal(list);

                Notification($"Движение {Name}: Все люди вылечены!");
            }
        }

        public override void Start()
        {
            while (!IsCanceled)
            {
                Notification($"Скоро будет движение {Name}");

                Task.Delay(3 * 1000).Wait();

                if (!StartCompetition())
                {
                    Notification($"Люди не пришли на участие в движении {Name}, движение отменяется");
                }
                else
                {
                    DoCompetition();

                    EndRoad();   
                }

                Task.Delay(5 * 1000).Wait();
            }
        }
    }
}
