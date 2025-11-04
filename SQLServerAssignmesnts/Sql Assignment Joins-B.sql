-- E-commerce Platform Schema


CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY,
    CustomerName VARCHAR(100),
    Email VARCHAR(100),
    RegistrationDate DATE
);

CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(200),
    Price DECIMAL(10, 2),
    CategoryID INT
);

CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY,
    CategoryName VARCHAR(100)
);

CREATE TABLE Orders (
    OrderID INT PRIMARY KEY,
    CustomerID INT,
    OrderDate DATE,
    TotalAmount DECIMAL(10, 2),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderDetails (
    OrderDetailID INT PRIMARY KEY,
    OrderID INT,
    ProductID INT,
    Quantity INT,
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Questions

-- 1. List all products with their category names, including products without a category.

SELECT 
	prod.ProductID,prod.ProductName,cat.CategoryName
FROM
	Products prod LEFT JOIN Categories cat
ON
	prod.CategoryID=cat.CategoryID

-- 2. Display all customers and their order history, including customers who haven't placed any orders.

SELECT 
	c.CustomerID,c.CustomerName,o.OrderID,o.OrderDate,o.TotalAmount
FROM 
	Customers c LEFT JOIN Orders o
ON 
	c.CustomerID=o.CustomerID

-- 3. Show all categories and the products in each category, including categories without any products.

SELECT 
	cat.CategoryID,cat.CategoryName,prod.ProductName
FROM 
	Categories cat LEFT JOIN Products prod
ON
	cat.CategoryID=prod.CategoryID


-- 4. List all possible customer-product combinations, regardless of whether a purchase has occurred.

SELECT
	cust.CustomerName,prod.ProductName
FROM
	Customers cust CROSS JOIN Products prod

-- 5. Display all orders with customer and product information, 
--	including orders where either the customer or product information is missing.

SELECT
	o.OrderID,c.CustomerName,p.ProductName
FROM
	Orders o LEFT JOIN OrderDetails od
ON
	o.OrderID = od.OrderID LEFT JOIN Customers c
ON
	o.CustomerID = c.CustomerID LEFT JOIN Products p
ON
	od.ProductID =p.ProductID
	

-- 6. Show all products that have never been ordered, along with their category information.

SELECT 
	p.ProductID,p.ProductName,c.CategoryName,od.OrderID
FROM
	Products p 
LEFT JOIN 
	OrderDetails od ON p.ProductID=od.ProductID
LEFT JOIN 
	Categories c ON c.CategoryID=p.CategoryID
WHERE od.OrderID IS NULL;

-- 7. List all customers who have placed orders in the last week, along with the products they've purchased.

SELECT
	c.CustomerID,c.CustomerName,p.ProductName
FROM 
	Customers c   
LEFT JOIN
	Orders o ON c.CustomerID=o.CustomerID
LEFT JOIN 
	OrderDetails od ON o.OrderID=od.OrderID
LEFT JOIN
	Products p ON od.ProductID=p.ProductID
WHERE
	o.OrderDate  BETWEEN DATEADD(day,-7,GETDATE()) AND DATEADD(day,-1,GETDATE())

-- 8. Display all categories with products priced over $100, including categories without such products.

SELECT
	c.CategoryID,c.CategoryName,p.ProductName,p.Price
FROM
	Categories c 
LEFT JOIN
	Products p ON c.CategoryID=p.CategoryID AND p.Price>100

-- 9. Show all orders placed before 2023 and any associated product information.

SELECT
	o.OrderID,o.OrderDate,p.ProductName
FROM
	Orders o
LEFT JOIN 
	OrderDetails od ON od.OrderID= o.OrderID
LEFT JOIN
	Products p ON p.ProductID=od.ProductID
WHERE 
	YEAR(o.OrderDate)<2023 

-- 10. List all possible category-customer combinations, 
-- regardless of whether the customer has purchased a product from that category.

SELECT
	cat.CategoryID,cat.CategoryName,cust.CustomerName
FROM
	Categories cat
CROSS JOIN
	Customers cust
