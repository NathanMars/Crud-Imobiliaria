CREATE TABLE [dbo].[Contrato] (
    [Id]         INT           NOT NULL IDENTITY,
    [idCliente]  INT           NULL,
    [idImovel]   INT           NULL,
    [dataCompra] DATETIME NULL,
    [corretor]   NVARCHAR(50) NULL,
    [dataInicio] DATETIME NULL,
    [dataFIm]    DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([idCliente]) REFERENCES [dbo].[Cliente] ([Id]),
    FOREIGN KEY ([idImovel]) REFERENCES [dbo].[Imovel] ([Id])
);

