CREATE TABLE [dbo].[Product]
(
	[ProductID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductName] VARCHAR(250) NOT NULL, 
    [ProductCategoryID] INT NOT NULL, 
    [Active] BIT NULL, 
    [SourceSystemID] INT NOT NULL, 
    CONSTRAINT [FK_Products_ProductCategory] FOREIGN KEY (ProductCategoryID) REFERENCES ProductCategory(ProductCategoryID), 
    CONSTRAINT [FK_Product_SourceSystem] FOREIGN KEY (SourceSystemID) REFERENCES SourceSystem(SourceSystemID)
)
