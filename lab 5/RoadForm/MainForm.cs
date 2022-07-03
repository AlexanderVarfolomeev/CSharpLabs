using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InputString;
using Lab5.Models;
using System.Reflection;

namespace Lab5.Main
{
    public partial class MainForm : Form
    {
        List<ViewObject> viewObjects;
        object viewObjectsLocker;

        List<ViewModel> viewModels;
        object viewModelsLocker;

        // рисователь всех объектов
        Painter painter;

        //здания на карте

        ViewObject hospital, gym;

        // спросмены
        List<Person> persons;
        object locker;

        // соревнования
        List<Competition> road;

        // соревнования будут только в в левой части экрана находится

        int maxCompetitionsNumber;

        IEnumerable<Type> doctorTypes;

        // будем хранить все уведомления, чтобы их постепенно очищать
        List<string> notifications;

        // картинки моделей
        // лучше сделать ссылки на них, так проще будет изменять код при изменении картинок
        Image personImage,
            ambulanceImage,
            autoserviceImage,
            peshehodImage,
            hospitalImage;

        public MainForm()
        {
            InitializeComponent();

            InitImages();

            viewObjects = new List<ViewObject>();
            viewObjectsLocker = new object();

            viewModels = new List<ViewModel>();
            viewModelsLocker = new object();

            persons = new List<Person>();
            locker = new object();

            doctorTypes = Assembly.Load("Lab5.Models").GetTypes()
                .Where(type => !type.IsAbstract && type.GetInterface("ICar") != null);

            notifications = new List<string>();

            maxCompetitionsNumber = (int)(pictureBox.Height / peshehodImage.Height);

            road = new List<Competition>();
        }

        void InitImages()
        {
            personImage = Properties.Resources.personPeshehod;
            ambulanceImage = Properties.Resources.Abmulance;
            autoserviceImage = Properties.Resources.Hospital;
            peshehodImage = Properties.Resources.peshehod;
            hospitalImage = Properties.Resources.Hospital;
        }

        void Notification(string message)
        {
            notificationTextBox.Invoke((MethodInvoker)delegate
            {
                notifications.Add(message);

                if (notifications.Count >= 15)
                {
                    // clear
                    notifications = notifications.GetRange(5, 9);

                    notificationTextBox.Text = "";

                    foreach (var item in notifications)
                    {
                        notificationTextBox.Text += item + "\r\n\r\n";
                    }
                }

                notificationTextBox.Text += message + "\r\n\r\n";
            });
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            painter.Stop();

            foreach (var item in road)
            {
                item.IsCanceled = true;
            }

            foreach (var item in viewModels)
            {
                if (item is ViewModel viewModel)
                    viewModel.Model.IsCanceled = true;
            }
        }

        void InputPersonModel(PersonModel personModel)
        {

            InputStringDialog inputLastName = new InputStringDialog(new WordValidator(), "Введите Фамилию");

            if (inputLastName.ShowDialog() == DialogResult.OK)
            {
                personModel.LastName = inputLastName.Value;
            }

            InputStringDialog inputFirstName = new InputStringDialog(new WordValidator(), "Введите Имя");

            if (inputFirstName.ShowDialog() == DialogResult.OK)
            {
                personModel.FirstName = inputFirstName.Value;
            }
        }

        private void addSportsmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person person = new Person(Notification, gym.X, gym.Y);

            InputPersonModel(person);

            // add to list and add to view

            lock(locker)
            {
                persons.Add(person);
            }

            lock(viewModels)
            {
                viewModels.Add(new ViewModel(person, personImage));
            }

            // запустим спросмена
            Task.Run(person.Start);
        }

        private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Type carType = typeof(Ambulance);

            SelectCarType selectDoctorType = new SelectCarType(doctorTypes);

            if (selectDoctorType.ShowDialog() == DialogResult.OK)
            {
                carType = selectDoctorType.SelectedType;
            }

            Car doctor = Activator.CreateInstance(carType,
                new object[] { (Action<string>)Notification, hospital.X, hospital.Y, persons, locker }) as Car;

