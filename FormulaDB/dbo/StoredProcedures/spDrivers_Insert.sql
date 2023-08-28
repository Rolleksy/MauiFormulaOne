CREATE PROCEDURE [dbo].[spDrivers_Insert]
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
	insert into dbo.[Drivers] (DriverId, url, GivenName, FamilyName, DateOfBirth, Nationality, PermanentNumber, Code)
	values (@DriverId, @url, @givenName, @familyName, @dateOfBirth, @nationality, @permanentNumber, @code)
end