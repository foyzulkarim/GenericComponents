using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationLibrary.Factory;
using ApplicationLibrary.Models.Departments;
using ApplicationLibrary.Models.Students;
using Commons.Service;
using Commons.ViewModel;

namespace ConsumerWinFormsApp
{
    public partial class StudentsForm : Form, IGenericForm<Student, StudentRequestModel, StudentViewModel>
    {
        BaseService<Student, StudentRequestModel, StudentViewModel> service;
        BaseService<Department, DepartmentRequestModel, DepartmetnViewModel> departmentService;
        StudentRequestModel studentRequestModel;

        public StudentsForm()
        {
            InitializeComponent();
            Load += Form_Load;
            saveButton.Click += saveButton_Click;
            searchButton.Click += searchButton_Click;
        }

        public void Form_Load(object sender, EventArgs e)
        {
            Factory.CreateService(out service);
            Factory.CreateService(out departmentService);

            studentRequestModel = new StudentRequestModel("");
            searchTextBox.DataBindings.Add("Text", studentRequestModel, "Keyword");
            
            List<DropdownViewModel> departments = departmentService.GetDropdownListAsync(new DepartmentRequestModel());
            LoadDropdown(departments);
        }

        private void LoadDropdown(List<DropdownViewModel> departments)
        {
            departmentComboBox.DataSource = departments;
            departmentComboBox.DisplayMember = "Text";
            departmentComboBox.ValueMember = "Id";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var m = CreateModel();
            service.Add(m);
            MessageBox.Show("Saved");
            ClearForm();
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

        private void modelListTabPage_Enter(object sender, EventArgs e)
        {
            LoadGridView();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadGridView();
        }

        public async Task LoadGridView()
        {
            var result = await service.SearchAsync(studentRequestModel);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result.Item1;
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
