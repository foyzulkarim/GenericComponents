using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationLibrary;
using ApplicationLibrary.Models.Students;
using Commons.Repository;
using Commons.Service;

namespace ConsumerWinFormsApp
{
    public partial class StudentsForm : Form
    {
        
        public StudentsForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            BaseRepository<Student> repository=new BaseRepository<Student>(new BusinessDbContext());
            BaseService<Student,StudentRequestModel,StudentViewModel> service  =new BaseService<Student, StudentRequestModel, StudentViewModel>(repository);
            Student student=new Student();
            student.Name = nameTextBox.Text;
            student.Phone = phoneTextBox.Text;
            student.Id=Guid.NewGuid().ToString();
            student.Created=DateTime.Now;
            student.Modified=DateTime.Now;
            student.CreatedBy = "me";
            student.ModifiedBy = "me";
            service.Add(student);
            MessageBox.Show("Saved");
            ClearForm();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            nameTextBox.Clear();
            phoneTextBox.Clear();
        }
    }
}
