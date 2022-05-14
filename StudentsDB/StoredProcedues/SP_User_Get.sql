CREATE PROCEDURE [dbo].[sp_UserGet]
	@Text NVARCHAR
AS
begin
SELECT * FROM dbo.Peoples WHERE LastName = @Text
end
