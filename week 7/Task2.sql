CREATE SCHEMA task2
GO
-- Create a table named "Employees" with columns for ID (integer), Name (varchar), and Salary (decimal).
CREATE TABLE Employees (
    ID INT,
    Name VARCHAR(100),
    Salary DECIMAL(10,2)
);
-- Add a new column named "Department" to the "Employees" table with data type varchar(50).
ALTER TABLE Employees
ADD Department VARCHAR(50);
-- Remove the "Salary" column from the "Employees" table.
ALTER TABLE Employees
DROP COLUMN Salary;
-- Rename the "Department" column in the "Employees" table to "DeptName".
-- SQL Server uses sp_rename for column renaming
EXEC sp_rename 'Employees.Department', 'DeptName', 'COLUMN';
-- Create a new table called "Projects" with columns for ProjectID (integer) and ProjectName (varchar).
CREATE TABLE Projects (
    ProjectID INT,
    ProjectName VARCHAR(100)
);
-- Add a primary key constraint to the "Employees" table for the "ID" column.
ALTER TABLE Employees
ADD CONSTRAINT PK_Employees PRIMARY KEY (ID);
-- Add a unique constraint to the "Name" column in the "Employees" table.
ALTER TABLE Employees
ADD CONSTRAINT UQ_Employees_Name UNIQUE (Name);
-- Create a table named "Customers" with columns for CustomerID (integer), FirstName (varchar), LastName (varchar), and Email (varchar), and Status (varchar).
CREATE TABLE Customers (
    CustomerID INT,
    FirstName VARCHAR(100),
    LastName VARCHAR(100),
    Email VARCHAR(150),
    Status VARCHAR(50)
);
-- Add a unique constraint to the combination of "FirstName" and "LastName" columns in the "Customers" table.
ALTER TABLE Customers
ADD CONSTRAINT UQ_Customers_FullName UNIQUE (FirstName, LastName);
-- Create a table named "Orders" with columns for OrderID (integer), CustomerID (integer), OrderDate (datetime), and TotalAmount (decimal).
CREATE TABLE Orders (
    OrderID INT,
    CustomerID INT,
    OrderDate DATETIME,
    TotalAmount DECIMAL(10,2)
);
-- Add a check constraint to the "TotalAmount" column in the "Orders" table to ensure that it is greater than zero.
ALTER TABLE Orders
ADD CONSTRAINT CHK_Orders_TotalAmount CHECK (TotalAmount > 0);
-- Create a schema named "Sales" and move the "Orders" table into this schema.
-- CREATE SCHEMA must be in its own batch
GO
CREATE SCHEMA Sales;
GO
ALTER SCHEMA Sales TRANSFER dbo.Orders;
-- Rename the "Orders" table to "SalesOrders."
EXEC sp_rename 'Sales.Orders', 'SalesOrders';