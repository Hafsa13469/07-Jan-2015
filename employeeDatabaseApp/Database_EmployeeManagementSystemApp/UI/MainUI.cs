using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Database_EmployeeManagementSystemApp.UI
{  
    public partial class MainUI : Form
    {List<Employee> employees=new List<Employee>(); 
        public MainUI()
        {
            InitializeComponent();
        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            EmployeeInfoEntry fEmployeeEntry=new EmployeeInfoEntry(employees);
            fEmployeeEntry.Show();
        }

        private void AddDesignationButton_Click(object sender, EventArgs e)
        {
           Add_Designation fDesignation=new Add_Designation(employees);
            fDesignation.Show();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            Search_modifyEmployee fSearchModifyEmployee=new Search_modifyEmployee(employees);
            fSearchModifyEmployee.Show();
        }
    }
}
