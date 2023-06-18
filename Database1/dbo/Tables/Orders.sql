CREATE TABLE [dbo].[Orders] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [ClientName] NVARCHAR (100)  NOT NULL,
    [CookieName] NVARCHAR (100)  NOT NULL,
    [UnitPrice]  DECIMAL (10, 2) NOT NULL,
    [Quantity]   INT             NOT NULL,
    [OrderDate]  DATETIME        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



