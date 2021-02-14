CREATE TABLE [dbo].[Products] (
    [ProductId]       NUMERIC (18)     IDENTITY (1, 1) NOT NULL,
    [ProductIdentity] UNIQUEIDENTIFIER NULL,
    [ProductName]     VARCHAR (50)     NULL,
    [UnitPrice]       FLOAT (53)       NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);

