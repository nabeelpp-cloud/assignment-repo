--SQL Server Function Assignment Questions - 3
CREATE DATABASE sql3;
USE sql3;

--String Functions

--1. Extract the middle 3 characters from the string 'ABCDEFG'.

SELECT SUBSTRING('ABCDEFG',3,3)

--2. From a table 'Employees' with a column 'FullName', write a query to extract the first name (assuming it's always the first word before a space).

SELECT LEFT(FullName,CHARINDEX(' ',FullName)-1) FROM Employees;

--3. Extract the first 5 characters from the string 'SQL Server 2022'.

SELECT LEFT('SQL Server 2022',5);

--4. From a 'Products' table with a 'ProductCode' column, write a query to get the first 3 characters of each product code.

SELECT LEFT(ProductCode,3) FROM Products;

--5. Extract the last 4 characters from the string 'ABCDEFGHIJKL'.

SELECT RIGHT('ABCDEFGHIJKL',5)

--6. From an 'Orders' table with an 'OrderID' column (format: ORD-YYYY-NNNN), write a query to extract just the numeric portion at the end.

SELECT RIGHT(OrderID,CHARINDEX('-',REVERSE(OrderID))-1) FROM Orders;

--7. Write a query to find the length of the string 'SQL Server Functions'.

SELECT LEN('SQL Server Functions');

--8. From a 'Customers' table, find customers whose names are longer than 20 characters.

SELECT CustomerName FROM Customers WHERE LEN(CustomerName)>20

--9. Compare the results of character count and byte count for the string 'SQL Server' with a trailing space.

SELECT LEN('SQL Server    ') AS char_count, DATALENGTH('SQL Server    ') AS byte_count

--10. Write a query to find the byte count of an empty string and explain the result.

SELECT DATALENGTH('');  --This will return 0 because empty string does not have any bytes.

--SELECT DATALENGTH(NULL);

--11. Find the position of 'Server' in the string 'Microsoft SQL Server'.

SELECT CHARINDEX('Server','Microsoft SQL Server')

--12. From an 'Emails' table, write a query to extract the domain name from email addresses.

SELECT RIGHT(EmailAddress,LEN(EmailAddress)-CHARINDEX('@',EmailAddress)) FROM Emails;

--13. Find the position of the first number in the string 'ABC123DEF456'.

SELECT PATINDEX('%[1-9]%','ABC123DEF456')

--14. Write a query to find all product names from a 'Products' table that contain a number.

SELECT ProductName FROM Products WHERE ProductName LIKE ('%[1-9]%');

--15. Join the strings 'SQL', 'Server', and '2022' with spaces between them.

SELECT CONCAT('SQL',' ', 'Server',' ','2022')
SELECT CONCAT_WS(' ','SQL', 'Server', '2022')

--16. From 'Employees' table with 'FirstName' and 'LastName' columns, create a 'FullName' column.

SELECT CONCAT(FirstName,' ',LastName) AS FullName FROM Employees;

--17. Join the array ('SQL', 'Server', '2022') with a hyphen as the separator.

SELECT CONCAT_WS('-','SQL', 'Server', '2022')

--18. From an 'Addresses' table, combine 'Street', 'City', 'State', and 'ZIP' columns into a single address string.

SELECT CONCAT_WS(', ',Street,City,State,ZIP) AS ADDRESS;

--19. Change all occurrences of 'a' to 'e' in the string 'database management'.

SELECT REPLACE('database management','a','e')

--20. From a 'Products' table, write a query to replace all spaces in product names with underscores.

SELECT REPLACE(ProductName,' ','_') FROM Products;

--21. Create a string of 10 asterisks (*).

SELECT REPLICATE('*',10)

--22. Write a query to pad all product codes in a 'Products' table to a length of 10 characters with leading zeros.

SELECT CONCAT(ProductCode,REPLICATE('0',10-LEN(ProductCode))) FROM Products

--23. Insert the string 'New ' at the beginning of 'York City'.

SELECT STUFF('York City',1,0,'New ');

--24. From an 'Emails' table, mask the username part of email addresses, showing only the first and last characters.

SELECT 
	CONCAT(
		STUFF(
			LEFT(EmailAddress,
				CHARINDEX('@',EmailAddress)-1
			) ,
			2,
			CHARINDEX('@',EmailAddress)-3,
			REPLICATE('*',CHARINDEX('@',EmailAddress)-2)
		),
		'@',
		RIGHT(EmailAddress,LEN(EmailAddress)-CHARINDEX('@',EmailAddress))
		) AS hidden_emails,
	EmailAddress AS actual_emails
FROM Emails;

--25. Convert the string 'sql server' to uppercase.

SELECT UPPER('sql server');

--26. Write a query to convert all customer names in a 'Customers' table to uppercase.

SELECT UPPER(CustomerName) FROM Customers;

--27. Convert the string 'SQL SERVER' to lowercase.

SELECT LOWER('SQL SERVER');

--28. From a 'Products' table, write a query to convert all product descriptions to lowercase.

SELECT LOWER(ProductDescription) FROM Products;

--29. Remove trailing spaces from the string 'SQL Server    '.

SELECT RTRIM('SQL Server    ')

--30. Write a query to remove trailing spaces from all email addresses in an 'Employees' table.

SELECT RTRIM(EmailAddress) FROM Employees;

--31. Remove leading spaces from the string '   SQL Server'.

SELECT LTRIM('   SQL Server')

--32. From a 'Comments' table, write a query to remove leading spaces from all comment texts.

SELECT LTRIM(Comment) FROM Comments

--33. Display the current date in the format 'dd-MM-yyyy'.

SELECT FORMAT(GETDATE(),'dd-MM-yyyy')

--34. From an 'Orders' table with an 'OrderTotal' column, display the total as a currency with 2 decimal places.

SELECT FORMAT(OrderTotal,'C','en-IN') FROM Orders;

--35. Separate the string 'apple,banana,cherry' into individual fruits.

SELECT * FROM string_split('apple,banana,cherry',',')

--36. From a 'Skills' table with a 'SkillList' column containing comma-separated skills, write a query to create a row for each individual skill.

SELECT value as skills FROM Skills CROSS APPLY  string_split(SkillList,',') 

--Date and Time Functions

--37. Write a query to display the current date and time.

SELECT GETDATE();
SELECT DATEADD(MINUTE,330,GETDATE())

--38. From an 'Orders' table, find all orders placed in the last 24 hours.

SELECT * FROM Orders WHERE OrderDATE >= DATEADD(HOUR,-24,GETDATE())

--39. Display the current UTC date and time.

SELECT SYSDATETIME();

--40. Write a query to show the time difference between local time and UTC time.

SELECT DATEDIFF(MINUTE,SYSDATETIME(),DATEADD(MINUTE,330,GETDATE()))

--41. Convert the current date and time to 'Pacific Standard Time'.

SELECT CONVERT(datetime,SYSDATETIMEOFFSET() AT TIME ZONE 'Pacific Standard Time');

--42. From a 'Flights' table with a 'DepartureTime' column in UTC, convert all departure times to 'Eastern Standard Time'.

SELECT CONVERT(datetime,DepartureTime AT TIME ZONE 'Eastern Standard Time') FROM Flights;

--43. Add 3 months to the current date.

SELECT CONVERT(date,DATEADD(MONTH,3,GETDATE()));

--44. From an 'Employees' table, write a query to calculate each employee's retirement date (65 years from their 'DateOfBirth').

SELECT CONVERT(date,DATEADD(YEAR,65,DateOfBirth)) AS retirement_date FROM Employees

--45. Calculate the number of days between '2023-01-01' and '2023-12-31'.

SELECT DATEDIFF(DAY,'2023-01-01','2023-12-31')

--46. From an 'Orders' table, find the average number of days between order date and ship date.

SELECT DATEDIFF(DAY,OrderDate,ShipDate) FROM Orders

--47. Extract the month number from the date '2023-09-15'.

SELECT MONTH('2023-09-15')

--48. From a 'Sales' table, write a query to group total sales by the quarter of the sale date.

SELECT DATEPART(QQ,SaleDate) AS quarter,SUM(SaleAmount) AS total_sales FROM Sales GROUP BY DATEPART(QQ,SaleDate)

--49. Extract the year from the current date.

SELECT YEAR(GETDATE())
SELECT DATEPART(year,GETDATE())

--50. From an 'Employees' table, find all employees hired in the year 2022.

SELECT * from Employees WHERE YEAR(HireDate)=2022

--51. Check if '2023-02-30' is a valid date.

SELECT 
	CASE 
		WHEN (1=ISDATE('2023-02-30')) THEN 'Yes'
		ELSE 'No'
	END AS is_valid


--52. Write a query to find all rows in a 'UserInputs' table where the 'EnteredDate' column contains invalid dates.

SELECT * FROM UserInputs WHERE 0 = ISDATE(EnteredDate)

--53. Find the last day of the current month.

SELECT EOMONTH(GETDATE())

--54. From a 'Subscriptions' table, write a query to extend all subscription end dates to the end of their respective months.

SELECT EOMONTH(EndDate) AS EndDate FROM Subscriptions

--55. Display the current date and time.

SELECT CONVERT(datetime,SYSDATETIMEOFFSET() AT TIME ZONE 'India Standard Time' )

--56. Compare the results of two different methods to get the current timestamp - are they always the same?

--They are not always same. Some will return utc time , some local time and others include offsets. 

SELECT 
	SYSDATETIME() AS sysdatetime,
	SYSDATETIMEOFFSET() AS sysdatetimeoffset,
	GETDATE() as getdate,
	GETUTCDATE() as getutcdate

--57. Get the current date and time with higher precision than standard methods.

SELECT SYSDATETIME()

--58. Write a query to insert the current high-precision timestamp into a 'Logs' table.

INSERT INTO LOGS (high_precision) VALUES(SYSDATETIME())

--59. Display the current UTC date and time with high precision.

SELECT SYSDATETIME()

--60. Calculate the difference in microseconds between the current local time and UTC time.

SELECT DATEDIFF(SECOND, SYSDATETIME() AT TIME ZONE 'India Standard Time',SYSUTCDATETIME() ) ;

--61. Get the current date, time, and time zone offset.

SELECT SYSDATETIMEOFFSET() AT TIME ZONE 'India Standard Time'

--62. From a 'GlobalEvents' table, convert all event times to include time zone offset information.

SELECT EventTime AT TIME ZONE 'UTC' AS EventTime FROM GlobalEvents

--63. Extract the month number from the date '2023-12-25'.

SELECT MONTH('2023-12-25')

--64. From a 'Sales' table, find the total sales for each month of the previous year.

SELECT 
	MONTH(SaleDate) as month_number, 
	SUM(SaleAmount) as sales_per_month,
	count(SaleAmount) as count_of_sales_per_month 
FROM 
	Sales 
WHERE 
	YEAR(SaleDate) = YEAR(DATEADD(YEAR,-1,GETDATE())) 
GROUP BY 
	MONTH(SaleDate)

--65. Extract the day of the month from '2023-03-15'.

SELECT DAY('2023-03-15')

--66. Write a query to find all orders from an 'Orders' table that were placed on the 15th day of any month.

SELECT * FROM Orders WHERE DAY(OrderDate) = 15

--67. Get the name of the month for the date '2023-09-01'.

SELECT DATENAME(MONTH,'2023-09-01')

--68. From an 'Events' table, write a query to display the day of the week (in words) for each event date.

SELECT DATENAME(WEEKDAY,EventDate) FROM Events

--69. Create a date for Christmas Day 2023.

SELECT DATEFROMPARTS(2023,12,25) AS ChristmasDay

--70. Write a query to convert separate year, month, and day columns from a 'Dates' table into a single DATE column.

SELECT DATEFROMPARTS(year,month,day) AS DATE FROM Dates