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
    public partial class EditForm : Form
    {
        DistanceStudent student = new DistanceStudent();
        public EditForm(IEnrollee enrollee)
        {
            InitializeComponent();
            if (enrollee is DistanceStudent)
            {
                student = enrollee as DistanceStudent;
                UpdateInfo();
            }
        }

        public void UpdateInfo()
        {
            nameBox.Text = student.Name;
            facultyBox.Text = student.Faculty;
            CouseBox.Text = student.Course.ToString();
            univercityBox.Text = student.University;
            mindBox.Text = student.Mind.ToString();
            lectureBox.Text = student.NumberOfLectures.ToString();
        }

        private void studyButton_Click(object sender, EventArgs e)
        {
            student.ToStudy();
            UpdateInfo();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            student.ToReadBook();
            UpdateInfo();
        }

        private void skipLecture_Click(object sender, EventArgs e)
        {
            student.SkipLesson();
            UpdateInfo();
        }

        private void goLecture_Click(object sender, EventArgs e)
        {
            student.GoToLesson();
            UpdateInfo();
        }

        private void infoButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = student.ToString();
        }

        private void mindButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = student.GetMind();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            student.Name = nameBox.Text;
            student.Faculty = facultyBox.Text;
            student.Course = Convert.ToInt32(CouseBox.Text);
            student.University = univercityBox.Text;
            student.Mind = Convert.ToInt32(mindBox.Text);
            student.NumberOfLectures = Convert.ToInt32(lectureBox.Text);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
