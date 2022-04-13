use project1;
CREATE TABLE Customers(
	customerName VARCHAR (50) NOT NULL,
	customerUserName VARCHAR (100) PRIMARY KEY, 
	customerPasw VARCHAR (60) NOT NULL,
	customerEmail VARCHAR (50) NOT NULL UNIQUE,
	);
	ALTER TABLE Customers
	ADD FOREIGN KEY (customerUserName) REFERENCES Orders(customerUserName);

INSERT INTO Customers VALUES('JOHN SMITH', 'JOHN95','JOHNSMITH98','JS1989@GMAIL.COM');
INSERT INTO Customers VALUES('HANNA DAVIDSON', 'HANNNNAAA','DAVIDSON18','HANDAV@GMAIL.COM');
INSERT INTO Customers VALUES('OLIVIA MARKSON', 'OLIM','OLIVIA7','MARKSONOLI@GMAIL.COM');

CREATE TABLE Orders(
	OrderNo INT IDENTITY(1000,1) PRIMARY KEY,
	CustomerUserName VARCHAR (100) FOREIGN KEY REFERENCES Customers(customerUserName),
	Product_No INT NOT NULL ,
	Product_Name VARCHAR (50) NOT NULL,
	Product_Size VARCHAR (5) NOT NULL,
	Product_Price DECIMAL(10,2) NOT NULL,
	Product_Qtity INT NOT NULL ,
	Order_Status VARCHAR (10) NOT NULL

	)
	ALTER TABLE Orders
		ADD FOREIGN KEY (Product_No) REFERENCES ProductsStock(productNo);

SELECT * FROM Orders;
SELECT sum(Product_Qtity * Product_Price)FROM Orders WHERE Order_Status = 'PENDING' AND CustomerUserName= 'OLIM'

INSERT INTO Orders VALUES( 'OLIM',210016,'Round neck cotton sweater','M',24.00,2,'PENDING');

SELECT*FROM Customers;
SELECT*FROM Orders;

SELECT CustomerID, SUM(Product_Price) AS Total FROM Orders WHERE Order_Status= 'PENDING' GROUP BY CustomerID;
DROP TABLE Orders;
DROP TABLE Customers;


