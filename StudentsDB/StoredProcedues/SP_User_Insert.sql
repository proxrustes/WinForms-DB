CREATE PROCEDURE [dbo].[sp_UserInsert]

	@FirstName NVARCHAR(30),
	@LastName NVARCHAR(30),
	@FatherName  NVARCHAR (10)   ,
    @Email       NVARCHAR (20) ,  
    @University		NVARCHAR (8)   ,
    @Birthday		DATE       , 
    @PhoneNumber NVARCHAR,
    @Telegram    NVARCHAR (15)
AS
begin
	INSERT INTO dbo.[Peoples] (FirstName, 
	LastName, 
	FatherName, 
	Email,
	University,
	Birthday,
	PhoneNumber,
	Telegram)
	
	VALUES
	(@FirstName, 
	@LastName, 
	@FatherName, 
	@Email,
	@University,
	@Birthday,
	@PhoneNumber,
	@Telegram)

end