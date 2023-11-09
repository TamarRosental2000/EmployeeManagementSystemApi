using EmployeeManagementSystemApi.Logic;
using EmployeeManagementSystemDb.Command;
using EmployeeManagementSystemDb.Models;
using EmployeeManagementSystemDb.Request;
using EmployeeManagementSystemDb.Utils;
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
        private Utils _utils;
        private readonly ILogger<EmployeeManagementController> _logger;

        public EmployeeManagementController(ILogger<EmployeeManagementController> logger,
            ValidateRequest validateRequest,
            UnitOfWork unitOfWork,
            EmployeeService employeeService,
            Service service,
            Utils utils)
        {
            _logger = logger;
            _ValidateRequest = validateRequest;
            _unitOfWork = unitOfWork;
            _employeeService = employeeService;
            _service = service;
            _utils = utils;
        }

        /// <summary>
        /// Add Employee.
        /// </summary>
        [Route("create/Employee")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequest employeeRquest)
        {
            try
            {
                var errMsg = _ValidateRequest.ValidateEmployee(employeeRquest);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    _logger.Log(LogLevel.Error, errMsg);
                    return BadRequest(employeeRquest);
                }
                var request = _utils.BuildEmployee(employeeRquest);

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
        /// craete Project.
        /// </summary>
        [Route("craete/Project")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateProject([FromBody] ProjectRequest projectRequest)
        {
            try
            {
                var errMsg = _ValidateRequest.ValidateProject(projectRequest);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    _logger.Log(LogLevel.Error, errMsg);
                    return BadRequest(projectRequest);
                }
                var request = _utils.BuildProject(projectRequest);
            
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
        /// Assign Project.
        /// </summary>
        [Route("assignProject")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AssignProject(int projectId,  int employeeId )
        {
            try
            {
                
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
        /// <summary>
        /// Update Project.
        /// </summary>
        [Route("update/Project")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> updateProject([FromBody] ProjectRequest projectRequest, int projectId)
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
                if (project == null)
                {
                }
                var request = _utils.BuildProject(projectRequest);
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
        /// Update Employee.
        /// </summary>
        [Route("update/Employee")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> updateEmployee([FromBody] EmployeeRequest employeeRequest, int employeeId)
        {
            try
            {
                var errMsg = _ValidateRequest.ValidateEmployee(employeeRequest);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    _logger.Log(LogLevel.Error, errMsg);
                    return BadRequest(employeeRequest);
                }
                var employee = _service.GetEmployee(employeeId);
                if (employee == null)
                {
                }
                var request = _utils.BuildEmployee(employeeRequest);
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
        /// Update Employee.
        /// </summary>
        [Route("delete/Employee")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> DeleteEmployee(int employeeId)
        {
            try
            {
                var errMsg = _ValidateRequest.ValidateId(employeeId);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    _logger.Log(LogLevel.Error, errMsg);
                    return BadRequest(employeeId);
                }
                var employee = _service.GetEmployee(employeeId);
                if (employee == null)
                {
                }
                employee.Projects.Clear();
                _service.SaveOrUpdate(employee);
                _service.DeleteEmployee(employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Delete Project.
        /// </summary>
        [Route("delete/project")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            try
            {
                var errMsg = _ValidateRequest.ValidateId(projectId);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    _logger.Log(LogLevel.Error, errMsg);
                    return BadRequest(projectId);
                }
                var project = _service.GetProject(projectId);
                if (project == null)
                {
                }
                project.Employees.Clear();
                _service.SaveOrUpdate(project);
                _service.DeleteEmployee(projectId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// report.
        /// Every employee get salery by project if he get X salery (for month) and work in Y project he get X * Y project
        /// This report show how much money spent on specific Id project
        /// 
        /// </summary>
        [Route("report")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<decimal> Report(int projectId)
        {
            try
            {
                var errMsg = _ValidateRequest.ValidateId(projectId);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    _logger.Log(LogLevel.Error, errMsg);
                }
                var project = _service.GetProject(projectId);
                if (project == null)
                {
                }
                if (project.EndDate==null)
                {
                    project.EndDate = DateTime.Now;
                }
                var sum = project.Employees.Sum(item => item.Salary);
                var diff = project.EndDate - project.StartDate;
                var month= diff.Value.Days / 30;
                return sum*month;

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return 0;
        }

    }
}