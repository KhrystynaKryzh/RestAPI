create database project1;
use project1;
CREATE TABLE ProductsStock(
	productNo INT PRIMARY KEY IDENTITY(210010,1) NOT NULL ,
	productCategory VARCHAR (50) NOT NULL,
	productName VARCHAR (50) NOT NULL UNIQUE,
	productDescription VARCHAR (100) NOT NULL ,
	productColor VARCHAR (60) NOT NULL,
	productQty_XS INT NOT NULL,
	productQty_S INT NOT NULL,
	productQty_M INT NOT NULL,
	productQty_L INT NOT NULL,
	productQty_XL INT NOT NULL,
	productIsInStock VARCHAR(5) NOT NULL,
	productPrice DECIMAL(10,2) NOT NULL,
);
ALTER TABLE ProductsStock
ADD CHECK (productQty_XS>=0);
ALTER TABLE ProductsStock
ADD CHECK (productQty_S>=0);
ALTER TABLE ProductsStock
ADD CHECK (productQty_M>=0);
ALTER TABLE ProductsStock
ADD CHECK (productQty_L>=0);
ALTER TABLE ProductsStock
ADD CHECK (productQty_XL>=0);

SELECT * FROM Orders;
select * from ProductsStock;
SELECT * FROM Customers;
SELECT * FROM SubmittedOrders;


INSERT INTO ProductsStock VALUES ('T-SHIRT', 'Strappy halter top', 'Halter top with criss-cross straps at the back.', 'BLACK',20,20,24,19,19,'YES', 20);
INSERT INTO ProductsStock VALUES ('T-SHIRT', 'Printed Bridgerton top', 'Short sleeve T-shirt with a round neck. Front print detail.', 'PINK',25,29,21,19,20,'YES', 18);
INSERT INTO ProductsStock VALUES ('T-SHIRT', 'Seamless crepe T-shirt', 'T-shirt with a round neck and short sleeves. Seamless fabric.', 'YELLOW',15,15,20,20,15,'YES', 17);
INSERT INTO ProductsStock VALUES ('DRESS', 'Halter knit dress', 'Long knit dress with a halter neck and criss-cross straps at the back.', 'BLUE',10,5,10,10,15,'YES', 17);

----------------------------------------------------------Submit Order----------------------------------------
CREATE TABLE SubmittedOrders(
	OrderNo INT IDENTITY(2000,1) PRIMARY KEY,
	CustomerUserName VARCHAR (100) FOREIGN KEY REFERENCES Customers(customerUserName),
	OrderSum INT not null
	);
select * from SubmittedOrders;

ALTER TABLE SubmittedOrders
ADD TransactionDate DATETIME not null;

---------------------------------------------PROCEDURE ---ADD TO ORDER --------------------------------------

	CREATE PROCEDURE addToOrder2(@productNo INT,@CustomerUserName VARCHAR(30), @size VARCHAR(3),@quantity INT) 
	AS
	BEGIN 
		IF @size ='XS'
			BEGIN 
			UPDATE ProductsStock SET productQty_XS=(productQty_XS-@quantity) WHERE productNo=@productNo;
			INSERT INTO Orders (Product_No,CustomerUserName, Product_Name,Product_Size,Product_Price, Product_Qtity,Order_Status)VALUES((SELECT productNo FROM ProductsStock WHERE productNo=@productNo),@CustomerUserName, (SELECT productName FROM ProductsStock WHERE productNo=@productNo),'XS',(SELECT productPrice FROM ProductsStock WHERE productNo=@productNo), @quantity, 'PENDING' );
			END
		IF @size ='S'
			BEGIN 
			UPDATE ProductsStock SET productQty_S=(productQty_S-@quantity) WHERE productNo=@productNo;
			INSERT INTO Orders (Product_No,CustomerUserName, Product_Name,Product_Size,Product_Price, Product_Qtity,Order_Status)VALUES((SELECT productNo FROM ProductsStock WHERE productNo=@productNo),@CustomerUserName, (SELECT productName FROM ProductsStock WHERE productNo=@productNo),'S',(SELECT productPrice FROM ProductsStock WHERE productNo=@productNo), @quantity,'PENDING' );

			END
		IF @size ='M'
			BEGIN 
			UPDATE ProductsStock SET productQty_M=(productQty_M-@quantity) WHERE productNo=@productNo;
			INSERT INTO Orders (Product_No,CustomerUserName, Product_Name,Product_Size,Product_Price, Product_Qtity,Order_Status)VALUES((SELECT productNo FROM ProductsStock WHERE productNo=@productNo),@CustomerUserName, (SELECT productName FROM ProductsStock WHERE productNo=@productNo),'M',(SELECT productPrice FROM ProductsStock WHERE productNo=@productNo), @quantity,'PENDING' );

			END
		IF @size ='L'
			BEGIN 
			UPDATE ProductsStock SET productQty_L=(productQty_L-@quantity) WHERE productNo=@productNo;
			INSERT INTO Orders (Product_No,CustomerUserName, Product_Name,Product_Size,Product_Price, Product_Qtity,Order_Status)VALUES((SELECT productNo FROM ProductsStock WHERE productNo=@productNo),@CustomerUserName, (SELECT productName FROM ProductsStock WHERE productNo=@productNo),'L',(SELECT productPrice FROM ProductsStock WHERE productNo=@productNo), @quantity,'PENDING' );

			END
		IF @size ='XL'
			BEGIN 
			UPDATE ProductsStock SET productQty_XL=(productQty_XL-@quantity) WHERE productNo=@productNo;
			INSERT INTO Orders (Product_No,CustomerUserName, Product_Name,Product_Size,Product_Price, Product_Qtity,Order_Status)VALUES((SELECT productNo FROM ProductsStock WHERE productNo=@productNo),@CustomerUserName, (SELECT productName FROM ProductsStock WHERE productNo=@productNo),'XL',(SELECT productPrice FROM ProductsStock WHERE productNo=@productNo), @quantity,'PENDING' );
			END
	END

	--EXEC  addToOrder2 210011,KK98,98000,'S',1;
------------------------------------------------PROCEDURE SUBMIT ORDER-------------------------------------

	CREATE PROCEDURE submitorder3 (@CustomerUserName VARCHAR(30))
	AS
	BEGIN 

		INSERT INTO SubmittedOrders VALUES (@CustomerUserName, (SELECT sum(Product_Qtity * Product_Price)
			FROM Orders 
			WHERE Order_Status = 'PENDING' AND CustomerUserName= @CustomerUserName), GETDATE());

		UPDATE Orders SET Order_Status= 'SUBMITED' WHERE Order_Status = 'PENDING' AND CustomerUserName= @CustomerUserName;
		
	END

	--EXEC  submitorder3 'IRA';
----------------------------------------------------------------------------------------------------------------------------------------

	SELECT *  FROM ProductsStock;

