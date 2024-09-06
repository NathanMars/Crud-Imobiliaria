CREATE TABLE [dbo].[Cliente]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nome] NVARCHAR(50) NULL, 
    [email] NVARCHAR(50) NULL, 
    [cpf] NCHAR(14) NULL, 
    [idade] INT NULL, 
    [estadoCivil] NVARCHAR(50) NULL, 
    [telefone] NVARCHAR(50) NULL
)
