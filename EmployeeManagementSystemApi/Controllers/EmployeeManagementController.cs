using EmployeeManagementSystemApi.Logic;
using EmployeeManagementSystemDb.Command;
using EmployeeManagementSystemDb.Models;
using Logic.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EmployeeManagementSystemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeManagementController : ControllerBase
    {
        private ValidateRequest _ValidateRequest;
        private UnitOfWork _unitOfWork;
        private EmployeeService _employeeService;
        private readonly ILogger<EmployeeManagementController> _logger;

        public EmployeeManagementController(ILogger<EmployeeManagementController> logger,
            ValidateRequest validateRequest,
            UnitOfWork unitOfWork,
            EmployeeService employeeService)
        {
            _logger = logger;
            _ValidateRequest = validateRequest;
            _unitOfWork = unitOfWork;
            _employeeService = employeeService;
            
        }
        /// <summary>
        /// Add Employee.
        /// </summary>
        [Route("create/Employee")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddEmployee([FromBody] Employee request)
        {
            try
            {
                var errMsg = _ValidateRequest.ValidateEmployee(request);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    _logger.Log(LogLevel.Error, errMsg);
                    return BadRequest(request);
                }
                _employeeService.SaveOrUpdateEmployee(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                return BadRequest(ex.Message);
            }
        }
    }
}