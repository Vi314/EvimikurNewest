using Entity.Entity;

namespace Logic.Abstract_Service
{
    public interface IEmployeeService
    {
        string CreateOne(Employee employee);
        string UpdateOne(Employee employee);
        string DeleteEmployee(int id);
        IEnumerable<Employee> GetEmployees();
        Employee GetById(int id);

}
}