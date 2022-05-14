CREATE PROCEDURE [dbo].[sp_UserUpdate]
	@Id int,
	@FirstName NVARCHAR(30),
	@LastName NVARCHAR(30),
	@FatherName  NCHAR (10)   ,
    @Email       NCHAR (20) ,  
    @University		NCHAR (8)   ,
    @Birthday		DATE       , 
    @PhoneNumber NCHAR,
    @Telegram    NCHAR (15)
AS
begin
	UPDATE dbo.[Peoples] SET 
	FirstName = @FirstName, 
	LastName = @LastName, 
	FatherName=@FatherName, 
	Email=@Email  ,
	University=@University,
	Birthday=@Birthday,
	PhoneNumber=@PhoneNumber,
	Telegram=@Telegram
	
	WHERE Id = @Id;
end
