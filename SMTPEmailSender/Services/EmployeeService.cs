using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp10.Data;
using ConsoleApp10.Models;

namespace SMTPEmailSender.Services
{
    public class EmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService()
        {
            _context = new DataContext();
        }

        public void addEmployee()
        {
            Console.WriteLine("Enter Employee First Name");
            var firstName = Console.ReadLine();
            Console.WriteLine("Enter Employee Last Name");
            var lastName = Console.ReadLine();
            Console.WriteLine("Enter Employee Email");
            var email = Console.ReadLine();

            Employee empToAdd = new Employee()
            {
                firstName = firstName,
                lastName = lastName,
                mail = email,
            };

            _context.employees.Add(empToAdd);
            _context.SaveChanges();
            Console.WriteLine("Employee Added to Database");
        }
        public void updateEmployee()
        {
            Console.WriteLine("Enter Employee ID to update:");
            int id = int.Parse(Console.ReadLine());
            var employee = _context.employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                Console.WriteLine("Employee not found!");
                return;
            }

            Console.WriteLine($"Updating details for: {employee.firstName} {employee.lastName}");

            Console.WriteLine("Enter new First Name (Leave blank to keep current):");
            var firstName = Console.ReadLine();
            if (!string.IsNullOrEmpty(firstName)) employee.firstName = firstName;

            Console.WriteLine("Enter new Last Name (Leave blank to keep current):");
            var lastName = Console.ReadLine();
            if (!string.IsNullOrEmpty(lastName)) employee.lastName = lastName;

            Console.WriteLine("Enter new Email (Leave blank to keep current):");
            var email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email)) employee.mail = email;

            _context.SaveChanges();
            Console.WriteLine("Employee details updated successfully!");
        }
        public void deleteEmployee()
        {
            Console.WriteLine("Enter Employee ID to delete:");
            int id = int.Parse(Console.ReadLine());
            var employee = _context.employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                Console.WriteLine("Employee not found!");
                return;
            }

            Console.WriteLine($"Are you sure you want to delete {employee.firstName} {employee.lastName}? (y/n)");
            var confirm = Console.ReadLine().ToLower();

            if (confirm == "y")
            {
                _context.employees.Remove(employee);
                _context.SaveChanges();
                Console.WriteLine("Employee deleted successfully!");
            }
            else
            {
                Console.WriteLine("Employee deletion cancelled.");
            }
        }
        public void searchEmployees()
        {
            Console.WriteLine("Enter search term (First Name, Last Name, or Email):");
            var searchTerm = Console.ReadLine().ToLower();

            var results = _context.employees
                                  .Where(e => e.firstName.ToLower().Contains(searchTerm) ||
                                             e.lastName.ToLower().Contains(searchTerm) ||
                                             e.mail.ToLower().Contains(searchTerm))
                                  .ToList();

            if (results.Any())
            {
                Console.WriteLine("Search Results:");
                foreach (var employee in results)
                {
                    Console.WriteLine($"ID: {employee.Id}, Name: {employee.firstName} {employee.lastName}, Email: {employee.mail}");
                }
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
        }
        public void viewEmployeeDetails()
        {
            Console.WriteLine("Enter Employee ID to view details:");
            int id = int.Parse(Console.ReadLine());
            var employee = _context.employees.FirstOrDefault(e => e.Id == id);

            if (employee != null)
            {
                Console.WriteLine($"Employee ID: {employee.Id}");
                Console.WriteLine($"First Name: {employee.firstName}");
                Console.WriteLine($"Last Name: {employee.lastName}");
                Console.WriteLine($"Email: {employee.mail}");
               
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void exportToCSV()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, "employees.csv");

            var employees = _context.employees.ToList();

            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine("ID,First Name,Last Name,Email");

                foreach (var employee in employees)
                {
                    writer.WriteLine($"{employee.Id},{employee.firstName},{employee.lastName},{employee.mail}");
                }
            }

            Console.WriteLine($"Employee data has been successfully exported to: {filePath}");
        }
        public void ShowAllEmployees()
        {
            var employees = _context.employees.ToList();
            foreach (var employee in employees)
            {
                Console.WriteLine($"Employee ID: {employee.Id}");
                Console.WriteLine($"First Name: {employee.firstName}");
                Console.WriteLine($"Last Name: {employee.lastName}");
                Console.WriteLine($"Email: {employee.mail}");
            }
        }
    }
}
