using SalesSystem.Configuration;
using SalesSystem.Interfaces;
using SalesSystem.Models;

namespace SalesSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> employees;
        private ApplicationContext context;

        public EmployeeService()
        {
            context = ApplicationContext.Instance;
            employees = context.Employees;
        }

        public List<Employee> GetAll()
        {
            return employees;
        }

        public List<Employee> GetAllSalesEmployees()
        {
            return employees.Where(e => e is SalesEmployee).ToList();
        }

        public Employee Save(Employee e)
        {
            if (!employees.Contains(e))
            {
                employees.Add(e);
            }
            return e;
        }

        public void Delete(Employee e)
        {
            employees.Remove(e);
        }

        public void AddSale(SalesEmployee e, Sale s)
        {
            e.Sales.Add(s);
        }

       
    }
}