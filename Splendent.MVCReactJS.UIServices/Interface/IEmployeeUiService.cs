using Splendent.MVCReactJS.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splendent.MVCReactJS.UIServices.Interface
{
    public interface IEmployeeUiService
    {
        Task<string> TestEmpApi();

        Task<List<EmployeeModel>> GetEmployees();
    }
}
