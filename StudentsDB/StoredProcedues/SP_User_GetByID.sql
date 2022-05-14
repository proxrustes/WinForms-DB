CREATE PROCEDURE [dbo].[SP_User_GetByID]
	@Id INT
AS
begin
SELECT * FROM dbo.Peoples WHERE Id = @Id
end