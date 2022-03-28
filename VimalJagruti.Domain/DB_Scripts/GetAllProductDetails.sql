CREATE OR ALTER PROCEDURE [GetAllProductDetails]
AS
BEGIN
SET NOCOUNT ON

SELECT p.Id AS ProductId , p.ProductName, pc.CategoryName FROM Products as p INNER JOIN ProductCategories as pc ON pc.Id = p.CategoryId_FK;

END