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
        private readonly DB db;

        //پایینی رو نوشتم رو db نگه داشتم وکریت و اساین رو زدم بعدش
        public EmployeeController(DB db)
        {
            this.db = db;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            //var allEmployees=db.Employees.ToList();
            //return Ok(allEmployees);
            //یا بالایی با پایینی جفتشم درسته
            return Ok(db.Employees.ToList());
        }


        [HttpGet]
        [Route("{id}")]        
        public IActionResult GetEmployeeById(int id)
        {
            var employee=db.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);

        }


        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto amd)
        {
            var employeeEntity = new Employee()
            {
                Name = amd.Name,
                Email = amd.Email,
                Phone = amd.Phone,
                Salary = amd.Salary,
            };
       
            db.Employees.Add(employeeEntity);
            db.SaveChanges();
            return Ok(employeeEntity);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateEmployee(int id,UpdateEmployeeDto ued)
        {
            var employee = db.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            employee.Name = ued.Name;
            employee.Email = ued.Email;
            employee.Phone = ued.Phone;
            employee.Salary = ued.Salary;
            db.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee=db.Employees.Find(id);
            if(employee == null)
            {
                return NotFound();
            }
            db.Employees.Remove(employee);
            db.SaveChanges();
            return Ok("با موفقیت حذف شد");
        }

    }      
}
