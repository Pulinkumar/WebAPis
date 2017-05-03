using Splendent.MVCReactJS.Models.Employee;
using Splendent.MVCReactJS.Services.RestClients;
using Splendent.MVCReactJS.UIServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splendent.MVCReactJS.UIServices.Employee
{
    public class EmployeeUiService : IEmployeeUiService
    {
        private readonly IEmployeeClient _employeeClient;
        public EmployeeUiService(IEmployeeClient employeeClient)
        {
            _employeeClient = employeeClient;
        }

        public async Task<string> TestEmpApi()
        {
            return await _employeeClient.TestEmployeeApiAsync();
        }

        public async Task<List<EmployeeModel>> GetEmployees()
        {
            return await _employeeClient.GetEmployeesAsync();
        }
    }
}
