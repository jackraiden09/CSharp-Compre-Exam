
using SalesSystem.Configuration;
using SalesSystem.Models;
using SalesSystem.Services;
using SalesSystem.Interfaces;

namespace SalesSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Employee employee = new Employee(1, "John", "Doe", "E123", 40000);
            // float salary = employee.GetSalary();
            // Console.WriteLine(salary);

            // ApplicationContext.Instance.Employees.Add(new Employee(666, "Miks", "Lanto", "09876543211", 2000));
            // foreach (var employee in ApplicationContext.Instance.Employees)
            // {
            //     Console.WriteLine("ID: " + employee.Id);
            //     Console.WriteLine("First Name: " + employee.FirstName);
            //     Console.WriteLine("Last Name: " + employee.LastName);
            //     Console.WriteLine("Employee Number: " + employee.EmployeeNumber);
            //     Console.WriteLine("Base Salary: " + employee.BaseSalary);
            //     if (employee is SalesEmployee)
            //     {
            //         SalesEmployee salesEmployee = employee as SalesEmployee;
            //         Console.WriteLine("Commission: " + salesEmployee.Commission);
            //         Console.WriteLine("Sales: ");
            //         foreach (var sale in salesEmployee.Sales)
            //         {
            //             Console.WriteLine("Name: " + sale.Name);
            //             Console.WriteLine("Amount: " + sale.Amount);
            //         }
            //     }
            //     Console.WriteLine();
            // }


            EmployeeService employeeService = new EmployeeService(); 
            while (true)
            {
                Console.WriteLine("Please enter a command (list, save, delete, add sale, quit)");
                string command = Console.ReadLine().ToLower();

                if (command == "list")
                {
                    // List all employees
                    List<Employee> employees = employeeService.GetAll();
                    foreach (Employee employee in employees)
                    {
                        Console.WriteLine(employee.FirstName + " " + employee.LastName);
                    }

                    // List all sales employees
                    List<Employee> salesEmployees = employeeService.GetAllSalesEmployees();
                    foreach (Employee employee in salesEmployees)
                    {
                        Console.WriteLine(employee.FirstName + " " + employee.LastName);
                    }
                }
                else if (command == "save")
                {
                    // Save an Employee record
                    Console.WriteLine("Enter Employee Number: ");
                    string tempId = Console.ReadLine();
                    int id = int.Parse(tempId);
                    Console.WriteLine("Enter the employee's first name:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Enter the employee's last name:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter the employee's employee number:");
                    string employeeNumber = Console.ReadLine();
                    Console.WriteLine("Enter the employee's base salary:");
                    float baseSalary = float.Parse(Console.ReadLine());

                    Employee employee = new Employee(id, firstName, lastName, employeeNumber, baseSalary);
                    employeeService.Save(employee);
                }
                else if (command == "delete")
                {
                    // Delete an Employee
                    Console.WriteLine("Enter the ID of the employee you want to delete:");
                    int id = int.Parse(Console.ReadLine());
                    Employee employeeToDelete = employeeService.GetAll().Find(x => x.Id == id);
                    employeeService.Delete(employeeToDelete);
                }
                else if (command == "add sale")
                {
                    Console.WriteLine("Enter the sales employee's ID:");
                    int id = int.Parse(Console.ReadLine());
                    var employee = employeeService.GetAll().OfType<SalesEmployee>().FirstOrDefault(e => e.Id == id);
                    if (employee != null)
                    {
                        Console.WriteLine("Enter the sale's name:");
                        string saleName = Console.ReadLine();
                        Console.WriteLine("Enter the sale's amount:");
                        float saleAmount = float.Parse(Console.ReadLine());
                        Sale sale = new Sale(saleName, saleAmount);
                        employeeService.AddSale(employee, sale);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid ID for a sales employee.");
                    }
                }

                else if (command == "quit")
                {
                    // Exit the program
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid command, please try again.");
                }
            }
        }
    }
}
