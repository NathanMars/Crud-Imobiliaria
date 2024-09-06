CREATE TABLE [dbo].[Imovel]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [tipo] NVARCHAR(50) NULL, 
    [endereco] NVARCHAR(50) NULL, 
    [valorVenda] MONEY NULL, 
    [valorAluguel] MONEY NULL, 
    [nQuartos] INT NULL, 
    [nBanheiros] INT NULL, 
    [vagasGaragem] INT NULL
)
