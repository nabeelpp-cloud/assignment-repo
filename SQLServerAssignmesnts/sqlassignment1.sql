--1-CREATE TABLE: Creates an Employees table with columns for EmployeeID, FirstName, LastName, Department, and Salary.

CREATE TABLE employee (
    employee_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),  
    first_name VARCHAR(25) NOT NULL,                   
    last_name VARCHAR(25) NOT NULL,                   
    department VARCHAR(25) NOT NULL CHECK (department IN ('HR', 'Finance', 'IT', 'Sales', 'Marketing', 'Admin')), 
    salary DECIMAL(10,2) NOT NULL CHECK (salary >= 0),                            
    CONSTRAINT DF_department_default DEFAULT 'HR' FOR department
);

--2-INSERT: Adds three employee records to the table.

INSERT INTO employee (first_name, last_name, department, salary) VALUES
	('Zayn','Malik','H R',50000.59),
	('Dua','Lipa','Marketing',100000.00),
	('Billie','Eiliesh','Sales',800000.00),
	('Arjith','Sing','IT',60000.59);

--3-SELECT: Shows different ways to query data:
--	Select all columns and rows
--	Select specific columns
--	Select with a WHERE clause to filter results

SELECT * FROM employee;
SELECT first_name,last_name FROM employee;
SELECT CONCAT(first_name,' ',last_name) AS name FROM employee;
SELECT * FROM employee WHERE salary > 75000;

--4-What is the purpose of the IDENTITY keyword in the CREATE TABLE statement?
--	To setup auto increment to specific column

--5-Write a SELECT statement to retrieve only the FirstName and Salary of all employees.

SELECT first_name,salary FROM employee;

--6-How would you modify the existing UPDATE statement to give all employees in the IT department a 10% raise

UPDATE employee SET salary += salary*0.10 WHERE department = 'IT';

--7-Write a SELECT statement to find the highest salary in the Employees table.

SELECT MAX(salary) as highest_salary FROM employee;

--8-How would you add a new column named "HireDate" of type DATE to the Employees table?

ALTER TABLE employee ADD hire_date DATE

--9-Write an INSERT statement to add a new employee named "Sarah Brown" in the "Marketing" department with a salary of 72000.00.

INSERT INTO employee (first_name, last_name, department, salary) VALUES ('Sarah','Brown','Marketing',72000);

--10-How would you modify the table to ensure that the Salary column cannot contain negative values?

ALTER TABLE employee ADD CONSTRAINT check_salary CHECK(salary>=0)

--11-How would you add a UNIQUE constraint to the Employees table to ensure that no two employees can have the same email address
--Write an ALTER TABLE statement to add an "Email" column to the Employees table with a UNIQUE constraint that allows NULL values


ALTER TABLE employee
ADD Email VARCHAR(100) NULL UNIQUE;

Drop table employee
ALTER TABLE employee DROP COLUMN email

--12-Can you change the value of an auto-incrementing ID for an existing record? What happens if you do?
--	Normally, you cannot change the value of an auto-increment (IDENTITY) column.
--	If you force it using SET IDENTITY_INSERT, it may cause key conflicts or sequence issues, so it should be avoided.
SET IDENTITY_INSERT employee ON;

UPDATE employee
SET employee_id = 10
WHERE employee_id = 1;

SET IDENTITY_INSERT employee OFF;

--13-What should you do if you want to start an auto-increment field from a specific number (e.g., 10) instead of 1?
-- Specify the starting point in identity is defined when creating the table
-- Eg:- CREATE TABLE employee2 (
--			employee_id INT NOT NULL PRIMARY KEY IDENTITY(10,1),  
--			first_name VARCHAR(25),
--			last_name VARCHAR(25),
--			department VARCHAR(25),
--			salary DECIMAL(10,2)
--		);

--14-What is the effect of having both a NOT NULL and a DEFAULT constraint on the same column?
--	If the column is not null and if no value inserted the defaul value will be stored.