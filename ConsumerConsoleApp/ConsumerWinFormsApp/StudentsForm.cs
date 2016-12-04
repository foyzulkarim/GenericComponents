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
using ApplicationLibrary.Models.Departments;
using ApplicationLibrary.Models.Students;
using Commons.Repository;
using Commons.Service;
using Commons.ViewModel;

namespace ConsumerWinFormsApp
{
    public partial class StudentsForm : Form
    {
        BaseService<Student, StudentRequestModel, StudentViewModel> studentService;
        BaseService<Department, DepartmentRequestModel, DepartmetnViewModel> departmentService;
        private StudentRequestModel studentRequestModel;
        
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
            student.DepartmentId = departmentComboBox.SelectedValue.ToString();
            studentService.Add(student);
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
            studentService = new BaseService<Student, StudentRequestModel, StudentViewModel>(studentRepository);
            studentRequestModel = new StudentRequestModel("");
            searchTextBox.DataBindings.Add("Text", studentRequestModel, "Keyword");
            var departmentRepository = new BaseRepository<Department>(dbContext);
            departmentService = new BaseService<Department, DepartmentRequestModel, DepartmetnViewModel>(departmentRepository);
            List<DropdownViewModel> departments = departmentService.GetDropdownListAsync(new DepartmentRequestModel());
            departmentComboBox.DataSource = departments;
            departmentComboBox.DisplayMember = "Text";
            departmentComboBox.ValueMember = "Id";
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
            var result = await studentService.SearchAsync(studentRequestModel);         
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result.Item1;            
        }
    }
}
