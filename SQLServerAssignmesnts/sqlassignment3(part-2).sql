-- SQL SERVER SCHEMA AND ASSIGNMENT QUESTIONS
-- Topic: GROUP BY, HAVING, and Aggregate Functions

-- =====================================================
-- SCHEMA CREATION
-- =====================================================

-- Create Database
CREATE DATABASE SalesAnalysisDB;
USE SalesAnalysisDB;
GO
-- 1. CUSTOMERS Table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(100) NOT NULL,
    City NVARCHAR(50),
    Country NVARCHAR(50),
    Region NVARCHAR(50),
    CustomerType NVARCHAR(20) CHECK (CustomerType IN ('Individual', 'Corporate'))
);

-- 2. PRODUCTS Table
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    Category NVARCHAR(50),
    UnitPrice DECIMAL(10,2),
    UnitsInStock INT,
    Supplier NVARCHAR(100)
);

-- 3. EMPLOYEES Table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Department NVARCHAR(50),
    Salary DECIMAL(10,2),
    HireDate DATE,
    ManagerID INT FOREIGN KEY REFERENCES Employees(EmployeeID)
);

-- 4. ORDERS Table
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
    EmployeeID INT FOREIGN KEY REFERENCES Employees(EmployeeID),
    OrderDate DATE,
    ShippedDate DATE,
    ShipCity NVARCHAR(50),
    ShipCountry NVARCHAR(50),
    Freight DECIMAL(8,2)
);

-- 5. ORDER_DETAILS Table
CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY IDENTITY(1,1),
    OrderID INT FOREIGN KEY REFERENCES Orders(OrderID),
    ProductID INT FOREIGN KEY REFERENCES Products(ProductID),
    Quantity INT,
    UnitPrice DECIMAL(10,2),
    Discount DECIMAL(4,2) DEFAULT 0.00
);

-- =====================================================
-- SAMPLE DATA INSERTION
-- =====================================================

-- Insert Customers
INSERT INTO Customers (CustomerName, City, Country, Region, CustomerType) VALUES
('ABC Corporation', 'New York', 'USA', 'North America', 'Corporate'),
('John Smith', 'London', 'UK', 'Europe', 'Individual'),
('Tech Solutions Ltd', 'Toronto', 'Canada', 'North America', 'Corporate'),
('Maria Garcia', 'Madrid', 'Spain', 'Europe', 'Individual'),
('Global Industries', 'Tokyo', 'Japan', 'Asia', 'Corporate'),
('David Wilson', 'Sydney', 'Australia', 'Oceania', 'Individual'),
('Innovation Corp', 'Berlin', 'Germany', 'Europe', 'Corporate'),
('Sarah Johnson', 'Chicago', 'USA', 'North America', 'Individual'),
('Asian Trading Co', 'Singapore', 'Singapore', 'Asia', 'Corporate'),
('Michael Brown', 'Paris', 'France', 'Europe', 'Individual');

-- Insert Products
INSERT INTO Products (ProductName, Category, UnitPrice, UnitsInStock, Supplier) VALUES
('Laptop Pro 15', 'Electronics', 1299.99, 50, 'TechSupplier Inc'),
('Wireless Mouse', 'Electronics', 29.99, 200, 'TechSupplier Inc'),
('Office Chair', 'Furniture', 199.99, 75, 'FurnitureCorp'),
('Desk Lamp', 'Furniture', 49.99, 120, 'FurnitureCorp'),
('Smartphone X1', 'Electronics', 899.99, 80, 'Mobiletech Ltd'),
('Coffee Maker', 'Appliances', 159.99, 45, 'HomeGoods Co'),
('Standing Desk', 'Furniture', 399.99, 30, 'FurnitureCorp'),
('Bluetooth Speaker', 'Electronics', 79.99, 150, 'AudioPro'),
('Microwave Oven', 'Appliances', 299.99, 25, 'HomeGoods Co'),
('Ergonomic Keyboard', 'Electronics', 89.99, 100, 'TechSupplier Inc');

-- Insert Employees
INSERT INTO Employees (FirstName, LastName, Department, Salary, HireDate, ManagerID) VALUES
('Alice', 'Johnson', 'Sales', 65000.00, '2020-01-15', NULL),
('Bob', 'Smith', 'Sales', 58000.00, '2021-03-20', 1),
('Carol', 'Davis', 'Marketing', 62000.00, '2019-11-10', NULL),
('David', 'Miller', 'Sales', 55000.00, '2022-02-14', 1),
('Emma', 'Wilson', 'IT', 75000.00, '2018-09-05', NULL),
('Frank', 'Taylor', 'Marketing', 59000.00, '2021-08-12', 3),
('Grace', 'Brown', 'Sales', 61000.00, '2020-12-03', 1),
('Henry', 'Jones', 'IT', 72000.00, '2019-04-18', 5),
('Ivy', 'Garcia', 'HR', 68000.00, '2021-01-25', NULL),
('Jack', 'Martinez', 'Sales', 57000.00, '2022-06-30', 1);

