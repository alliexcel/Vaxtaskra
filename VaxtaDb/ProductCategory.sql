CREATE TABLE [dbo].[ProductCategory]
(
	[ProductCategoryID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CategoryName] VARCHAR(250) NOT NULL, 
    [ProductTypeID] INT NOT NULL, 
    [is_individual_product] BIT NULL, 
    CONSTRAINT [FK_ProductCategory_ProductType] FOREIGN KEY (ProductTypeID) REFERENCES ProductType(ProductTypeID)
)
