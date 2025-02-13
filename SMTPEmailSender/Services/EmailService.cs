using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp10.Data;
using ConsoleApp10.Models;
using ConsoleApp10.SMTP;

namespace SMTPEmailSender.Services
{
    public class EmailService
    {
        private readonly DataContext _context;
        private readonly EmailSender _sender;

        public EmailService()
        {
            _context = new DataContext();
            _sender = new EmailSender();
        }

        public void SendMail()
        {
            var employeeService = new EmployeeService();
            employeeService.ShowAllEmployees();

            Console.WriteLine("Choose Employee by ID");
            int chosenID = int.Parse(Console.ReadLine());
            Employee chosenEmployee = _context.employees.Where(e => e.Id == chosenID).FirstOrDefault();

            if (chosenEmployee == null)
            {
                Console.WriteLine($"Employee with Id {chosenID} does not exist in database.");
                return;
            }

            string employeeMail = chosenEmployee.mail;

            Console.WriteLine("Choose Email Type:");
            Console.WriteLine("1. Meeting Invitation \n2. Happy Birthday message \n3. Salary Alert");
            var option = Console.ReadLine();

            if (option == "1")
            {
                SendMeetingEmail(chosenEmployee, employeeMail);
            }
            else if (option == "2")
            {
                SendBirthdayEmail(chosenEmployee, employeeMail);
            }
            else if (option == "3")
            {
                SendSalaryAlertEmail(chosenEmployee, employeeMail);
            }
        }

        public void sendMailToAll()
        {
            var employees = _context.employees.ToList();

            Console.WriteLine("Choose Email Type:");
            Console.WriteLine("1. Meeting Invitation \n2. Birthday Message \n3. Salary Alert");
            var option = Console.ReadLine();

            if (option == "1")
            {
                foreach (var employee in employees)
                {
                    SendMeetingEmail(employee, employee.mail);
                }
                Console.WriteLine("Meeting Invitation emails have been sent to all employees.");
            }
            else if (option == "2")
            {
                foreach (var employee in employees)
                {
                    SendBirthdayEmail(employee, employee.mail);
                }
                Console.WriteLine("Birthday emails have been sent to all employees.");
            }
            else if (option == "3")
            {
                foreach (var employee in employees)
                {
                    SendSalaryAlertEmail(employee, employee.mail);
                }
                Console.WriteLine("Salary alert emails have been sent to all employees.");
            }
            else
            {
                Console.WriteLine("Invalid option. Please choose a valid option.");
            }
        }


        private void SendMeetingEmail(Employee chosenEmployee, string employeeMail)
        {
            var subject = "Meeting Invitation";
            var content = @$"
                <html>
                    <head>
                        <style>
                            body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; color: #333; background-color: #f9fafb; }}
                            .email-container {{ background-color: #ffffff; border-radius: 12px; padding: 30px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); max-width: 600px; margin: 30px auto; }}
                            h2 {{ color: #2c3e50; font-size: 28px; font-weight: bold; }}
                            p {{ font-size: 16px; line-height: 1.6; color: #555; }}
                            .button {{ padding: 12px 30px; background-color: #3498db; color: white; text-decoration: none; font-weight: bold; font-size: 16px; border-radius: 6px; }}
                            .footer {{ font-size: 13px; color: #999; margin-top: 30px; border-top: 1px solid #eee; padding-top: 15px; }}
                        </style>
                    </head>
                    <body>
                        <div class='email-container'>
                            <h2>Dear {chosenEmployee.firstName},</h2>
                            <p>You are invited to a meeting on <strong>20th February at 20:00</strong>.</p>
                            <p>Please attend the meeting, and feel free to reach out if you have any questions.</p>
                            <a href='#' class='button'>Confirm Attendance</a>
                            <p class='footer'>This is an automated message. Do not reply.</p>
                        </div>
                    </body>
                </html>";

            _sender.sendMail(employeeMail, subject, content);
        }

        private void SendBirthdayEmail(Employee chosenEmployee, string employeeMail)
        {
            var subject = "Happy Birthday";
            var content = @$"
                <html>
                    <head>
                        <style>
                            body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; color: #333; background-color: #fef8f4; }}
                            .email-container {{ background-color: #ffffff; border-radius: 12px; padding: 40px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); max-width: 600px; margin: 30px auto; }}
                            h2 {{ color: #e74c3c; font-size: 32px; font-weight: bold; }}
                            p {{ font-size: 16px; line-height: 1.6; color: #555; }}
                            .button {{ padding: 12px 30px; background-color: #f39c12; color: white; text-decoration: none; font-weight: bold; font-size: 16px; border-radius: 6px; }}
                            .footer {{ font-size: 13px; color: #999; margin-top: 40px; border-top: 1px solid #eee; padding-top: 15px; }}
                        </style>
                    </head>
                    <body>
                        <div class='email-container'>
                            <h2>Happy Birthday {chosenEmployee.firstName}!</h2>
                            <p>We wish you all the best on your special day!</p>
                            <a href='#' class='button'>Celebrate</a>
                            <p class='footer'>This is an automated message. Do not reply.</p>
                        </div>
                    </body>
                </html>";

            _sender.sendMail(employeeMail, subject, content);
        }

        private void SendSalaryAlertEmail(Employee chosenEmployee, string employeeMail)
        {
            var subject = "Salary Alert";
            var content = @$"
                <html>
                    <head>
                        <style>
                            body {{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; color: #333; background-color: #f4f7fa; }}
                            .email-container {{ background-color: #ffffff; border-radius: 12px; padding: 40px; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); max-width: 600px; margin: 30px auto; }}
                            h2 {{ color: #27ae60; font-size: 28px; font-weight: bold; }}
                            p {{ font-size: 16px; line-height: 1.6; color: #555; }}
                            .button {{ padding: 12px 30px; background-color: #27ae60; color: white; text-decoration: none; font-weight: bold; font-size: 16px; border-radius: 6px; }}
                            .footer {{ font-size: 13px; color: #999; margin-top: 40px; border-top: 1px solid #eee; padding-top: 15px; }}
                        </style>
                    </head>
                    <body>
                        <div class='email-container'>
                            <h2>Salary Alert for {chosenEmployee.firstName}</h2>
                            <p>Your salary has been processed successfully.</p>
                            <a href='#' class='button'>View Details</a>
                            <p class='footer'>This is an automated message. Do not reply.</p>
                        </div>
                    </body>
                </html>";

            _sender.sendMail(employeeMail, subject, content);
        }
    }
}