-- Insert Orders
INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, ShippedDate, ShipCity, ShipCountry, Freight) VALUES
(1, 2, '2024-01-15', '2024-01-18', 'New York', 'USA', 25.50),
(2, 4, '2024-01-20', '2024-01-23', 'London', 'UK', 35.75),
(3, 7, '2024-02-05', '2024-02-08', 'Toronto', 'Canada', 28.90),
(1, 2, '2024-02-15', '2024-02-18', 'New York', 'USA', 42.30),
(4, 10, '2024-02-28', '2024-03-03', 'Madrid', 'Spain', 31.20),
(5, 2, '2024-03-10', '2024-03-13', 'Tokyo', 'Japan', 55.80),
(6, 4, '2024-03-25', '2024-03-28', 'Sydney', 'Australia', 67.40),
(7, 7, '2024-04-12', '2024-04-15', 'Berlin', 'Germany', 38.90),
(2, 10, '2024-04-20', '2024-04-23', 'London', 'UK', 29.60),
(8, 2, '2024-05-05', '2024-05-08', 'Chicago', 'USA', 33.75),
(9, 4, '2024-05-18', '2024-05-21', 'Singapore', 'Singapore', 48.20),
(3, 7, '2024-06-02', '2024-06-05', 'Toronto', 'Canada', 52.10),
(10, 10, '2024-06-15', '2024-06-18', 'Paris', 'France', 41.30),
(1, 2, '2024-07-01', '2024-07-04', 'New York', 'USA', 36.80),
(5, 4, '2024-07-20', '2024-07-23', 'Tokyo', 'Japan', 59.90);

-- Insert Order Details
INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice, Discount) VALUES
(1, 1, 2, 1299.99, 0.05), (1, 2, 5, 29.99, 0.00),
(2, 3, 1, 199.99, 0.00), (2, 4, 2, 49.99, 0.10),
(3, 5, 1, 899.99, 0.00), (3, 8, 3, 79.99, 0.00),
(4, 1, 1, 1299.99, 0.00), (4, 10, 2, 89.99, 0.05),
(5, 6, 1, 159.99, 0.00), (5, 9, 1, 299.99, 0.00),
(6, 2, 10, 29.99, 0.15), (6, 4, 3, 49.99, 0.00),
(7, 7, 1, 399.99, 0.00), (7, 3, 2, 199.99, 0.10),
(8, 5, 2, 899.99, 0.00), (8, 8, 1, 79.99, 0.00),
(9, 1, 1, 1299.99, 0.00), (9, 2, 3, 29.99, 0.00),
(10, 6, 2, 159.99, 0.05), (10, 9, 1, 299.99, 0.00),
(11, 10, 5, 89.99, 0.00), (11, 8, 2, 79.99, 0.10),
(12, 3, 3, 199.99, 0.00), (12, 7, 1, 399.99, 0.00),
(13, 5, 1, 899.99, 0.00), (13, 2, 4, 29.99, 0.00),
(14, 1, 3, 1299.99, 0.10), (14, 4, 1, 49.99, 0.00),
(15, 9, 2, 299.99, 0.00), (15, 6, 1, 159.99, 0.00);

-- =====================================================
-- ASSIGNMENT QUESTIONS
-- =====================================================



--Question 1: Find the total number of customers in each country.

SELECT COUNT(*) AS number_of_customers, Country FROM Customers GROUP BY Country

--Question 2: Calculate the average unit price of products in each category.

SELECT AVG(UnitPrice) AS average_unit_price, Category FROM Products GROUP BY Category

--Question 3: Find the maximum and minimum salary in each department.

SELECT MAX(Salary) as max_salary, MIN(Salary) as min_salary, Department FROM Employees GROUP BY Department

--Question 4: Count the total number of products supplied by each supplier.

SELECT COUNT(*) number_of_products,Supplier FROM  Products GROUP BY Supplier

--Question 5: Calculate the total value of inventory (UnitsInStock × UnitPrice) for each product category.

SELECT SUM(UnitPrice*UnitsInStock) total_value_of_inventry, Category FROM Products GROUP BY Category

--Question 6: Find all product categories that have more than 2 products.

SELECT Category,COUNT(*) number_of_products FROM Products GROUP BY Category HAVING COUNT(*)>2

--Question 7: List departments where the average salary is greater than $60,000.

SELECT AVG(Salary) average_salary, Department FROM Employees GROUP BY Department HAVING AVG(Salary)> 60000

--Question 8: Show product categories where the average unit price is between $100 and $500.

SELECT AVG(UnitPrice) average_unit_price,Category FROM Products GROUP BY Category HAVING AVG(UnitPrice) BETWEEN 100 AND 500

--Question 9: Find suppliers who supply products worth more than $10,000 in total inventory value.

SELECT Supplier,SUM(UnitPrice*UnitsInStock) as total_inventory FROM Products GROUP BY Supplier HAVING SUM(UnitPrice*UnitsInStock)>10000

--Question 10: List countries that have more than 1 customer and show the customer count.

SELECT Country,COUNT(*) FROM Customers GROUP BY Country HAVING COUNT(*)>1
