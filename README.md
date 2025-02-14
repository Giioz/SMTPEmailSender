Employee Management System
This Employee Management System is a console-based application built with C# and Entity Framework. The system allows administrators to manage employee records in a database, send email notifications, and export data to CSV format. It includes functionality for adding, updating, deleting, and searching employee records, as well as sending specific emails like meeting invitations, birthday greetings, and salary alerts.

Features
1. Employee Registration & Management
Add Employee: Allows you to register a new employee by entering their first name, last name, and email.
Update Employee: Edit an existing employee’s information, including first name, last name, and email.
Delete Employee: Remove an employee from the system by providing their unique employee ID.
Search Employees: Find employees based on their first name, last name, or email.
View Employee Details: Retrieve detailed information of an employee using their ID.
2. Email Notifications
Send Email to Specific Employee: Send personalized emails to individual employees based on their ID, such as meeting invitations, birthday wishes, or salary alerts.
Send Email to All Employees: Broadcast emails to all employees for announcements like meetings, birthdays, or salary updates.
3. CSV Export
Export Employee Data to CSV: Export the entire list of employees to a CSV file for easy data management. The CSV file is saved to the desktop.
4. Email Templates
Meeting Invitations: Send formatted meeting invitations to employees.
Birthday Greetings: Send personalized birthday messages to employees.
Salary Alerts: Notify employees about their salary payments through a salary alert email.
Technologies Used
C#: The core programming language used to develop the application.
Entity Framework: ORM framework to manage employee data in the database.
SMTP: For sending emails using an external email service.
CSV Export: To store employee data in CSV format on the desktop for easy access.
Setup and Installation
Clone the Repository:

bash
Copy
git clone https://github.com/yourusername/employee-management-system.git
cd employee-management-system
Install Required Packages:

Make sure to install the necessary Entity Framework and SMTP packages if required.
Configure Database Connection:

Update the database connection string in appsettings.json or your preferred configuration file to ensure the application connects to your database correctly.
SMTP Configuration:

Set up the SMTP email sender with valid credentials to send emails. This can be configured in the EmailSender class.
Run the Application:

bash
Copy
dotnet run
Usage
Employee Management
Add Employee: The system will prompt you to input employee details (First Name, Last Name, Email) and add them to the database.
Update Employee: You can search and select an employee to update their information by ID.
Delete Employee: Delete an employee by entering their unique ID. The system will ask for confirmation before deletion.
Search Employees: Search for employees based on first name, last name, or email.
View Employee Details: Retrieve detailed information of an employee by entering their employee ID.
Email Notifications
Send Email to an Employee:

Choose the employee from the list by ID and select an email type (Meeting, Birthday, Salary Alert).
The system will send a formatted email based on the selected type.
Send Email to All Employees:

Broadcast the same type of email (Meeting, Birthday, Salary Alert) to all employees in the system.
Export to CSV
The Export to CSV function will generate a file named employees.csv containing employee data, and save it on your desktop.
Example Screenshots
Add Employee:
mathematica
Copy
Enter Employee First Name
John
Enter Employee Last Name
Doe
Enter Employee Email
johndoe@example.com
Employee Added to Database
Update Employee:
sql
Copy
Enter Employee ID to update:
1
Updating details for: John Doe
Enter new First Name (Leave blank to keep current):
John
Enter new Last Name (Leave blank to keep current):
Smith
Enter new Email (Leave blank to keep current):
johnsmith@example.com
Employee details updated successfully!
Send Email to All Employees:
markdown
Copy
Choose Email Type:
1. Meeting Invitation
2. Birthday Message
3. Salary Alert
Export Employee Data:
css
Copy
Employee data has been successfully exported to: C:\Users\YourUser\Desktop\employees.csv
Contributing
Feel free to fork the repository and submit pull requests for any improvements or new features.

License
This project is licensed under the MIT License.
