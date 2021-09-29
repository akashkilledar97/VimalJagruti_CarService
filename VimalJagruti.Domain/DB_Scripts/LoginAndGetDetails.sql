CREATE PROCEDURE [LoginAndGetDetails](@username nvarchar(max))
AS
BEGIN
SET NOCOUNT ON

SELECT Id,CONCAT(FirstName,' ',LastName) as FullName,Password,RefreshToken,Username,Roles,RefreshToken FROM Users as u WHERE u.Username = @username;

END