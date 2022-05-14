CREATE PROCEDURE [dbo].[sp_UserGetAll]
	@Id int,
	@FirstName NVARCHAR(30),
	@LastName NVARCHAR(30)
AS
begin
	SELECT * FROM dbo.[Peoples]
end
