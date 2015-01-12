using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_EmployeeManagementSystemApp.DAL.DAO;

namespace Database_EmployeeManagementSystemApp.DAL.DBGateways
{
    internal class DBGateways
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["EmployeeInformationSystem"].ConnectionString;
          

        private SqlConnection aSqlConnection;
        private SqlCommand aSqlCommand;

        public DBGateways()
        {
            aSqlConnection = new SqlConnection(connectionString);
        }

        public void Save(Designation aDesignation)
        {
            string query = "INSERT INTO t_designation VALUES ('" + aDesignation.Code + "','" + aDesignation.Title
                           + "')";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            aSqlCommand.ExecuteNonQuery();
            aSqlConnection.Close();
        }
        

        public Designation Find(string code)
        {
            string query = "SELECT * FROM t_designation WHERE Code = '" + code + "'";
            aSqlConnection.Open();
            aSqlCommand = new SqlCommand(query, aSqlConnection);
            SqlDataReader aDataReader = aSqlCommand.ExecuteReader();
            Designation aDesignation;

            if (aDataReader.HasRows)
            {
                aDesignation = new Designation();
                aDataReader.Read();
                aDesignation.Id = Convert.ToInt32(aDataReader["id"]);
                aDesignation.Code = aDataReader["code"].ToString();
                aDesignation.Title = aDataReader["title"].ToString();
                aDataReader.Close();
                aSqlConnection.Close();
                return aDesignation;
            }
            else
            {
                aSqlConnection.Close();
                return null;
            }
        }
       
    }
}
