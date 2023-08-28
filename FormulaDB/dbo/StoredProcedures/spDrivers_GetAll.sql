CREATE PROCEDURE [dbo].[spDrivers_GetAll]
AS
begin
	select *
	from dbo.[Drivers];
end
