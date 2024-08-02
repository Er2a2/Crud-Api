using Crud_Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud_Api.Data
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
