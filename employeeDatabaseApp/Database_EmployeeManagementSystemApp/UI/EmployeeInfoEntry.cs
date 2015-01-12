using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using Database_EmployeeManagementSystemApp.BLL;

namespace Database_EmployeeManagementSystemApp.UI
{
    public partial class EmployeeInfoEntry : Form
    {
        List<Employee> employees = new List<Employee>(); 
        public EmployeeInfoEntry(List<Employee> employeeEntry )
        {
            employees = employeeEntry;
            InitializeComponent();
        }
        string connectionString =  ConfigurationManager.ConnectionStrings["EmployeeInformationSystem"].ConnectionString;

        private void EmployeeInfoEntry_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string query = @"SELECT code,title FROM t_designation";
            SqlCommand command = new SqlCommand(query, connection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Employee anEmployee = new Employee();

                anEmployee.DesignationCode = reader["code"].ToString();
                anEmployee.Designationtitle = reader["title"].ToString();

                employees.Add(anEmployee);
            }

            reader.Close();
            connection.Close();

            designationComboBox.Items.Clear();
            foreach (Employee anEmployee in employees)
            {
                designationComboBox.Items.Add(anEmployee);
            }

            designationComboBox.DisplayMember = "designationtitle";
            designationComboBox.ValueMember = "designationCode";
        }


        private void Savebutton_Click(object sender, EventArgs e)
        {
          
            
            Employee anEmployee=new Employee();
            anEmployee.Name = nameText.Text;
            anEmployee.Email = emailText.Text;
            anEmployee.Address = addressText.Text;
            Employee selectedDesignation = (Employee)designationComboBox.SelectedItem;
            anEmployee.DesignationCode = selectedDesignation.DesignationCode;

            EmployeeManager anEmployeeManager= new EmployeeManager();
            string msg = anEmployeeManager.Save(anEmployee);
            MessageBox.Show(msg);
           
        }
    }
}