            InputPersonModel(doctor);

            lock (viewModelsLocker)
            {
                viewModels.Add(new ViewModel(doctor, ambulanceImage));
            }

            Task.Run(doctor.Start);
        }

        void SetBuildingsSize()
        {
            hospital.X = pictureBox.Width - hospitalImage.Width / 2;
            hospital.Y = hospitalImage.Height / 2;


            gym.X = pictureBox.Width - autoserviceImage.Width / 2;
            gym.Y = pictureBox.Height - autoserviceImage.Height / 2;
        }

        void AddCompetition(string competitionName, int maxParticipatingSportmansNumber = 5)
        {
            float x = peshehodImage.Width / 2,
                y = peshehodImage.Height / 2;

            y += road.Count() * peshehodImage.Height;

            road.Add(new Competition(Notification, persons, locker, x, y, competitionName, maxParticipatingSportmansNumber));

            lock (viewObjectsLocker)
            {
                viewObjects.Add(new ViewObject(peshehodImage, x, y));
            }

            Task.Run(road[road.Count() - 1].Start);

            if (road.Count() >= maxCompetitionsNumber)
                addCompatitionToolStripMenuItem.Enabled = false;
        }

        void GenerateSportmans(int sportmansNumber)
        {
            // создадим несколько спорстменов, врачей, соревнование, запустим их в потоках

            for (int i = 0; i < sportmansNumber; i++)
            {
                var newSportsman = new Person(Notification, gym.X, gym.Y)
                {
                    LastName = "SpLast" + i.ToString(),
                    FirstName = "SpFirst" + i.ToString()
                };

                persons.Add(newSportsman);

                viewModels.Add(new ViewModel(newSportsman, personImage));

                Task.Run(newSportsman.Start);
            }
        }

        void GenerateDoctors(int doctorsNumber)
        {
            object[] doctorArgs = new object[]
           { (Action<string>)Notification,
                hospital.X,
                hospital.Y,
                persons,
                locker };

            for (int i = 0; i < doctorsNumber; i++)
            {
                foreach (var item in doctorTypes)
                {
                    Car newDoctor = Activator.CreateInstance(item, doctorArgs) as Car;
                    newDoctor.LastName = "DtLast" + i.ToString();
                    newDoctor.FirstName = "DtFirst" + i.ToString();

                    viewModels.Add(new ViewModel(newDoctor, ambulanceImage));

                    Task.Run(newDoctor.Start);
                }
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addSportsmanToolStripMenuItem.Enabled = true;
            addDoctorToolStripMenuItem.Enabled = true;
            startToolStripMenuItem.Enabled = false;
            addCompatitionToolStripMenuItem.Enabled = true;

            painter = new Painter(pictureBox, Color.FromArgb(128, 255, 128),
               new Font(notificationTextBox.Font.FontFamily, 10f, notificationTextBox.Font.Style),
               viewObjects, viewObjectsLocker, viewModels, viewModelsLocker);

            // create buildings

            hospital = new ViewObject(hospitalImage);
            gym = new ViewObject(autoserviceImage);

            SetBuildingsSize();

            // add hospital, stadium, gym
            viewObjects.Add(hospital);
            viewObjects.Add(gym);

            AddCompetition("Дорога 1");

            GenerateSportmans(8);

            GenerateDoctors(1);

            painter.Start();
        }

        private void addCompatitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputStringDialog inputCompettionName = new InputStringDialog(new WordValidator(), "Введите имя дороги");

            string name = "";

            if (inputCompettionName.ShowDialog() == DialogResult.OK)
                name = inputCompettionName.Value;

            InputStringDialog inputMaxParticipatingSportmansNumber = new InputStringDialog(new NotNegativeIntValidator(),
                "Введите максимальное количество людей  на пешеходе");

            if (inputMaxParticipatingSportmansNumber.ShowDialog() == DialogResult.OK)
                AddCompetition(name, Int32.Parse(inputMaxParticipatingSportmansNumber.Value));
            else
                AddCompetition(name);
        }
    }
}
