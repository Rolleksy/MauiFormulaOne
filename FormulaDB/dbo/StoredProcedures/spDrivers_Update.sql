CREATE PROCEDURE [dbo].[spDrivers_Update]
			@DriverId nvarchar(50),
		@url nvarchar(100),
		@givenName nvarchar(50),
		@familyName nvarchar(50),
		@dateOfBirth nvarchar(50),
		@nationality nvarchar(50),
		@permanentNumber nvarchar(10),
		@code nvarchar(20)
AS
begin
	update dbo.[Drivers]
	set url = @url, GivenName = @givenName, FamilyName = @familyName, DateOfBirth = @dateOfBirth, Nationality = @nationality, PermanentNumber = @permanentNumber, Code = @code
	where DriverId = @DriverId;
end