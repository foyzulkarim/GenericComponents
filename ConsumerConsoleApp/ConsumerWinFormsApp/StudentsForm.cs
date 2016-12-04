using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationLibrary.Models.Departments;
using ApplicationLibrary.Models.Students;
using Commons.Service;
using Commons.ViewModel;

namespace ConsumerWinFormsApp
{
    public partial class StudentsForm : Form, IGenericForm<Student>
    {
        StudentRequestModel studentRequestModel;

        public StudentsForm()
        {
            InitializeComponent();

            Load += Form_Load;
            saveButton.Click += saveButton_Click;
            searchButton.Click += searchButton_Click;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            studentRequestModel = new StudentRequestModel("");
            searchTextBox.DataBindings.Add("Text", studentRequestModel, "Keyword");
            List<DropdownViewModel> departments = App.DepartmentService.GetDropdownListAsync(new DepartmentRequestModel());
            LoadDropdown(departments);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var m = CreateModel();
            App.StudentService.Add(m);
            MessageBox.Show("Saved");
            ClearForm();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void modelListTabPage_Enter(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void LoadDropdown(List<DropdownViewModel> departments)
        {
            departmentComboBox.DataSource = departments;
            departmentComboBox.DisplayMember = "Text";
            departmentComboBox.ValueMember = "Id";
        }
        
        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        public void ClearForm()
        {
            nameTextBox.Clear();
            phoneTextBox.Clear();
        }
        
        public async Task LoadGridView()
        {
            var result = await App.StudentService.SearchAsync(studentRequestModel);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result.Item1;
        }

        public void LoadDropdown()
        {
            departmentComboBox.DataSource = App.DepartmentService.GetDropdownListAsync(new DepartmentRequestModel());
        }
        
        public Student CreateModel()
        {
            Student student = new Student
            {
                Name = nameTextBox.Text,
                Phone = phoneTextBox.Text,
                DepartmentId = departmentComboBox.SelectedValue.ToString()
            };
            student.SetCommonValues();
            return student;
        }       
    }
}
