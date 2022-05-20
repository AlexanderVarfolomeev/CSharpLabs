using System;
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
    public partial class CreateCarForm : Form
    {
        public CreateCarForm()
        {
            InitializeComponent();
        }

        private void CarForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double fuel = Convert.ToDouble(textBox4.Text);
            string brand = textBox1.Text;
            double diam = Convert.ToDouble(textBox2.Text);
            double power = Convert.ToDouble(textBox3.Text);

            Car car = new Car(brand, fuel, diam, power);
            CarForm form = new CarForm(car);
            this.Hide();
            form.ShowDialog();
        }
    }
}
