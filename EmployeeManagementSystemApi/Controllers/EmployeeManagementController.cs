using EmployeeManagementSystemApi.Logic;
using EmployeeManagementSystemDb.Command;
using EmployeeManagementSystemDb.Models;
using EmployeeManagementSystemDb.Request;
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
        private Service _service;
        private readonly ILogger<EmployeeManagementController> _logger;

        public EmployeeManagementController(ILogger<EmployeeManagementController> logger,
            ValidateRequest validateRequest,
            UnitOfWork unitOfWork,
            EmployeeService employeeService,
            Service service)
        {
            _logger = logger;
            _ValidateRequest = validateRequest;
            _unitOfWork = unitOfWork;
            _employeeService = employeeService;
            _service = service;
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
        /// <summary>
        /// Add Employee.
        /// </summary>
        [Route("craete/Project")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProject([FromBody] Project request)
        {
            try
            {
                //var errMsg = _ValidateRequest.ValidateEmployee(request);
                //if (!string.IsNullOrEmpty(errMsg))
                //{
                //    _logger.Log(LogLevel.Error, errMsg);
                //    return BadRequest(request);
                //}
                _service.SaveOrUpdate(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Add Employee.
        /// </summary>
        [Route("assignProject")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AssignProject(int projectId,  int employeeId )
        {
            try
            {
                //var errMsg = _ValidateRequest.ValidateEmployee(request);
                //if (!string.IsNullOrEmpty(errMsg))
                //{
                //    _logger.Log(LogLevel.Error, errMsg);
                //    return BadRequest(request);
                //}
                
                var project = _service.GetProject(projectId);
                var employee = _service.GetEmployee(employeeId);
                if (project == null|| employee ==null)
                {
                   
                }
                if(project.Employees.Any(e=>e.EmployeeId == employeeId))
                {
                    //already exists
                    //return;
                }
                project.Employees.Add(employee);
                _service.SaveOrUpdate(project);

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