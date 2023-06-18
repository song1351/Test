CREATE TABLE [dbo].[PurchaseOrderDetail] (
    [PurchaseOrderID] INT      IDENTITY (1, 1) NOT NULL,
    [UnitPrice]       MONEY    NULL,
    [OrderQty]        SMALLINT NULL,
    PRIMARY KEY CLUSTERED ([PurchaseOrderID] ASC)
);





