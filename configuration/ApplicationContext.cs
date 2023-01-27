using SalesSystem.Models;

namespace SalesSystem.Configuration
{
    public class ApplicationContext
    {
        private static ApplicationContext instance;
        private List<Employee> _employees;

        private ApplicationContext()
        {
            _employees = new List<Employee>();
        }

        public static ApplicationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationContext();
                }
                return instance;
            }
        }

        public List<Employee> Employees
        {
            get { return _employees; }
        }
    }
}