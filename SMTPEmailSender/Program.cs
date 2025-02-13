
using ConsoleApp10.Data;
using ConsoleApp10.Models;
using ConsoleApp10.SMTP;
using SMTPEmailSender.Services;



EmployeeService employeeService = new EmployeeService();
EmailService emailService = new EmailService();

while (true)
{
    Console.WriteLine("1. Add Employee \n 2. View All Employees \n 3. Send mail \n 4. Update Employees \n 5. Delete Employee \n 6. Search Employee \n 7. View Employee Details \n 8. Send Mail to All Employees \n 9. Export Employees to CSV (Desktop) \n 10. Quit");
    var option = Console.ReadLine();
    if (option == "1")
    {
        employeeService.addEmployee();
    }
    else if (option == "2")
    {
        employeeService.ShowAllEmployees();
    }
    else if (option == "3")
    {
        emailService.SendMail();
    }
    else if (option == "4")
    {
        employeeService.updateEmployee();
    }
    else if (option == "5")
    {
        employeeService.deleteEmployee();
    }
    else if (option == "6")
    {
        employeeService.searchEmployees();
    }
    else if (option == "7")
    {
        employeeService.viewEmployeeDetails();
    }
    else if (option == "8")
    {
        emailService.sendMailToAll();
    }
    else if (option == "9")
    {
        employeeService.exportToCSV();
    }
    else if (option == "10")
    {
        break;
    }


}










