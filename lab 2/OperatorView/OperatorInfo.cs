using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OperatorModel;

namespace OperatorView
{
    public partial class OperatorInfo : Form
    {
        private Operator op;
        private OperatorChild ch;
        public OperatorInfo(Operator op, OperatorChild ch)
        {
            this.op = op;
            this.ch = ch;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = op.Quality().ToString();
            textBox2.Text = ch.Quality().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Text = op.ToString();
            textBox4.Text = ch.ToString();
        }

        private void OperatorInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
