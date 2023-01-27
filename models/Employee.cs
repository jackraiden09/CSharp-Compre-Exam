namespace SalesSystem.Models 
{
    public class Employee : Person 
    {
        public string EmployeeNumber {get; set;}
        public float BaseSalary {get; set;}

        public Employee(int id, string fName, string lName, string employeeNum, float baseSalary) : 
            base(id, fName, lName)
        {
            this.EmployeeNumber = employeeNum;
            this.BaseSalary = baseSalary;
        }

        public float GetSalary()
        {
            return this.BaseSalary;
        }

    }
}