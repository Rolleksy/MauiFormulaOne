CREATE PROCEDURE [dbo].[spDrivers_Delete]
		@DriverId nvarchar(50)
AS
begin
	delete 
	from dbo.[Drivers]
	where driverId = @DriverId;
end
