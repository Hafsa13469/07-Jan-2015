using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_EmployeeManagementSystemApp
{
    public partial class Search_modifyEmployee : Form
    {
        List<Employee> employees = new List<Employee>(); 
        public Search_modifyEmployee(List<Employee> searchEmployees )
        {
            employees = searchEmployees;
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }

        
    }
}
