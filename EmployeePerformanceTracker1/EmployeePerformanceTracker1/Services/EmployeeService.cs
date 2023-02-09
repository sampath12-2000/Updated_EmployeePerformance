using EmployeePerformanceTracker1.Models;
using EmployeePerformanceTracker1.Repository;

namespace EmployeePerformanceTracker1.Services
{
    public class EmployeeService
    {
        IEmployeeRepository<Employee> _repository;
        public EmployeeService(IEmployeeRepository<Employee> repository)
        {
            _repository = repository;
        }

        #region getall
        
        public async Task<IEnumerable<Employee>> GetAll()
        {
          return await _repository.GetAll();
        }
        


        #endregion
    }
}
