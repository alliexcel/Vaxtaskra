CREATE TABLE [dbo].[Gjaldskra_Product]
(
	[Product_gjaldID] INT NOT NULL PRIMARY KEY, 
    [TegundGjaldID] INT NOT NULL, 
    [ProductID] INT NOT NULL, 
    [GjaldskraID] INT NOT NULL, 
    CONSTRAINT [FK_Table1_Tegund_gjalds] FOREIGN KEY (TegundGjaldID) REFERENCES Tegund_Gjalds(TegundGjaldID), 
    CONSTRAINT [FK_Table1_ToTable_1] FOREIGN KEY (ProductID) REFERENCES Product(ProductID), 
    CONSTRAINT [FK_Table1_ToTable_2] FOREIGN KEY (GjaldskraID) REFERENCES Gjaldskra(GjaldskraID)
)
