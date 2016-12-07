using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationLibrary.Models.Departments;
using ApplicationLibrary.Models.Students;
using Commons.Utility;
using Commons.ViewModel;

namespace ConsumerWinFormsApp
{
    public partial class DepartmentForm : Form, IGenericForm<Department>
    {
        DepartmentRequestModel requestModel;

        public DepartmentForm()
        {
            InitializeComponent();
            Load += Form_Load;
            saveButton.Click += saveButton_Click;
            searchButton.Click += searchButton_Click;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            requestModel = new DepartmentRequestModel("");
            searchTextBox.DataBindings.Add("Text", requestModel, "Keyword");
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var m = CreateModel();
                App.DepartmentService.Add(m);
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
        
        public Department CreateModel()
        {
            Department model = new Department()
            {
                Name = nameTextBox.Text
            };
            model.SetCommonValues();
            return model;
        }

        public void ClearForm()
        {
            nameTextBox.Clear();
        }

        public async Task LoadGridView()
        {
            Tuple<List<DepartmetnViewModel>, int> result = await App.DepartmentService.SearchAsync(requestModel);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = result.Item1.OfType<object>().ToList().ConvertToViewableDynamicList();            
        }  
    }
}
