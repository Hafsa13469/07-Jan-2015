using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_EmployeeManagementSystemApp.DAL.DBGateways
{
    class EmployeeDBGateways
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EmployeeInformationSystem"].ConnectionString;
           

        private SqlConnection aSqlConnection;
        private SqlCommand aSqlCommand;
         public EmployeeDBGateways()
        {
            aSqlConnection = new SqlConnection(connectionString);
        }
        public void Save(Employee anEmployee)
        {
            string query = "INSERT INTO t_Employees(name,email,address,desg_code) VALUES('" + anEmployee.Name + "','" + anEmployee.Email + "','" + anEmployee.Address + "','" + anEmployee.DesignationCode + "')";
            
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
        }
        public Employee Find(string Email)
        {
            string query = "SELECT * FROM t_Employees WHERE email = '" +Email + "'";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
            Employee anEmployee;

            if (aDataReader.HasRows)
            {
                anEmployee = new Employee();
                aDataReader.Read();
                anEmployee.Name = aDataReader["name"].ToString();
                anEmployee.DesignationCode = aDataReader["desg_code"].ToString();
                anEmployee.Address = aDataReader["address"].ToString();
                anEmployee.Email = aDataReader["email"].ToString();
                aDataReader.Close();
                aSqlConnection.Close();
                return anEmployee;
            }
            else
            {
                aSqlConnection.Close();
                return null;
            }
        }
    }
}
