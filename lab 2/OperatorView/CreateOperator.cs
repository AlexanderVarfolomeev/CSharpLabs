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
    public partial class CreateOperator : Form
    {
        public CreateOperator()
        {
            InitializeComponent();
        }

        private void CreateOperatorButton_Click(object sender, EventArgs e)
        {
            double d = Convert.ToDouble(AreaOp.Text);
            decimal ee = Convert.ToDecimal(PriceOp.Text);
            Operator op = new Operator(
                NameOp.Text,
                Convert.ToDecimal(PriceOp.Text),
                Convert.ToDouble(AreaOp.Text));

            OperatorChild childOp = new OperatorChild(
                NameCh.Text,
                Convert.ToDecimal(PriceCh.Text),
                Convert.ToDouble(AreaCh.Text),
                PayCh.SelectedIndex == 0 ? true : false
                );
            OperatorInfo form = new OperatorInfo(op, childOp);
            this.Hide();
            form.ShowDialog();
        }
    }
}
