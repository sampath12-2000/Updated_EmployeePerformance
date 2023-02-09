using EmployeePerformanceTracker1.Models;
using Microsoft.EntityFrameworkCore;
namespace EmployeePerformanceTracker1.Repository
{
    public class EmployeeRepository:IEmployeeRepository<Employee>
    {
        private readonly EPTDBContext _dbcontext;

        public EmployeeRepository(EPTDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        #region GetAllEmployees
        public async Task<IEnumerable<Employee>> GetAll()
        {
            try
            {
                return await _dbcontext.Employees.ToListAsync();
            }
            catch
            {
                return Enumerable.Empty<Employee>();
            }
        }
        #endregion

        #region GetById
        public async Task<Employee> GetById(int id)
        {
            try {
                var employee = await _dbcontext.Employees.Where(e => e.EmployeeId == id).Select(e => new Employee()
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.EmployeeName,
                    Grade = e.Grade,
                    PhoneNo = e.PhoneNo,
                    Location = e.Location,
                    Role = e.Role,
                    EmailId = e.EmailId,
                    Password = e.Password,
                    MentorId=e.MentorId,
                    Mentor=e.Mentor
                }).FirstOrDefaultAsync();
                return employee;
        }
            catch
            {
                throw;
            }
            }
        #endregion
    }
}
