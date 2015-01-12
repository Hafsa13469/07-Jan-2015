using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Database_EmployeeManagementSystemApp.BLL;
using Database_EmployeeManagementSystemApp.DAL.DAO;

namespace Database_EmployeeManagementSystemApp.UI
{
    public partial class Add_Designation : Form
    {
        private List<Employee> employees = new List<Employee>();

        public Add_Designation(List<Employee> designationEmployees)
        {
            employees = designationEmployees;
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {



            //string code = codeText.Text;
            //string title = titlteText.Text;


            Designation aDesignation = new Designation();
            aDesignation.Code = codeText.Text;
            aDesignation.Title = titlteText.Text;
            DesignationManager aDesignationManager = new DesignationManager();
            string msg = aDesignationManager.Save(aDesignation);
            MessageBox.Show(msg);
        }
    }
}
