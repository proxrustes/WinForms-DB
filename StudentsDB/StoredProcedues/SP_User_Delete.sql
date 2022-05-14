CREATE PROCEDURE [dbo].[sp_UserDelete]
	@Id int
AS
begin
	DELETE dbo.[Peoples] WHERE Id = @Id;
end
