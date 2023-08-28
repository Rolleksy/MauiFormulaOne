CREATE PROCEDURE [dbo].[spDrivers_Get]
	@DriverId nvarchar(50)
AS
begin
	select * 
	from dbo.[Drivers]
	where driverId = @DriverId;
end