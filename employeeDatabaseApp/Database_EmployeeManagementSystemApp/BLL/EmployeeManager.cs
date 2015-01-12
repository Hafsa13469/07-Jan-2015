using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_EmployeeManagementSystemApp.DAL.DBGateways;

namespace Database_EmployeeManagementSystemApp.BLL
{
    class EmployeeManager
    {
        public string Save(Employee anEmployee)
        {
            const int MIN_LENGTH_OF_CODE = 3;
            EmployeeDBGateways anEmployeeDbGateways = new EmployeeDBGateways();
            if (anEmployee.Email.Length >= MIN_LENGTH_OF_CODE)
            {
                Employee anEmployeefound = anEmployeeDbGateways.Find(anEmployee.Email);
                if (anEmployeefound== null)
                {
                    anEmployeeDbGateways.Save(anEmployee);
                    return "Saved";
                }
                else
                {
                    return "This code doesn't exists";
                }
            }
            else
            {
                return "Code must be " + MIN_LENGTH_OF_CODE + " char long";
            }
        }
    }
}
