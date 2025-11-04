--1-CREATE TABLE: Creates an Employees table with columns for EmployeeID, FirstName, LastName, Department, and Salary.

CREATE TABLE employee (
	employee_id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	first_name VARCHAR(25),
	last_name VARCHAR(25),
	department VARCHAR(25),
	salary DECIMAL(10,2)
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

ALTER TABLE employee ADD email VARCHAR(25);

UPDATE employee SET email='zayn@malik.com' where employee_id=1
UPDATE employee SET email='dua@lipa.com' where employee_id=2
UPDATE employee SET email='billie@eilish.com' where employee_id=3
UPDATE employee SET email='arjisth@singh.com' where employee_id=4
UPDATE employee SET email='sarah@brown.com' where employee_id=5

ALTER TABLE employee ADD CONSTRAINT unique_key UNIQUE (email) 

Drop table employee
ALTER TABLE employee DROP COLUMN email

--12-Can you change the value of an auto-incrementing ID for an existing record? What happens if you do?
--	No, If a column specified auto increment that is IDENTITY then we can't change the value of the column directly
--	But have a methode to turn on insert in the IDENTITY column using IDENTITY_INSERT
--	Eg:- SET IDENTITY_INSERT employee ON
--		 INSERT INTO employee (emp_id,emp_name) values(26,'Nabeel)
--		 SET IDENTITY_INSERT employee OFF
--	Also we can adjust the seed to where want the next seed using DBCC CHECKIDET ('employee',RESEED, 26)


--13-What should you do if you want to start an auto-increment field from a specific number (e.g., 10) instead of 1?
-- Specify the starting point in identity is defined when creating the table
-- Eg:- CREATE TABLE employee2 (
--			employee_id INT NOT NULL PRIMARY KEY IDENTITY(10,1),  <----here 10 is the staring point of the id
--			first_name VARCHAR(25),
--			last_name VARCHAR(25),
--			department VARCHAR(25),
--			salary DECIMAL(10,2)
--		);

--14-What is the effect of having both a NOT NULL and a DEFAULT constraint on the same column?
--	If the column is not null and if no value inserted the defaul value will be stored.