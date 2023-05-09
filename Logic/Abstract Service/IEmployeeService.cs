using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface IEmployeeService
    {
        string CreateEmployee(Employee employee);
        string UpdateEmployee(Employee employee);
        string DeleteEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        Employee GetById(int id);

}
}