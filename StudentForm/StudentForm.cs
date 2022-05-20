using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentModel;

namespace StudentForm
{
    public partial class StudentForm : Form
    {
        public List<IEnrollee> enrollerList = new List<IEnrollee>();
        public StudentForm()
        {
            InitializeComponent();
        }


        private void studentList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (studentList.SelectedIndex != -1)
            {
                int selectedStudent = studentList.SelectedIndex;
                EditForm editForm = new EditForm(enrollerList[selectedStudent]);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    studentList.Items.RemoveAt(selectedStudent);
                    studentList.Items.Insert(selectedStudent, enrollerList[selectedStudent]);
                }
            }
        }
        private void studentList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            IEnrollee newStudent = new DistanceStudent();
            EditForm editForm = new EditForm(newStudent);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                enrollerList.Add(newStudent);
                studentList.Items.Add(newStudent);
            }

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (studentList.SelectedIndex != -1)
            {
                int selectedStudent = studentList.SelectedIndex;
                enrollerList.RemoveAt(selectedStudent);
                studentList.Items.RemoveAt(selectedStudent);
            }
        }
    }
}
