namespace EmployeePerformanceTracker1.Repository
{
    public interface IEmployeeRepository<T1> where T1 : class
    {
        #region abstract methods
        Task<IEnumerable<T1>> GetAll();

        Task<T1> GetById(int id);

        #endregion
    }
}
