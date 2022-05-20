using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarModel;

namespace CarView
{
    public partial class CarForm : Form
    {
        private Car car;
        public CarForm(Car tmp)
        {
            InitializeComponent();
            car = tmp;
        }

        private void CarForm_Load(object sender, EventArgs e)
        {
           Update();
        }

        private void DriveButton_Click(object sender, EventArgs e)
        {
            double distance = car.Drive();
            Update();

            if (distance != 0)
            {
                Report.Text = $"Проехали {distance} км.";
            }
            else
                Report.Text = "Не смогли поехать из за неполадок!";
        }

        private void Update()
        {
            brandLabel.Text = car.Brand;
            Wheel1CondLabel.Text = car.Wheels[0].Condition.ToString();
            Wheel2CondLabel.Text = car.Wheels[1].Condition.ToString();
            Wheel3CondLabel.Text = car.Wheels[2].Condition.ToString();
            Wheel4CondLabel.Text = car.Wheels[3].Condition.ToString();

            EngCondLabel.Text = car.Eng.Condition.ToString();
            FuelLabel.Text = car.MaxFuel.ToString();
            RealFuelLabel.Text = car.Fuel.ToString();
        }

        private void Refuel_Click(object sender, EventArgs e)
        {
            if (car.Fuel == car.MaxFuel)
                Report.Text = "Бак полон!";
            else
            {
                car.Refuel();
                Report.Text = "Заливаем. . .";
                Update();
            }
        }

        private void Change1_Click(object sender, EventArgs e)
        {
            car.ChangeWheel(0);
            Update();
            Report.Text = "Поменяли первое колесо.";
        }

        private void Change2_Click(object sender, EventArgs e)
        {
            car.ChangeWheel(1);
            Update();
            Report.Text = "Поменяли второе колесо.";
        }

        private void Change3_Click(object sender, EventArgs e)
        {
            car.ChangeWheel(2);
            Update();
            Report.Text = "Поменяли третье колесо.";
        }

        private void Change4_Click(object sender, EventArgs e)
        {
            car.ChangeWheel(3);
            Update();
            Report.Text = "Поменяли четвертое колесо.";
        }

        private void EngRepair_Click(object sender, EventArgs e)
        {
            car.RepairEngine();
            Update();
            Report.Text = "Починили двигатель.";
        }

        private void FuelLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report.Text = "Марка вашей машина " + car.ToString();
        }
    }
}
