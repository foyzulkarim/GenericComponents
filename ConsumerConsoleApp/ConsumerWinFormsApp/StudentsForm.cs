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
            BaseRepository<Student> repository = new BaseRepository<Student>(new BusinessDbContext());
            service = new BaseService<Student, StudentRequestModel, StudentViewModel>(repository);
            request = new StudentRequestModel("");
            searchButton.DataBindings.Add("Text", request, "Keyword");
            ReloadStudents();
        }

        private async void ReloadStudents()
        {
            var studentViewModels = await service.GetAllAsync();
            var list = studentViewModels.Select(x => new { x.Name, x.Phone, x.Modified }).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }

        private void studentListTabPage_Enter(object sender, EventArgs e)
        {
            ReloadStudents();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchStudents();
        }

        private async void SearchStudents()
        {
            // we will refactor it.
            var result = await service.SearchAsync(request);
            var list = result.Item1.Select(x => new { x.Name, x.Phone, x.Modified }).ToList();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;
        }
    }
}
