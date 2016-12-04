using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumerWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void studentsButton_Click(object sender, EventArgs e)
        {
            StudentsForm form = new StudentsForm();
            form.ShowDialog(this);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void departmentsButton_Click(object sender, EventArgs e)
        {
            DepartmentForm form = new DepartmentForm();
            form.ShowDialog(this);
        }
    }
}
