CREATE TABLE [dbo].[ServerDB]
(
	[Id] INT NOT NULL  IDENTITY, 
    [username] NVARCHAR(50) NOT NULL, 
    [password] NVARCHAR(50) NOT NULL, 
    PRIMARY KEY ([username])
)
