CREATE TABLE [dbo].[Gjaldskra_Product]
(
	[GjaldskraProductID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductID] INT NOT NULL, 
    [GjaldskraID] INT NOT NULL, 
    [TegundGjaldID] INT NOT NULL, 
    CONSTRAINT [FK_Gjaldskra_Product_Product] FOREIGN KEY (ProductID) REFERENCES Product(ProductID), 
    CONSTRAINT [FK_Gjaldskra_Product_Gjaldskra] FOREIGN KEY (GjaldskraID) REFERENCES Gjaldskra(GjaldskraID), 
    CONSTRAINT [FK_Gjaldskra_Product_TegundGjaldID] FOREIGN KEY (TegundGjaldID) REFERENCES Tegund_gjalds(TegundGjaldID)
)
