CREATE DATABASE DataStreamDB;

USE DataStreamDB;

-- 1. Create Tables
CREATE TABLE Clients (
    ClientId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    Email NVARCHAR(150),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    [Name] NVARCHAR(100),
    Price DECIMAL(18,2),
    Category NVARCHAR(50)
);

CREATE TABLE Sales (
    SaleId INT IDENTITY(1,1) PRIMARY KEY,
    ClientId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT,
    TotalAmount DECIMAL(18,2),
    SaleDate DATETIME,
    CONSTRAINT FK_Sales_Clients FOREIGN KEY (ClientId) REFERENCES Clients(ClientId),
    CONSTRAINT FK_Sales_Products FOREIGN KEY (ProductId) REFERENCES Products(ProductId)
);

SET NOCOUNT ON;

-- 2. Populate Products (1,000 rows)
INSERT INTO Products ([Name], Price, Category)
SELECT TOP 1000 
    'Product ' + CAST(ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS VARCHAR),
    (ABS(CHECKSUM(NEWID())) % 500) + 10.50,
    CASE WHEN ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) % 3 = 0 THEN 'Electronics' ELSE 'Home' END
FROM sys.all_columns a CROSS JOIN sys.all_columns b;

-- 3. Populate Clients (100,000 rows)
WITH CTE_Nums AS (
    SELECT TOP 100000 ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS n
    FROM sys.all_columns a CROSS JOIN sys.all_columns b
)
INSERT INTO Clients (FullName, Email)
SELECT 'Client Name ' + CAST(n AS VARCHAR), 'user' + CAST(n AS VARCHAR) + '@example.com'
FROM CTE_Nums;

-- 4. Populate Sales (5,000,000 rows)
DECLARE @ClientCount INT = (SELECT COUNT(*) FROM Clients);
DECLARE @ProductCount INT = (SELECT COUNT(*) FROM Products);

WITH L0 AS (SELECT 1 AS c UNION ALL SELECT 1),
L1 AS (SELECT 1 AS c FROM L0 AS A CROSS JOIN L0 AS B),
L2 AS (SELECT 1 AS c FROM L1 AS A CROSS JOIN L1 AS B),
L3 AS (SELECT 1 AS c FROM L2 AS A CROSS JOIN L2 AS B),
L4 AS (SELECT 1 AS c FROM L3 AS A CROSS JOIN L3 AS B),
L5 AS (SELECT 1 AS c FROM L4 AS A CROSS JOIN L4 AS B),
Nums AS (SELECT ROW_NUMBER() OVER(ORDER BY (SELECT NULL)) AS n FROM L5)
INSERT INTO Sales (ClientId, ProductId, Quantity, TotalAmount, SaleDate)
SELECT TOP 5000000
    (ABS(CHECKSUM(NEWID())) % @ClientCount) + 1,
    (ABS(CHECKSUM(NEWID())) % @ProductCount) + 1,
    (ABS(CHECKSUM(NEWID())) % 5) + 1,
    0,
    DATEADD(DAY, -(ABS(CHECKSUM(NEWID())) % 365), GETDATE())
FROM Nums;

-- 5. Update TotalAmount based on Product Price
UPDATE Sales 
SET TotalAmount = s.Quantity * p.Price
FROM Sales s
JOIN Products p ON s.ProductId = p.ProductId;