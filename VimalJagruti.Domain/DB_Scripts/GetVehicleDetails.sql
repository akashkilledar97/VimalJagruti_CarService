CREATE OR ALTER PROCEDURE [GetVehicleDetails](@VehicleNumber nvarchar(max))
AS
BEGIN
SET NOCOUNT ON

SELECT * FROM VehicleDetails as v WHERE v.VehicleNumber = @VehicleNumber;

END