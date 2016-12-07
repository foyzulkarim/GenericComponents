using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationLibrary.Models.Departments;
using ApplicationLibrary.Models.Students;
using Commons.Model;
using Commons.Service;
using Commons.Utility;
using Commons.ViewModel;
using Newtonsoft.Json;

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
            try
            {
                var m = CreateModel();
                App.StudentService.Add(m);
                MessageBox.Show("Saved");
                ClearForm();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error Occurred");
            }
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
            List<object> objects = result.Item1.OfType<object>().ToList();
            dataGridView1.DataSource = objects.ConvertToViewableDynamicList();
        }

        public void LoadDropdown()
        {
            departmentComboBox.DataSource = App.DepartmentService.GetDropdownListAsync(new DepartmentRequestModel());
        }

        public Student CreateModel()
        {
            Student model = new Student
            {
                Name = nameTextBox.Text,
                Phone = phoneTextBox.Text,
                DepartmentId = departmentComboBox.SelectedValue.ToString(),
            };
            model.SetCommonValues();
            return model;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value == "Delete")
            {
                bool confirmDelete = ShowDeleteAlert();
                if (confirmDelete)
                {
                    var id = dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                    bool deleted = App.StudentService.Delete(id);
                    LoadGridView();
                    MessageBox.Show(this, "Deleted", "Successful", MessageBoxButtons.OK);
                }
            }
        }

        private bool ShowDeleteAlert()
        {
            var result = MessageBox.Show(this, "Delete this?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }
    }
}
