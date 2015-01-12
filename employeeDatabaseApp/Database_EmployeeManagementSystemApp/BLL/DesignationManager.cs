using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_EmployeeManagementSystemApp.DAL.DAO;
using Database_EmployeeManagementSystemApp.DAL.DBGateways;

namespace Database_EmployeeManagementSystemApp.BLL
{
    class DesignationManager
    {
        const int MIN_LENGTH_OF_CODE = 3;
        public string Save(Designation aDesignation)
        {
           DBGateways aDesignationDBGateway = new DBGateways();
            if (aDesignation.Code.Length >= MIN_LENGTH_OF_CODE)
            {
                Designation designationFound = aDesignationDBGateway.Find(aDesignation.Code);
                if (designationFound == null)
                {
                    aDesignationDBGateway.Save(aDesignation);
                    return "Saved";
                }
                else
                {
                    return "This code already exists";
                }
            }
            else
            {
                return "Code must be " + MIN_LENGTH_OF_CODE + " char long";
            }
        }
       
    }
}
