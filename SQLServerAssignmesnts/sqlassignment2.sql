--SQL Assignemnt 2
CREATE DATABASE assignments;

USE assignments;

--For this assignment, assume you have a database with the following table:
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Department VARCHAR(50),
    Salary DECIMAL(10, 2),
    HireDate DATE
);

INSERT INTO employees VALUES 
	(101,'Nabeel','P P','H R',100000.00,'2025-10-13'),
	(102,'Mafas','M B','Sales',75000.00,'2024-01-31'),
	(103,'Abhinav','P','Marketing',25000.00,'2020-4-20'),
	(104,'Karthik','M','I T',200000.00,'2023-7-3'),
	(105,'IHzan','V','Sales',60000.00,'2022-12-13'),
	(106,'Susan','Sharma','I T',600000.00,'2018-12-13'),
	(107,'Jhon','Augustin','Marketing',700000.00,'2025-10-13'),
	(108, 'Annie', 'Joseph', 'IT', 75000.00, '2024-11-12'),
	(109, 'Shane', 'Thomas', 'Finance', 82000.00, '2025-03-25');



--1-Create a table students and insert names in malayalam

CREATE TABLE students (
	studnet_id INT  PRIMARY KEY IDENTITY(1,1), 
	first_name NVARCHAR(100) COLLATE Indic_General_100_CI_AI,
	email VARCHAR(25)
);

INSERT INTO students (first_name,email) VALUES
	(N'നബീൽ', 'nabeel@gmail.com'),
	(N'മാഫാസ്', 'mafas@gmail.com'),
	(N'അഭിനവ്', 'abhinav@gmail.com'),
	(N'കാർത്തിക', 'karthik@gmail.com');

SELECT * FROM students;

--2-Retrieve all employees who work in Sales, Marketing, or IT departments.

SELECT * FROM employees WHERE department IN('Sales','Marketing','I T');

--3-Find all employees with salaries ranging from $50,000 to $75,000 (inclusive).

SELECT * FROM employees WHERE salary BETWEEN 50000 AND 75000;

--4-List all employees whose last name begins with the letter 'S'.

SELECT * FROM employees WHERE lastname LIKE 'S%';

--5-Display all employees with exactly five letters in their first name.

SELECT * FROM employees WHERE firstname LIKE '_____';

--6-Find employees whose last name starts with either 'B', 'R', or 'S'.

SELECT * FROM employees WHERE lastname LIKE '[B,R,S]%';

--7-Retrieve all employees whose first name begins with any letter from 'A' through 'M'.

SELECT * FROM employees WHERE firstname LIKE'[A-M]%';

--8-List employees whose last name doesn't start with a vowel (A, E, I, O, U).

SELECt * FROM employees WHERE lastname LIKE '[^(A,E,I,O,U)]%';

--9-Identify employees earning more than $80,000 annually. 

SELECT * FROM employees WHERE salary > 80000;

--10-Find employees who joined the company before 2020. 

SELECt * FROM employees WHERE  YEAR(hiredate)<2020;

--11-List all employees not named 'John' (first name).

SELECT * FROM employees WHERE firstname!='Jhon';

--12-Identify Marketing department employees earning $60,000 or less who were hired after June 30, 2019.

SELECT * FROM employees WHERE department ='Marketing' AND salary <= 60000 AND hiredate > '2019-06-30'

--13-Find employees whose first name contains the letters 'an' anywhere and ends with 'e'.

SELECT * FROM employees WHERE firstname LIKE '%an%e';