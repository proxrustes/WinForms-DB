CREATE TABLE [dbo].[Peoples] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50) NULL,
    [LastName]    NVARCHAR (10)    NULL,
    [FatherName]  NVARCHAR (10)    NULL,
    [Email]       NVARCHAR (20)    NULL,
    [University]  NVARCHAR (8)     NULL,
    [Birthday]    DATE          NULL,
    [PhoneNumber] NVARCHAR     NULL,
    [Telegram]    NVARCHAR (15)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

