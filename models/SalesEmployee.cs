using SalesSystem.Configuration;

namespace SalesSystem.Models
{
    public class SalesEmployee : Employee
    {
        public float Commission { get; set; }
        public List<Sale> Sales;

        public SalesEmployee(int id, string fName, string lName, string employeeNum, float baseSalary, float commission, Sale sales)
        : base(id, fName, lName, employeeNum, baseSalary)

        {
            this.Commission = commission;
            this.Sales = new List<Sale>();

        }

        public float GetSalary()
        {
            float totalSales = 0;
            foreach (Sale sale in Sales)
            {
                totalSales += sale.Amount * Commission;
            }
            return totalSales;
        }

        public float GetCommission()
        {
            return Commission;
        }

        public void AddSale(int employeeId, Sale sale)
        {
            var salesEmployee = ApplicationContext.Instance.Employees
                .OfType<SalesEmployee>()
                .FirstOrDefault(x => x.Id == employeeId);

            if (salesEmployee != null)
            {
                salesEmployee.Sales.Add(sale);
            }
            else
            {
                Console.WriteLine("No SalesEmployee with that ID exists.");
            }
        }
    }
}