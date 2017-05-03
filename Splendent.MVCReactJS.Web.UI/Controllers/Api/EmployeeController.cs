using Splendent.MVCReactJS.Models.Employee;
using Splendent.MVCReactJS.Services.RestClients;
using Splendent.MVCReactJS.UIServices.Employee;
using Splendent.MVCReactJS.UIServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Splendent.MVCReactJS.Web.UI.Controllers.Api
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeUiService _employeeUiService;
        public EmployeeController(IEmployeeUiService employeeUiService)
        {
            _employeeUiService = employeeUiService;
        }

        [Route("testEmployeeApi"), HttpGet]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> TestEmployeeApiAsync()
        {
            return Ok(await _employeeUiService.TestEmpApi());
        }

        [Route("getemployees"), HttpGet]
        [ResponseType(typeof(List<EmployeeModel>))]
        public async Task<IHttpActionResult> GetEmployeesAsync()
        {
            return Ok(await _employeeUiService.GetEmployees());
        }
    }
}
