using AutoMapper;
using Crud_Api.Data;
using Crud_Api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DB _db;

        //پایینی رو نوشتم رو db نگه داشتم وکریت و اساین رو زدم بعدش
        public EmployeeController(IMapper mapper,DB db)
        {
            _mapper = mapper;
            _db = db;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            // گرفتن لیست کارکنان از دیتابیس
            var employees = _db.Employees.ToList();

            // تبدیل لیست کارکنان به لیست EmployeeDto
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);

            // بازگشت لیست EmployeeDto به کلاینت
            return Ok(employeeDtos);

            //پایینی بدون مپر

            //var allEmployees=db.Employees.ToList();
            //return Ok(allEmployees);
            //یا بالایی با پایینی جفتشم درسته
           // return Ok(db.Employees.ToList());
        }


        [HttpGet]
        [Route("{id}")]        
        public IActionResult GetEmployeeById(int id)
        {
            var employee=_db.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            var employeeDtos = _mapper.Map<EmployeeDto>(employee);

            return Ok(employeeDtos);

        }


        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto amd)
        {
            var employeeEntity = new Employee()
            {
                Name = amd.Name,
                Family= amd.Family,
                Email = amd.Email,
                Phone = amd.Phone,
                Salary = amd.Salary,
            };
       
            _db.Employees.Add(employeeEntity);
            _db.SaveChanges();
            return Ok(employeeEntity);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEmployee(int id,UpdateEmployeeDto ued)
        {
            var employee = _db.Employees.Find(id);
            if(employee == null)
            {
                return NotFound("کاربر پیدا نشد");
            }
            employee.Name = ued.Name;
            employee.Family=ued.Family;
            employee.Email = ued.Email;
            employee.Phone = ued.Phone;
            employee.Salary = ued.Salary;
            _db.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee=_db.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return Ok("با موفقیت حذف شد");
        }

    }      
}
