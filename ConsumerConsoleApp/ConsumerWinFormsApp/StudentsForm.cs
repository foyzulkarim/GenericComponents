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
        BaseService<Student, StudentRequestModel, StudentViewModel> service;
        private StudentRequestModel request;
        public StudentsForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            Student student = new Student();
            student.Name = nameTextBox.Text;
            student.Phone = phoneTextBox.Text;
            student.Id = Guid.NewGuid().ToString();
            student.Created = DateTime.Now;
            student.Modified = DateTime.Now;
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

        private void StudentsForm_Load(object sender, EventArgs e)
        {
            BusinessDbContext dbContext = new BusinessDbContext();
            BaseRepository<Student> studentRepository = new BaseRepository<Student>(dbContext);
            service = new BaseService<Student, StudentRequestModel, StudentViewModel>(studentRepository);
            request = new StudentRequestModel("");
            searchTextBox.DataBindings.Add("Text", request, "Keyword");
            
        }       

        private  void studentListTabPage_Enter(object sender, EventArgs e)
        {
             SearchStudents();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchStudents();
        }

        private async Task SearchStudents()
        {         
            var result = await service.SearchAsync(request);         
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result.Item1;            
        }
    }
}
