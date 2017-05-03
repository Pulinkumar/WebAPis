using Splendent.MVCReactJS.Models.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using Splendent.Framework.ServiceAgent.Rest;

namespace Splendent.MVCReactJS.Services.RestClients
{
    public interface IEmployeeClient
    {

        [RestOperation(Resource = @"api/employee/testEmployeeApi", Verb = Method.GET)]
        Task<string> TestEmployeeApiAsync();

        [RestOperation(Resource = @"api/employee/getemployees", Verb = Method.GET)]
        Task<List<EmployeeModel>> GetEmployeesAsync();
    }
}
