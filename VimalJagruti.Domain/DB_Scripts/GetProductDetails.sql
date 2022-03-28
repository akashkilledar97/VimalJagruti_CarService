CREATE OR ALTER PROCEDURE [GetProductDetails](@Id nvarchar(max))
AS
BEGIN
SET NOCOUNT ON

SELECT p.Id AS ProductId , p.ProductName, pc.CategoryName FROM Products as p INNER JOIN ProductCategories as pc ON pc.Id = p.CategoryId_FK WHERE p.Id = @Id;

END